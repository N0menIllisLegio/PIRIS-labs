using PIRIS_labs.Data.Entities;

namespace PIRIS_labs.Data.Repositories
{
  public class DisabilitiesRepository : RepositoryBase<Disability>
  {
    public DisabilitiesRepository(ApplicationDbContext applicationDbContext)
      : base(applicationDbContext)
    { }
  }
}
