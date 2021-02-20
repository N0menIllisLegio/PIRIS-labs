using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIRIS_labs.Data.Entities;
using PIRIS_labs.Enums;

namespace PIRIS_labs.Data
{
  public static class DatabaseSeeder
  {
    public static void SeedDatabase(ModelBuilder builder)
    {
      SeedCities(builder.Entity<City>());
      SeedMaritalStatuses(builder.Entity<MaritalStatus>());
      SeedNationalities(builder.Entity<Nationality>());
      SeedDisabilities(builder.Entity<Disability>());
      SeedAccountAndDeposit(builder);
    }

    public static void SeedCities(EntityTypeBuilder<City> cityBuilder)
    {
      cityBuilder.HasData(new City { Name = "Vienna" });
      cityBuilder.HasData(new City { Name = "Zürich" });
      cityBuilder.HasData(new City { Name = "Vancouver" });
      cityBuilder.HasData(new City { Name = "Munich" });
      cityBuilder.HasData(new City { Name = "Auckland" });
      cityBuilder.HasData(new City { Name = "Düsseldorf" });
      cityBuilder.HasData(new City { Name = "Frankfurt" });
      cityBuilder.HasData(new City { Name = "Copenhagen" });
      cityBuilder.HasData(new City { Name = "Geneva" });
      cityBuilder.HasData(new City { Name = "Basel" });
      cityBuilder.HasData(new City { Name = "Sydney" });
    }

    public static void SeedMaritalStatuses(EntityTypeBuilder<MaritalStatus> maritalStatusBuilder)
    {
      maritalStatusBuilder.HasData(new MaritalStatus { Name = "Single" });
      maritalStatusBuilder.HasData(new MaritalStatus { Name = "Married" });
      maritalStatusBuilder.HasData(new MaritalStatus { Name = "Widowed" });
      maritalStatusBuilder.HasData(new MaritalStatus { Name = "Divorced" });
      maritalStatusBuilder.HasData(new MaritalStatus { Name = "Separated" });
      maritalStatusBuilder.HasData(new MaritalStatus { Name = "Registered partnership" });
    }

    public static void SeedNationalities(EntityTypeBuilder<Nationality> nationalityBuilder)
    {
      nationalityBuilder.HasData(new Nationality { Name = "Austrian" });
      nationalityBuilder.HasData(new Nationality { Name = "Belarusian" });
      nationalityBuilder.HasData(new Nationality { Name = "Czech" });
      nationalityBuilder.HasData(new Nationality { Name = "French" });
      nationalityBuilder.HasData(new Nationality { Name = "Georgian" });
      nationalityBuilder.HasData(new Nationality { Name = "German" });
      nationalityBuilder.HasData(new Nationality { Name = "Greek" });
      nationalityBuilder.HasData(new Nationality { Name = "Japanese" });
      nationalityBuilder.HasData(new Nationality { Name = "Liechtenstein citizen" });
      nationalityBuilder.HasData(new Nationality { Name = "Norwegian" });
      nationalityBuilder.HasData(new Nationality { Name = "Polish" });
      nationalityBuilder.HasData(new Nationality { Name = "Scottish" });
      nationalityBuilder.HasData(new Nationality { Name = "Swedish" });
      nationalityBuilder.HasData(new Nationality { Name = "Swiss" });
      nationalityBuilder.HasData(new Nationality { Name = "Turkish" });
      nationalityBuilder.HasData(new Nationality { Name = "Ugandan" });
      nationalityBuilder.HasData(new Nationality { Name = "Vatican citizen" });
      nationalityBuilder.HasData(new Nationality { Name = "Venezuelan" });
      nationalityBuilder.HasData(new Nationality { Name = "Welsh" });
    }

    public static void SeedDisabilities(EntityTypeBuilder<Disability> disabilityBuilder)
    {
      disabilityBuilder.HasData(new Disability { Name = "None" });
      disabilityBuilder.HasData(new Disability { Name = "Grade 1" });
      disabilityBuilder.HasData(new Disability { Name = "Grade 2" });
      disabilityBuilder.HasData(new Disability { Name = "Grade 3" });
    }

