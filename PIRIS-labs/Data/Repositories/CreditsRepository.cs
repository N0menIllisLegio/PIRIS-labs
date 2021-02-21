using PIRIS_labs.Data.Entities;

namespace PIRIS_labs.Data.Repositories
{
  public class CreditsRepository: RepositoryBase<Credit>
  {
    public CreditsRepository(ApplicationDbContext applicationDbContext)
      : base(applicationDbContext)
    { }
  }
}
