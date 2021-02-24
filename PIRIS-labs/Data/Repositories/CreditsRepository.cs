using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using PIRIS_labs.Data.Entities;
using PIRIS_labs.DTOs.Credit;

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

    public async Task<List<CreditPercentAccountDto>> GetOpenCreditPercentAccounts()
    {
      var query = DbSet.Join(ApplicationDbContext.Accounts,
        credit => credit.PercentAccountNumber,
        account => account.Number,
        (credit, account) => new { credit, account })
        .Where(result => !result.credit.Closed)
        .Join(ApplicationDbContext.CreditPlans, firstJoinResult => firstJoinResult.credit.CreditPlanID, creditPlan => creditPlan.ID,
        (firstJoinResult, creditPlan) => new CreditPercentAccountDto
        {
          PercentAccount = firstJoinResult.account,
          Credit = firstJoinResult.credit,
          CreditPercent = creditPlan.Percent,
          Anuity = creditPlan.Anuity,
          Months = creditPlan.MonthPeriod,
        });

      return await query.ToListAsync();
    }
  }
}
