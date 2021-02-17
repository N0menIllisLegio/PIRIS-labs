using PIRIS_labs.Data.Entities;

namespace PIRIS_labs.Data.Repositories
{
  public class DepositPlansRepository: RepositoryBase<DepositPlan>
  {
    public DepositPlansRepository(ApplicationDbContext applicationDbContext)
      : base(applicationDbContext)
    { }
  }
}
