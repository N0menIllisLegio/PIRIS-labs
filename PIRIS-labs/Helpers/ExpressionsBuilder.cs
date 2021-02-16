using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using PIRIS_labs.Data.Entities;
using PIRIS_labs.Enums;
using PIRIS_labs.Models;

namespace PIRIS_labs.Helpers
{
  public static class ExpressionsBuilder
  {
    private const string _dateFormat = "dd.MM.yyyy";
    private const string _dateTimeFormat = "dd.MM.yyyy HH:mm";

    private static readonly MethodInfo _stringContainsMethod = typeof(string)
      .GetMethod("Contains", new[] { typeof(string) });

    private static readonly HashSet<Type> _searchableTypes = new HashSet<Type>
    {
      typeof(byte),
      typeof(sbyte),
      typeof(int),
      typeof(uint),
      typeof(long),
      typeof(ulong),
      typeof(double),
      typeof(decimal),
      typeof(DateTime),
      typeof(string)
    };

    // Calling Parse method via reflection doesn't work on Mono on Android in Release setup :(
    private static readonly Dictionary<string, Func<string, object>> _parseMethods =
      new Dictionary<string, Func<string, object>>
      {
        { typeof(bool).Name, str => Boolean.Parse(str) },
        { typeof(byte).Name, str => Byte.Parse(str, CultureInfo.InvariantCulture) },
        { typeof(sbyte).Name, str => SByte.Parse(str, CultureInfo.InvariantCulture) },
        { typeof(short).Name, str => Int16.Parse(str, CultureInfo.InvariantCulture) },
        { typeof(ushort).Name, str => UInt16.Parse(str, CultureInfo.InvariantCulture) },
        { typeof(int).Name, str => Int32.Parse(str, CultureInfo.InvariantCulture) },
        { typeof(uint).Name, str => UInt32.Parse(str, CultureInfo.InvariantCulture) },
        { typeof(long).Name, str => Int64.Parse(str, CultureInfo.InvariantCulture) },
        { typeof(ulong).Name, str => UInt64.Parse(str, CultureInfo.InvariantCulture) },
        { typeof(float).Name, str => Single.Parse(str, CultureInfo.InvariantCulture) },
        { typeof(double).Name, str => Double.Parse(str, CultureInfo.InvariantCulture) },
        { typeof(decimal).Name, str => Decimal.Parse(str, CultureInfo.InvariantCulture) },
        { typeof(Guid).Name, str => Guid.Parse(str) },
        { typeof(string).Name, str => str },
      };

    /// <summary>
    /// Specifies how a given binary operation must handle NULL value as its right operand.
    /// </summary>
    private enum NullEvaluationStrategy
    {
      /// <summary>
      /// A binary operatrion is always TRUE for NULL.
      /// </summary>
      AlwaysTrue,

      /// <summary>
      /// A binary operation is always FALSE for NULL.
      /// </summary>
      AlwaysFalse,

      /// <summary>
      /// A binary operation can be either TRUE or FALSE for NULL and must be evaluated as usual.
      /// </summary>
      Evaluate
    }

    public static IQueryable<TEntity> SearchBy<TEntity>(this IQueryable<TEntity> entities,
      string searchString,
      Expression<Func<TEntity, object>> searchedPropertiesSelector = null,
      IEnumerable<FilterCriterion> filterCriteria = null,
      Expression<Func<TEntity, bool>> additionalFilterCriteria = null)
    {
      return entities.Where(ExpressionsBuilder.BuildFilterExpression<TEntity>(searchString,
        searchedPropertiesSelector, filterCriteria, additionalFilterCriteria));
    }

