using System;
using System.Linq;
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
  }
}
