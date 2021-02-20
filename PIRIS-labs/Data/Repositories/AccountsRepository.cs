using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PIRIS_labs.Data.Entities;
using PIRIS_labs.DTOs.Common;

namespace PIRIS_labs.Data.Repositories
{
  public class AccountsRepository: RepositoryBase<Account>
  {
    public AccountsRepository(ApplicationDbContext applicationDbContext)
        : base(applicationDbContext)
    { }

    public async Task<List<AccountTypeDto>> GetAccountsWithTypes()
    {
      var query = DbSet.Join(ApplicationDbContext.AccountPlans,
        account => account.AccountPlanNumber,
        accountPlan => accountPlan.Number,
        (account, accountPlan) => new AccountTypeDto { Account = account, AccountType = accountPlan.Type });

      return await query.ToListAsync();
    }

    public int GetClientsLastAccountNumber(Guid clientID)
    {
      return DbSet.Where(account => account.OwnerID == clientID)
        .Max(account => account.ClientsAccountNumber).GetValueOrDefault();
    }

    public async Task<Account> GetBankDevelopmentFundAccount()
    {
      return await DbSet.FindAsync("7327000010017");
    }

    public async Task<Account> GetBankCashboxAccount()
    {
      return await DbSet.FindAsync("1010000010027");
    }
  }
}
