using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using PIRIS_labs.Data.Entities;

namespace PIRIS_labs.Data.Repositories
{
  public class CreditsRepository: RepositoryBase<Credit>
  {
    public CreditsRepository(ApplicationDbContext applicationDbContext)
      : base(applicationDbContext)
    { }

    public async Task<List<Credit>> GetOrderedCreditsAsync(Func<IQueryable<Credit>,
      IIncludableQueryable<Credit, object>> include = null, bool disableTracking = true)
    {
      IQueryable<Credit> query = DbSet;

      if (disableTracking)
      {
        query = query.AsNoTracking();
      }

      if (include is not null)
      {
        query = include(query);
      }

      return await query.OrderBy(credit => credit.Closed).ToListAsync();
    }
  }
}
