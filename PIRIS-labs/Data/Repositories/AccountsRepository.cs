using System;
using System.Linq;
using System.Threading.Tasks;
using PIRIS_labs.Data.Entities;

namespace PIRIS_labs.Data.Repositories
{
  public class AccountsRepository: RepositoryBase<Account>
  {
    public AccountsRepository(ApplicationDbContext applicationDbContext)
        : base(applicationDbContext)
    { }

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
