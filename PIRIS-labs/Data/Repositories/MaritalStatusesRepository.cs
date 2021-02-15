using PIRIS_labs.Data.Entities;

namespace PIRIS_labs.Data.Repositories
{
  public class MaritalStatusesRepository : RepositoryBase<MaritalStatus>
  {
    public MaritalStatusesRepository(ApplicationDbContext applicationDbContext)
      : base(applicationDbContext)
    { }
  }
}
