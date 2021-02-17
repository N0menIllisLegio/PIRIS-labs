using PIRIS_labs.Data.Entities;

namespace PIRIS_labs.Data.Repositories
{
  public class DepositsRepository: RepositoryBase<Deposit>
  {
    public DepositsRepository(ApplicationDbContext applicationDbContext)
      : base(applicationDbContext)
    { }
  }
}
