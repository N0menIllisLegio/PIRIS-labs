﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PIRIS_labs.Data;

namespace PIRIS_labs.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210219224443_AddClientNumberMigration")]
    partial class AddClientNumberMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("PIRIS_labs.Data.Entities.Account", b =>
                {
                    b.Property<string>("Number")
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("AccountPlanNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(4)");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("CreditValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("DebitValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("OwnerID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Number");

                    b.HasIndex("AccountPlanNumber");

                    b.HasIndex("OwnerID");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Number = "7327000010017",
                            AccountPlanNumber = "7327",
                            Balance = 1000000000m,
                            CreditValue = 1000000000m,
                            DebitValue = 0m,
                            OwnerID = new Guid("627de68a-7c1e-4983-9345-61351783b9e7")
                        });
                });

            modelBuilder.Entity("PIRIS_labs.Data.Entities.AccountPlan", b =>
                {
                    b.Property<string>("Number")
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Number");

                    b.ToTable("AccountPlans");

                    b.HasData(
                        new
                        {
                            Number = "3014",
                            Name = "Passive account for Individuals",
                            Type = 0
                        },
                        new
                        {
                            Number = "2400",
                            Name = "Active account for Individuals",
                            Type = 1
                        },
                        new
                        {
                            Number = "1010",
                            Name = "Bank cashbox account",
                            Type = 1
                        },
                        new
                        {
                            Number = "7327",
                            Name = "Bank Development Fund account",
                            Type = 0
                        });
                });

            modelBuilder.Entity("PIRIS_labs.Data.Entities.City", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Name");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Name = "Vienna"
                        },
                        new
                        {
                            Name = "Zürich"
                        },
                        new
                        {
                            Name = "Vancouver"
                        },
                        new
                        {
                            Name = "Munich"
                        },
                        new
                        {
                            Name = "Auckland"
                        },
                        new
                        {
                            Name = "Düsseldorf"
                        },
                        new
                        {
                            Name = "Frankfurt"
                        },
                        new
                        {
                            Name = "Copenhagen"
                        },
                        new
                        {
                            Name = "Geneva"
                        },
                        new
                        {
                            Name = "Basel"
                        },
                        new
                        {
                            Name = "Sydney"
                        });
                });

            modelBuilder.Entity("PIRIS_labs.Data.Entities.Client", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ActualResidenceAddress")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("ActualResidenceCityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("BirthPlace")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("DisabilityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Email")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("HomePhoneNumber")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("IdentificationNumber")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("LiableForMilitaryService")
                        .HasColumnType("bit");

                    b.Property<string>("MaritalStatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("MobilePhoneNumber")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("MonthlyIncome")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("NationalityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("PassportIssuedBy")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("PassportIssuedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PassportNumber")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("PassportSeries")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("Pensioner")
                        .HasColumnType("bit");

                    b.Property<string>("Position")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("RegistrationAddress")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("RegistrationCityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("WorkPlace")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("ID");

                    b.HasIndex("ActualResidenceCityName");

                    b.HasIndex("DisabilityName");

                    b.HasIndex("MaritalStatusName");

                    b.HasIndex("NationalityName");

                    b.HasIndex("RegistrationCityName");

                    b.HasIndex(new[] { "IdentificationNumber" }, "IX_Clients_IdentificationNumber")
                        .IsUnique();

                    b.HasIndex(new[] { "PassportSeries", "PassportNumber" }, "IX_Clients_PassportSeries_PassportNumber")
                        .IsUnique();

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            ID = new Guid("627de68a-7c1e-4983-9345-61351783b9e7"),
                            ActualResidenceAddress = "Praterstrasse 72",
                            ActualResidenceCityName = "Vienna",
                            BirthPlace = "Nibelheim",
                            Birthday = new DateTime(1987, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DisabilityName = "None",
                            Gender = 1,
                            IdentificationNumber = "8463627K730PB2",
                            LiableForMilitaryService = true,
                            MaritalStatusName = "Single",
                            Name = "Lockhart",
                            NationalityName = "Austrian",
                            Number = 0,
                            PassportIssuedBy = "Österreichische Staatsdruckerei",
                            PassportIssuedDate = new DateTime(2003, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PassportNumber = "0926088",
                            PassportSeries = "DD",
                            Patronymic = "Rokkuhāto",
                            Pensioner = false,
                            Position = "Chief Financial Officer",
                            RegistrationAddress = "Praterstrasse 72",
                            RegistrationCityName = "Vienna",
                            Surname = "Tifa",
                            WorkPlace = "Bank"
                        });
                });

            modelBuilder.Entity("PIRIS_labs.Data.Entities.Deposit", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("ClientID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DepositPlanID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MainAccountNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("PercentAccountNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(13)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.HasIndex("DepositPlanID");

                    b.HasIndex("MainAccountNumber");

                    b.HasIndex("PercentAccountNumber");

                    b.ToTable("Deposits");
                });

            modelBuilder.Entity("PIRIS_labs.Data.Entities.DepositPlan", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DayPeriod")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<decimal>("Percent")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Revocable")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("DepositPlans");

                    b.HasData(
                        new
                        {
                            ID = new Guid("d8ffaf98-6dcb-4310-a76d-39d0a2b7ed48"),
                            DayPeriod = 20,
                            Name = "Standard",
                            Percent = 0.01m,
                            Revocable = true
                        },
                        new
                        {
                            ID = new Guid("979f2c2e-f263-43b3-aca6-800fa0a3668f"),
                            DayPeriod = 40,
                            Name = "Standard+",
                            Percent = 0.05m,
                            Revocable = false
                        },
                        new
                        {
                            ID = new Guid("464fe5a5-1621-4078-9258-cc6d9bca5147"),
                            DayPeriod = 100,
                            Name = "Medium",
                            Percent = 0.1m,
                            Revocable = false
                        },
                        new
                        {
                            ID = new Guid("5125376b-1fb8-4e1d-80ee-df7a5504cf9b"),
                            DayPeriod = 220,
                            Name = "Ultra",
                            Percent = 0.4m,
                            Revocable = true
                        });
                });

            modelBuilder.Entity("PIRIS_labs.Data.Entities.Disability", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Name");

                    b.ToTable("Disabilities");

                    b.HasData(
                        new
                        {
                            Name = "None"
                        },
                        new
                        {
                            Name = "Grade 1"
                        },
                        new
                        {
                            Name = "Grade 2"
                        },
                        new
                        {
                            Name = "Grade 3"
                        });
                });

            modelBuilder.Entity("PIRIS_labs.Data.Entities.MaritalStatus", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Name");

                    b.ToTable("MaritalStatuses");

                    b.HasData(
                        new
                        {
                            Name = "Single"
                        },
                        new
                        {
                            Name = "Married"
                        },
                        new
                        {
                            Name = "Widowed"
                        },
                        new
                        {
                            Name = "Divorced"
                        },
                        new
                        {
                            Name = "Separated"
                        },
                        new
                        {
                            Name = "Registered partnership"
                        });
                });

            modelBuilder.Entity("PIRIS_labs.Data.Entities.Nationality", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Name");

                    b.ToTable("Nationalities");

                    b.HasData(
                        new
                        {
                            Name = "Austrian"
                        },
                        new
                        {
                            Name = "Belarusian"
                        },
                        new
                        {
                            Name = "Czech"
                        },
                        new
                        {
                            Name = "French"
                        },
                        new
                        {
                            Name = "Georgian"
                        },
                        new
                        {
                            Name = "German"
                        },
                        new
                        {
                            Name = "Greek"
                        },
                        new
                        {
                            Name = "Japanese"
                        },
                        new
                        {
                            Name = "Liechtenstein citizen"
                        },
                        new
                        {
                            Name = "Norwegian"
                        },
                        new
                        {
                            Name = "Polish"
                        },
                        new
                        {
                            Name = "Scottish"
                        },
                        new
                        {
                            Name = "Swedish"
                        },
                        new
                        {
                            Name = "Swiss"
                        },
                        new
                        {
                            Name = "Turkish"
                        },
                        new
                        {
                            Name = "Ugandan"
                        },
                        new
                        {
                            Name = "Vatican citizen"
                        },
                        new
                        {
                            Name = "Venezuelan"
                        },
                        new
                        {
                            Name = "Welsh"
                        });
                });

            modelBuilder.Entity("PIRIS_labs.Data.Entities.Transaction", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("TransactionDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("TransferFromAccountNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("TransferToAccountNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(13)");

                    b.HasKey("ID");

                    b.HasIndex("TransferFromAccountNumber");

                    b.HasIndex("TransferToAccountNumber");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("PIRIS_labs.Data.Entities.Account", b =>
                {
                    b.HasOne("PIRIS_labs.Data.Entities.AccountPlan", "AccountPlan")
                        .WithMany()
                        .HasForeignKey("AccountPlanNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PIRIS_labs.Data.Entities.Client", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccountPlan");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("PIRIS_labs.Data.Entities.Client", b =>
                {
                    b.HasOne("PIRIS_labs.Data.Entities.City", "ActualResidenceCity")
                        .WithMany()
                        .HasForeignKey("ActualResidenceCityName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PIRIS_labs.Data.Entities.Disability", "Disability")
                        .WithMany()
                        .HasForeignKey("DisabilityName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PIRIS_labs.Data.Entities.MaritalStatus", "MaritalStatus")
                        .WithMany()
                        .HasForeignKey("MaritalStatusName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PIRIS_labs.Data.Entities.Nationality", "Nationality")
                        .WithMany()
                        .HasForeignKey("NationalityName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PIRIS_labs.Data.Entities.City", "RegistrationCity")
                        .WithMany()
                        .HasForeignKey("RegistrationCityName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ActualResidenceCity");

                    b.Navigation("Disability");

                    b.Navigation("MaritalStatus");

                    b.Navigation("Nationality");

                    b.Navigation("RegistrationCity");
                });

            modelBuilder.Entity("PIRIS_labs.Data.Entities.Deposit", b =>
                {
                    b.HasOne("PIRIS_labs.Data.Entities.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PIRIS_labs.Data.Entities.DepositPlan", "DepositPlan")
                        .WithMany()
                        .HasForeignKey("DepositPlanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PIRIS_labs.Data.Entities.Account", "MainAccount")
                        .WithMany()
                        .HasForeignKey("MainAccountNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PIRIS_labs.Data.Entities.Account", "PercentAccount")
                        .WithMany()
                        .HasForeignKey("PercentAccountNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("DepositPlan");

                    b.Navigation("MainAccount");

                    b.Navigation("PercentAccount");
                });

            modelBuilder.Entity("PIRIS_labs.Data.Entities.Transaction", b =>
                {
                    b.HasOne("PIRIS_labs.Data.Entities.Account", "TransferFromAccount")
                        .WithMany()
                        .HasForeignKey("TransferFromAccountNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PIRIS_labs.Data.Entities.Account", "TransferToAccount")
                        .WithMany()
                        .HasForeignKey("TransferToAccountNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TransferFromAccount");

                    b.Navigation("TransferToAccount");
                });
#pragma warning restore 612, 618
        }
    }
}