    public static IQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> entities,
      IEnumerable<SortOption> sortOptions)
    {
      if (sortOptions is null || sortOptions.Count() == 0)
      {
        return entities;
      }

      var sortOptionsList = GetValidPropertyNames<TEntity, SortOption>(sortOptions
        .ToDictionary(sortOption => sortOption.PropertyName)).ToList();

      if (sortOptionsList.Count == 0)
      {
        return entities;
      }

      int propertiesCount = typeof(TEntity).GetProperties(BindingFlags.Public | BindingFlags.Instance).Length;
      bool firstSort = true;
      IOrderedQueryable<TEntity> result = null;

      if (sortOptionsList.Count < propertiesCount)
      {
        propertiesCount = sortOptionsList.Count;
      }

      for (int i = 0; i < propertiesCount; i++)
      {
        var sortOption = sortOptionsList[i];

        if (sortOption.Order == SortOrder.None)
        {
          continue;
        }

        var parameter = Expression.Parameter(typeof(TEntity), "x");

        var orderExpression = Expression.Lambda<Func<TEntity, object>>(Expression.Convert(
          Expression.Property(parameter, sortOption.PropertyName), typeof(object)), parameter);

        switch (sortOption.Order)
        {
          case SortOrder.Ascending:

            result = firstSort
              ? entities.OrderBy(orderExpression)
              : result.ThenBy(orderExpression);

            break;

          case SortOrder.Descending:

            result = firstSort
              ? entities.OrderByDescending(orderExpression)
              : result.ThenByDescending(orderExpression);

            break;

          default:
            throw new ArgumentException(nameof(SortOrder));
        }
      }

      return result;
    }

    public static Expression<Func<TEntity, bool>> BuildFilterExpression<TEntity>(
      string searchString,
      Expression<Func<TEntity, object>> searchedPropertiesSelector = null,
      IEnumerable<FilterCriterion> filterCriteria = null,
      Expression<Func<TEntity, bool>> additionalFilterCriteria = null)
    {
      var filterCriteriaList = filterCriteria?.ToList();

      if (filterCriteria is not null)
      {
        filterCriteriaList = GetValidPropertyNames<TEntity, FilterCriterion>(filterCriteriaList
          .ToDictionary(filter => filter.PropertyName)).ToList();
      }

      var parameter = additionalFilterCriteria?.Parameters[0] ?? Expression.Parameter(typeof(TEntity), "x");
      var body = additionalFilterCriteria?.Body ?? Expression.Constant(true);

      if (filterCriteriaList?.Count > 0)
      {
        var firstCriterionExpression = BuildCriterionExpression(filterCriteriaList[0], typeof(TEntity), parameter);

        body = additionalFilterCriteria == null
          ? firstCriterionExpression
          : Expression.AndAlso(additionalFilterCriteria.Body, firstCriterionExpression);

        for (int i = 1; i < filterCriteriaList.Count; i++)
        {
          body = Expression.AndAlso(body, BuildCriterionExpression(filterCriteriaList[i], typeof(TEntity), parameter));
        }
      }

      if (searchString?.Length > 0)
      {
        var searchedProperties = searchedPropertiesSelector == null
          ? null
          : ((NewExpression)searchedPropertiesSelector.Body).Arguments.Cast<MemberExpression>()
            .Select(expr => (PropertyInfo)expr.Member);

        body = Expression.AndAlso(body,
          BuildSearchExpression(searchString, typeof(TEntity), parameter, searchedProperties));
      }

      return (Expression<Func<TEntity, bool>>)Expression.Lambda(body, parameter);
    }

    private static IEnumerable<string> GetEntitiesPropertiesNames(string parentEntity, Type type)
    {
      var propertiesNames = new List<string>();

      foreach (var property in type.GetProperties()
        .Where(prop => prop.GetCustomAttribute(typeof(ExpressionsBuilderAttribute)) is not null))
      {
        if (typeof(IEntity).IsAssignableFrom(property.PropertyType))
        {
          propertiesNames.AddRange(GetEntitiesPropertiesNames(property.Name + '.', property.PropertyType));
        }
        else
        {
          if (!typeof(System.Collections.IEnumerable).IsAssignableFrom(property.PropertyType))
          {
            propertiesNames.Add(parentEntity + property.Name);
          }
        }
      }

      return propertiesNames;
    }

    private static IEnumerable<TResult> GetValidPropertyNames<TEntity, TResult>(Dictionary<string, TResult> items)
    {
      var existingPropertiesNames = GetEntitiesPropertiesNames(String.Empty, typeof(TEntity));
      var result = new List<TResult>();

      foreach (var item in items)
      {
        if (existingPropertiesNames.Any((prop) => prop.Equals(item.Key)))
        {
          result.Add(item.Value);
        }
      }

      return result;
    }

