using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PIRIS_labs.Data.Entities;

namespace PIRIS_labs.Data
{
  public class ApplicationDbContext: IdentityDbContext<User, IdentityRole<Guid>, Guid>
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Disability> Disabilities { get; set; }
    public DbSet<Nationality> Nationalities { get; set; }
    public DbSet<MaritalStatus> MaritalStatuses { get; set; }
    public DbSet<City> Cities { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      builder.Entity<User>()
        .Ignore(p => p.LockoutEnd)
        .Ignore(p => p.TwoFactorEnabled)
        .Ignore(p => p.PhoneNumberConfirmed)
        .Ignore(p => p.PhoneNumber)
        .Ignore(p => p.ConcurrencyStamp)
        .Ignore(p => p.SecurityStamp)
        .Ignore(p => p.NormalizedUserName)
        .Ignore(p => p.UserName)
        .Ignore(p => p.LockoutEnabled)
        .Ignore(p => p.NormalizedEmail)
        .Ignore(p => p.AccessFailedCount);

      DatabaseSeeder.SeedDatabase(builder);
    }
  }
}
