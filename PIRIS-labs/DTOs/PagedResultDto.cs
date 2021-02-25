using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace PIRIS_labs.DTOs
{
  public class PagedResultDto<T>
  {
    public PagedInfoDto PagedInfo { get; set; }

    public IEnumerable<T> Items { get; set; }

    public int TotalItemsCount { get; set; }

    public PagedResultDto<TDestination> Convert<TDestination>(IMapper mapper)
    {
      return new PagedResultDto<TDestination>
      {
        PagedInfo = PagedInfo,
        TotalItemsCount = TotalItemsCount,
        Items = Items.Select(item => mapper.Map<TDestination>(item))
      };
    }
  }
}