    public static void SeedAccountAndDeposit(ModelBuilder builder)
    {
      var accountPlanBuilder = builder.Entity<AccountPlan>();
      var depositPlanBuilder = builder.Entity<DepositPlan>();

      var bankFundaccountPlan = new AccountPlan { Number = "7327", Name = "Bank Development Fund account", Type = AccountType.Passive };
      var bankCashboxAccountPlan = new AccountPlan { Number = "1010", Name = "Bank cashbox account", Type = AccountType.Active };
      accountPlanBuilder.HasData(new AccountPlan { Number = "3014", Name = "Passive account for Individuals", Type = AccountType.Passive });
      accountPlanBuilder.HasData(new AccountPlan { Number = "2400", Name = "Active account for Individuals", Type = AccountType.Active });
      accountPlanBuilder.HasData(bankCashboxAccountPlan);
      accountPlanBuilder.HasData(bankFundaccountPlan);

      var bankOwner = new Client
      {
        ID = Guid.Parse("627DE68A-7C1E-4983-9345-61351783B9E7"),
        Surname = "Tifa",
        Name = "Lockhart",
        Patronymic = "Rokkuhāto",
        Birthday = new DateTime(1987, 5, 3),
        Gender = Gender.Female,
        BirthPlace = "Nibelheim",
        ActualResidenceCityName = "Vienna",
        ActualResidenceAddress = "Praterstrasse 72",
        WorkPlace = "Bank",
        Position = "Chief Financial Officer",
        RegistrationCityName = "Vienna",
        RegistrationAddress = "Praterstrasse 72",
        MaritalStatusName = "Single",
        NationalityName = "Austrian",
        DisabilityName = "None",
        Pensioner = false,
        LiableForMilitaryService = true,
        PassportSeries = "DD",
        PassportNumber = "0926088",
        PassportIssuedBy = "Österreichische Staatsdruckerei",
        PassportIssuedDate = new DateTime(2003, 4, 16),
        IdentificationNumber = "8463627K730PB2"
      };

      int bankOwnersAccountsNumber = 0;
      builder.Entity<Client>().HasData(bankOwner);
      builder.Entity<Account>().HasData(new Account
      {
        AccountPlanNumber = bankFundaccountPlan.Number,
        Number = $"{bankFundaccountPlan.Number}00001{++bankOwnersAccountsNumber:000}7", // 00001 - bankOwner.Number, but its generates in DB
        OwnerID = bankOwner.ID,
        CreditValue = 1_000_000_000,
        Balance = 1_000_000_000
      });

      builder.Entity<Account>().HasData(new Account
      {
        AccountPlanNumber = bankCashboxAccountPlan.Number,
        Number = $"{bankCashboxAccountPlan.Number}00001{++bankOwnersAccountsNumber:000}7", // 00001 - bankOwner.Number, but its generates in DB
        OwnerID = bankOwner.ID
      });

      depositPlanBuilder.HasData(new DepositPlan { ID = Guid.Parse("D8FFAF98-6DCB-4310-A76D-39D0A2B7ED48"), Name = "Standard", DayPeriod = 20, Percent = 0.01m, Revocable = true });
      depositPlanBuilder.HasData(new DepositPlan { ID = Guid.Parse("979F2C2E-F263-43B3-ACA6-800FA0A3668F"), Name = "Standard+", DayPeriod = 40, Percent = 0.05m, Revocable = false });
      depositPlanBuilder.HasData(new DepositPlan { ID = Guid.Parse("464FE5A5-1621-4078-9258-CC6D9BCA5147"), Name = "Medium", DayPeriod = 100, Percent = 0.1m, Revocable = false });
      depositPlanBuilder.HasData(new DepositPlan { ID = Guid.Parse("5125376B-1FB8-4E1D-80EE-DF7A5504CF9B"), Name = "Ultra", DayPeriod = 220, Percent = 0.4m, Revocable = true });
    }
  }
}
