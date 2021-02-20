using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using PIRIS_labs.Data.Entities;
using PIRIS_labs.DTOs.Deposit;

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

    public async Task<List<DepositPercentAccountDto>> GetOpenDepositPercentAccounts()
    {
      var query = DbSet.Join(ApplicationDbContext.Accounts,
        deposit => deposit.PercentAccountNumber,
        account => account.Number,
        (deposit, account) => new { deposit, account })
        .Where(result => !result.deposit.Closed)
        .Join(ApplicationDbContext.DepositPlans, firstJoinResult => firstJoinResult.deposit.DepositPlanID, depositPlan => depositPlan.ID,
        (firstJoinResult, depositPlan) => new DepositPercentAccountDto
        {
          Account = firstJoinResult.account,
          DepositAmount = firstJoinResult.deposit.Amount,
          Percent = depositPlan.Percent
        });

      return await query.ToListAsync();
    }
  }
}
