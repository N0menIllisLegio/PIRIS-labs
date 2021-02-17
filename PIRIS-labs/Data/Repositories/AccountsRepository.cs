using PIRIS_labs.Data.Entities;

namespace PIRIS_labs.Data.Repositories
{
  public class AccountsRepository: RepositoryBase<Account>
  {
    public AccountsRepository(ApplicationDbContext applicationDbContext)
        : base(applicationDbContext)
    { }
  }
}