    private static Expression BuildSearchExpression(string searchString, Type entityType, ParameterExpression parameter,
      IEnumerable<PropertyInfo> searchedProperties)
    {
      Expression body = Expression.Constant(false);

      if (searchedProperties == null)
      {
        // _searchableTypes.Contains(propInfo.PropertyType) is not included here as an optimization:
        // the type of a property is calcualted once and then used for both checking and processing inside the foreach.
        searchedProperties = entityType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
          .Where(propInfo => propInfo.CanWrite);
      }

      foreach (var propertyInfo in searchedProperties)
      {
        var propertyType = propertyInfo.PropertyType;
        var underlyingType = Nullable.GetUnderlyingType(propertyType);
        bool propertyNotNullable = propertyType.IsValueType && underlyingType == null;
        var parsingType = underlyingType ?? propertyType;

        if (!_searchableTypes.Contains(parsingType))
        {
          continue;
        }

        var memberExpression = Expression.Property(parameter, propertyInfo.Name);

        if (propertyType == typeof(string))
        {
          // ... || x.Property != null && x.Property.Contains(searchString)
          body = Expression.OrElse(
            body,
            Expression.AndAlso(
              Expression.NotEqual(memberExpression, Expression.Constant(null, propertyType)),
              Expression.Call(memberExpression, _stringContainsMethod, Expression.Constant(searchString))));
        }
        else
        {
          Expression valueExpression;

          try
          {
            object value;

            // DateTime can stand for date only or for date and time, so DateTime is checked separately.
            if (parsingType == typeof(DateTime))
            {
              bool valueIsDate = DateTime.TryParseExact(searchString, _dateFormat,
                CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateTimeValue);

              if (!valueIsDate)
              {
                dateTimeValue = DateTime.ParseExact(searchString, _dateTimeFormat,
                  CultureInfo.InvariantCulture);
              }

              value = dateTimeValue;
            }
            else
            {
              value = _parseMethods[parsingType.Name].Invoke(searchString);
            }

            valueExpression = Expression.Constant(value, propertyType);
          }
          catch (Exception)
          {
            // Cannot parse searchString as a value of type parsingType
            continue;
          }

          body = propertyNotNullable
            // ... || x.Property == value
            ? Expression.OrElse(body, Expression.Equal(memberExpression, valueExpression))
            // ... || x.Property != null && x.Property == value
            : Expression.OrElse(
              body,
              Expression.AndAlso(
                Expression.NotEqual(memberExpression, Expression.Constant(null, propertyType)),
                Expression.Equal(memberExpression, valueExpression)));
        }
      }

      return body;
    }

