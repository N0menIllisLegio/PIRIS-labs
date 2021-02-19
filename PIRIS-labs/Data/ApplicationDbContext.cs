using Microsoft.EntityFrameworkCore;
using PIRIS_labs.Data.Entities;

namespace PIRIS_labs.Data
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Disability> Disabilities { get; set; }
    public DbSet<Nationality> Nationalities { get; set; }
    public DbSet<MaritalStatus> MaritalStatuses { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Client> Clients { get; set; }

    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Deposit> Deposits { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountPlan> AccountPlans { get; set; }
    public DbSet<DepositPlan> DepositPlans { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
      DatabaseSeeder.SeedDatabase(builder);
    }
  }
}
