using PIRIS_labs.Data.Entities;

namespace PIRIS_labs.Data.Repositories
{
  public class NationalitiesRepository : RepositoryBase<Nationality>
  {
    public NationalitiesRepository(ApplicationDbContext applicationDbContext)
      : base(applicationDbContext)
    { }
  }
}
