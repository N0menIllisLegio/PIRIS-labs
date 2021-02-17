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

      builder.Entity<Deposit>()
        .HasOne(p => p.MainAccount)
        .WithMany(p => p.MainAccountDeposits)
        .HasForeignKey(p => p.MainAccountID);

      builder.Entity<Deposit>()
        .HasOne(p => p.PercentAccount)
        .WithMany(p => p.PercentAccountDeposits)
        .HasForeignKey(p => p.PercentAccountID);

      builder.Entity<Transaction>()
        .HasOne(p => p.CreditAccount)
        .WithMany(p => p.CreditTransactions)
        .HasForeignKey(p => p.CreditAccountID);

      builder.Entity<Transaction>()
        .HasOne(p => p.DebitAccount)
        .WithMany(p => p.DebitTransactions)
        .HasForeignKey(p => p.DebetAccountID);

      builder.Entity<DepositPlan>()
        .HasOne(p => p.MainAccountPlan)
        .WithMany(p => p.MainAccountPlanOfDeposits)
        .HasForeignKey(p => p.MainAccountPlanID);

      builder.Entity<DepositPlan>()
        .HasOne(p => p.PercentAccountPlan)
        .WithMany(p => p.PercentAccountPlanOfDeposits)
        .HasForeignKey(p => p.PercentAccountPlanID);

      DatabaseSeeder.SeedDatabase(builder);
    }
  }
}
