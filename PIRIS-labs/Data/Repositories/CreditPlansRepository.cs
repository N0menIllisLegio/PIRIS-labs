using PIRIS_labs.Data.Entities;

namespace PIRIS_labs.Data.Repositories
{
  public class CreditPlansRepository: RepositoryBase<CreditPlan>
  {
    public CreditPlansRepository(ApplicationDbContext applicationDbContext)
      : base(applicationDbContext)
    { }
  }
}
