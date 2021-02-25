using PIRIS_labs.Data.Entities;

namespace PIRIS_labs.Data.Repositories
{
  public class CreditCardsRepository: RepositoryBase<CreditCard>
  {
    public CreditCardsRepository(ApplicationDbContext applicationDbContext)
      : base(applicationDbContext)
    { }
  }
}
