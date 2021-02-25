using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using PIRIS_labs.Data.Entities;

namespace PIRIS_labs.Data.Repositories
{
  public class CreditPlansRepository: RepositoryBase<CreditPlan>
  {
    public CreditPlansRepository(ApplicationDbContext applicationDbContext)
      : base(applicationDbContext)
    { }

    public async Task<List<CreditPlan>> GetCreditPlansOrderedAsync(Func<IQueryable<CreditPlan>,
      IIncludableQueryable<CreditPlan, object>> include = null, bool disableTracking = true)
    {
      IQueryable<CreditPlan> query = DbSet;

      if (disableTracking)
      {
        query = query.AsNoTracking();
      }

      if (include is not null)
      {
        query = include(query);
      }

      return await query.OrderBy(plan => plan.Percent).ThenBy(plan => plan.MonthPeriod).ToListAsync();
    }
  }
}
