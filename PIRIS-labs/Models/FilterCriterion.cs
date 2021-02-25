using PIRIS_labs.Enums;

namespace PIRIS_labs.Models
{
  public class FilterCriterion
  {
    public string PropertyName { get; set; }
    public string Value { get; set; }
    public FilterOperatorType OperatorType { get; set; }
  }
}
