using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PIRIS_labs.Models;

namespace PIRIS_labs.DTOs
{
  public class PagedInfoDto: IValidatableObject
  {
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public string SearchString { get; set; }

    public List<SortOption> SortOptions { get; set; }

    public List<FilterCriterion> Filters { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
      const int minimumItemsPerPage = 10;
      const int maximumItemsPerPage = 20;

      if (PageNumber <= 0)
      {
        PageNumber = 1;
      }

      if (PageSize < minimumItemsPerPage)
      {
        PageSize = minimumItemsPerPage;
      }
      else if (PageSize > maximumItemsPerPage)
      {
        PageSize = maximumItemsPerPage;
      }

      return new List<ValidationResult>();
    }
  }
}
