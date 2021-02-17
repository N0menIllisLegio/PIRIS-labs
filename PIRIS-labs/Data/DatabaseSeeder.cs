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
      SeedAccountAndDepositPlans(builder.Entity<AccountPlan>(), builder.Entity<DepositPlan>());
    }

    public static void SeedCities(EntityTypeBuilder<City> cityBuilder)
    {
      cityBuilder.HasData(new City { Name = "Yerpolis" });
      cityBuilder.HasData(new City { Name = "Purgh" });
      cityBuilder.HasData(new City { Name = "Jine" });
      cityBuilder.HasData(new City { Name = "Fleim" });
      cityBuilder.HasData(new City { Name = "Besding" });
      cityBuilder.HasData(new City { Name = "Keedlas" });
      cityBuilder.HasData(new City { Name = "Dorough" });
      cityBuilder.HasData(new City { Name = "Stranta" });
      cityBuilder.HasData(new City { Name = "Jeka" });
      cityBuilder.HasData(new City { Name = "Qesa" });
      cityBuilder.HasData(new City { Name = "Olislas" });
      cityBuilder.HasData(new City { Name = "Icofield" });
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
      disabilityBuilder.HasData(new Disability { Name = "Musculoskeletal System" });
      disabilityBuilder.HasData(new Disability { Name = "Special Senses and Speech" });
      disabilityBuilder.HasData(new Disability { Name = "Respiratory Disorders" });
      disabilityBuilder.HasData(new Disability { Name = "Cardiovascular System" });
      disabilityBuilder.HasData(new Disability { Name = "Digestive System" });
      disabilityBuilder.HasData(new Disability { Name = "Genitourinary Disorders" });
      disabilityBuilder.HasData(new Disability { Name = "Hematological Disorders" });
      disabilityBuilder.HasData(new Disability { Name = "Skin Disorders" });
      disabilityBuilder.HasData(new Disability { Name = "Endocrine Disorders" });
      disabilityBuilder.HasData(new Disability { Name = "Congenital Disorders that Affect Multiple Body Systems" });
      disabilityBuilder.HasData(new Disability { Name = "Neurological Disorders" });
      disabilityBuilder.HasData(new Disability { Name = "Mental Disorders" });
      disabilityBuilder.HasData(new Disability { Name = "Cancer (Malignant Neoplastic Diseases)" });
      disabilityBuilder.HasData(new Disability { Name = "Immune System Disorders" });
    }

    public static void SeedAccountAndDepositPlans(EntityTypeBuilder<AccountPlan> accountPlanBuilder, EntityTypeBuilder<DepositPlan> depositPlanBuilder)
    {
      var accountPlan = new AccountPlan { ID = Guid.NewGuid(), AccountName = "Passive account for Individuals", AccountNumber = "3014", AccountType = AccountType.Passive };
      accountPlanBuilder.HasData(accountPlan);
      accountPlanBuilder.HasData(new AccountPlan { ID = Guid.NewGuid(), AccountName = "Active account for Entities", AccountNumber = "2400", AccountType = AccountType.Active });
      accountPlanBuilder.HasData(new AccountPlan { ID = Guid.NewGuid(), AccountName = "Bank cash desk account", AccountNumber = "1010", AccountType = AccountType.Active });
      accountPlanBuilder.HasData(new AccountPlan { ID = Guid.NewGuid(), AccountName = "Bank Development Fund account", AccountNumber = "7327", AccountType = AccountType.Passive });

      depositPlanBuilder.HasData(new DepositPlan { ID = Guid.NewGuid(), Name = "Standard", DayPeriod = 20, Percent = 0.01m, Revocable = true, MainAccountPlanID = accountPlan.ID, PercentAccountPlanID = accountPlan.ID });
      depositPlanBuilder.HasData(new DepositPlan { ID = Guid.NewGuid(), Name = "Standard+", DayPeriod = 40, Percent = 0.05m, Revocable = false, MainAccountPlanID = accountPlan.ID, PercentAccountPlanID = accountPlan.ID });
      depositPlanBuilder.HasData(new DepositPlan { ID = Guid.NewGuid(), Name = "Medium", DayPeriod = 100, Percent = 0.1m, Revocable = false, MainAccountPlanID = accountPlan.ID, PercentAccountPlanID = accountPlan.ID });
      depositPlanBuilder.HasData(new DepositPlan { ID = Guid.NewGuid(), Name = "Ultra", DayPeriod = 220, Percent = 0.4m, Revocable = true, MainAccountPlanID = accountPlan.ID, PercentAccountPlanID = accountPlan.ID });
    }
  }
}
