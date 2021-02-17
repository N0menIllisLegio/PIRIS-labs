using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIRIS_labs.Data.Entities;

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
  }
}
