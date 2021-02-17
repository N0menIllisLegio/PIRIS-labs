using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using PIRIS_labs.Data.Entities;

namespace PIRIS_labs.Data.Repositories
{
  public class ClientsRepository : RepositoryBase<Client>
  {
    public ClientsRepository(ApplicationDbContext applicationDbContext)
      : base(applicationDbContext)
    { }

    public async Task<List<Client>> GetClientSurnameOrderedAsync(Func<IQueryable<Client>,
      IIncludableQueryable<Client, object>> include = null, bool disableTracking = true)
    {
      IQueryable<Client> query = DbSet;

      if (disableTracking)
      {
        query = query.OrderBy(client => client.Surname).AsNoTracking();
      }

      if (include is not null)
      {
        query = include(query);
      }

      return await query.ToListAsync();
    }
  }
}
