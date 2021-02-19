using PIRIS_labs.Data.Entities;

namespace PIRIS_labs.Data.Repositories
{
  public class AccountPlansRepository: RepositoryBase<AccountPlan>
  {
    public AccountPlansRepository(ApplicationDbContext applicationDbContext)
        : base(applicationDbContext)
    { }
  }
}