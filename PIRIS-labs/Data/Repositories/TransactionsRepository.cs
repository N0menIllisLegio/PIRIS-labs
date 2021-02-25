using PIRIS_labs.Data.Entities;

namespace PIRIS_labs.Data.Repositories
{
  public class TransactionsRepository: RepositoryBase<Transaction>
  {
    public TransactionsRepository(ApplicationDbContext applicationDbContext)
        : base(applicationDbContext)
    { }
  }
}