    private static Expression BuildCriterionExpression(FilterCriterion filterCriterion, Type entityType,
      ParameterExpression parameter)
    {
      string fullPropertyName = filterCriterion.PropertyName;
      int periodPosition = fullPropertyName.IndexOf('.');
      bool singleProperty = periodPosition == -1;

      string firstPropertyName = singleProperty
        ? fullPropertyName : fullPropertyName.Substring(0, periodPosition);
      string secondPropertyName = singleProperty
        ? null : fullPropertyName.Substring(periodPosition + 1, fullPropertyName.Length - periodPosition - 1);

      var memberExpression = singleProperty
        ? Expression.Property(parameter, fullPropertyName)
        : Expression.Property(Expression.Property(parameter, firstPropertyName), secondPropertyName);

      var propertyType = singleProperty
        ? entityType.GetProperty(fullPropertyName)?.PropertyType
        : entityType
          .GetProperty(firstPropertyName)?.PropertyType?
          .GetProperty(secondPropertyName)?.PropertyType;

      var underlyingType = Nullable.GetUnderlyingType(propertyType);
      bool propertyNotNullable = propertyType.IsValueType && underlyingType == null;

      ConstantExpression valueExpression;
      if (String.IsNullOrEmpty(filterCriterion.Value))
      {
        // Carefuly build default value for non-nullable value types and null for reference and nullable value types.
        valueExpression = propertyNotNullable
          ? Expression.Constant(Activator.CreateInstance(propertyType))
          : Expression.Constant(null, propertyType);
      }
      else
      {
        // If filtered property is Nullable<T>, then it is important to use T itself for parsing, but the original
        // Nullable<T> for the constant expression bellow!
        var parsingType = underlyingType ?? propertyType;

        object filterValue;

        // DateTime can stand for date only or for date and time, so DateTime is checked separately.
        if (parsingType == typeof(DateTime))
        {
          bool valueIsDate = DateTime.TryParseExact(filterCriterion.Value, _dateFormat,
            CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateTimeValue);

          if (!valueIsDate)
          {
            dateTimeValue = DateTime.ParseExact(filterCriterion.Value, _dateTimeFormat,
              CultureInfo.InvariantCulture);
          }

          filterValue = dateTimeValue;
        }
        else
        {
          filterValue = parsingType.IsEnum
          ? Enum.Parse(parsingType, filterCriterion.Value)
          : _parseMethods[parsingType.Name].Invoke(filterCriterion.Value);
        }

        valueExpression = Expression.Constant(filterValue, propertyType);
      }

      // Some strange expressions for NULLs, like (x < NULL) => TRUE are expected.
      Expression result = null;
      switch (filterCriterion.OperatorType)
      {
        case FilterOperatorType.Contains:
          result = Expression.Call(memberExpression, _stringContainsMethod, valueExpression)
            .HandleNulls(memberExpression, valueExpression, propertyNotNullable, NullEvaluationStrategy.AlwaysFalse);
          break;
        case FilterOperatorType.DoesNotContain:
          result = Expression.Not(Expression.Call(memberExpression, _stringContainsMethod, valueExpression))
            .HandleNulls(memberExpression, valueExpression, propertyNotNullable, NullEvaluationStrategy.AlwaysTrue);
          break;
        case FilterOperatorType.Equals:
          result = Expression.Equal(memberExpression, valueExpression)
            .HandleNulls(memberExpression, valueExpression, propertyNotNullable, NullEvaluationStrategy.Evaluate);
          break;
        case FilterOperatorType.DoesNotEqual:
          result = Expression.NotEqual(memberExpression, valueExpression)
            .HandleNulls(memberExpression, valueExpression, propertyNotNullable, NullEvaluationStrategy.Evaluate);
          break;
        case FilterOperatorType.GreaterThan:
          result = Expression.GreaterThan(memberExpression, valueExpression)
            .HandleNulls(memberExpression, valueExpression, propertyNotNullable, NullEvaluationStrategy.AlwaysFalse);
          break;
        case FilterOperatorType.LessThan:
          result = Expression.LessThan(memberExpression, valueExpression)
            .HandleNulls(memberExpression, valueExpression, propertyNotNullable, NullEvaluationStrategy.AlwaysTrue);
          break;
        default:
          throw new NotSupportedException($"Filter operation {filterCriterion.OperatorType} is not supported.");
      }

      return result;
    }

    private static Expression HandleNulls(this Expression mainExpression,
      MemberExpression memberExpression,
      ConstantExpression constantExpression,
      bool propertyNotNullable,
      NullEvaluationStrategy nullEvaluationStrategy)
    {
      if (propertyNotNullable)
      {
        return constantExpression.Value == null ? Expression.Constant(false) : mainExpression;
      }
      else
      {
        switch (nullEvaluationStrategy)
        {
          case NullEvaluationStrategy.AlwaysFalse:
            return constantExpression.Value == null
              ? (Expression)Expression.Constant(false)
              : Expression.AndAlso(
                  Expression.NotEqual(memberExpression, Expression.Constant(null, constantExpression.Type)),
                  mainExpression);

          case NullEvaluationStrategy.AlwaysTrue:
            return constantExpression.Value == null
              ? (Expression)Expression.Constant(true)
              : Expression.OrElse(
                  Expression.Equal(memberExpression, Expression.Constant(null, constantExpression.Type)),
                  mainExpression);

          case NullEvaluationStrategy.Evaluate:
            return mainExpression;

          default:
            throw new ApplicationException("Unexpected NullEvaluationStrategy encountered.");
        }
      }
    }
  }
}
