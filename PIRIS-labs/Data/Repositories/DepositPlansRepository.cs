using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using PIRIS_labs.Data.Entities;

namespace PIRIS_labs.Data.Repositories
{
  public class DepositPlansRepository: RepositoryBase<DepositPlan>
  {
    public DepositPlansRepository(ApplicationDbContext applicationDbContext)
      : base(applicationDbContext)
    { }

    public async Task<List<DepositPlan>> GetDepositPlansOrderedAsync(Func<IQueryable<DepositPlan>,
      IIncludableQueryable<DepositPlan, object>> include = null, bool disableTracking = true)
    {
      IQueryable<DepositPlan> query = DbSet;

      if (disableTracking)
      {
        query = query.AsNoTracking();
      }

      if (include is not null)
      {
        query = include(query);
      }

      return await query.OrderBy(plan => plan.Percent).ThenBy(plan => plan.DayPeriod).ToListAsync();
    }
  }
}