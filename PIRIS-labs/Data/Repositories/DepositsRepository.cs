using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using PIRIS_labs.Data.Entities;

namespace PIRIS_labs.Data.Repositories
{
  public class DepositsRepository: RepositoryBase<Deposit>
  {
    public DepositsRepository(ApplicationDbContext applicationDbContext)
      : base(applicationDbContext)
    { }

    public async Task<List<Deposit>> GetOrderedDepositsAsync(Func<IQueryable<Deposit>,
      IIncludableQueryable<Deposit, object>> include = null, bool disableTracking = true)
    {
      IQueryable<Deposit> query = DbSet;

      if (disableTracking)
      {
        query = query.AsNoTracking();
      }

      if (include is not null)
      {
        query = include(query);
      }

      return await query.OrderBy(deposit => deposit.Closed).ToListAsync();
    }
  }
}
