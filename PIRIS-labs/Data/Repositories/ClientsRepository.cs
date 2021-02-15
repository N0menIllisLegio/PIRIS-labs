using PIRIS_labs.Data.Entities;

namespace PIRIS_labs.Data.Repositories
{
  public class ClientsRepository : RepositoryBase<Client>
  {
    public ClientsRepository(ApplicationDbContext applicationDbContext)
      : base(applicationDbContext)
    { }
  }
}
