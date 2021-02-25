using PIRIS_labs.Data.Entities;

namespace PIRIS_labs.Data.Repositories
{
  public class CitiesRepository : RepositoryBase<City>
  {
    public CitiesRepository(ApplicationDbContext applicationDbContext)
      : base(applicationDbContext)
    { }
  }
}
