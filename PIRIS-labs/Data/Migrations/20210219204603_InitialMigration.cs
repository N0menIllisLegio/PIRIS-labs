using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PIRIS_labs.Migrations
{
  public partial class InitialMigration: Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "AccountPlans",
          columns: table => new
          {
            Number = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
            Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
            Type = table.Column<int>(type: "int", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_AccountPlans", x => x.Number);
          });

      migrationBuilder.CreateTable(
          name: "Cities",
          columns: table => new
          {
            Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Cities", x => x.Name);
          });

      migrationBuilder.CreateTable(
          name: "DepositPlans",
          columns: table => new
          {
            ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
            Percent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            DayPeriod = table.Column<int>(type: "int", nullable: false),
            Revocable = table.Column<bool>(type: "bit", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_DepositPlans", x => x.ID);
          });

      migrationBuilder.CreateTable(
          name: "Disabilities",
          columns: table => new
          {
            Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Disabilities", x => x.Name);
          });

      migrationBuilder.CreateTable(
          name: "MaritalStatuses",
          columns: table => new
          {
            Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_MaritalStatuses", x => x.Name);
          });

      migrationBuilder.CreateTable(
          name: "Nationalities",
          columns: table => new
          {
            Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Nationalities", x => x.Name);
          });

      migrationBuilder.CreateTable(
          name: "Clients",
          columns: table => new
          {
            ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            Surname = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
            Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
            Patronymic = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
            Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
            Gender = table.Column<int>(type: "int", nullable: false),
            BirthPlace = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
            ActualResidenceCityName = table.Column<string>(type: "nvarchar(250)", nullable: false),
            ActualResidenceAddress = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
            HomePhoneNumber = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
            MobilePhoneNumber = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
            WorkPlace = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
            Position = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
            RegistrationCityName = table.Column<string>(type: "nvarchar(250)", nullable: false),
            Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
            RegistrationAddress = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
            MaritalStatusName = table.Column<string>(type: "nvarchar(250)", nullable: false),
            NationalityName = table.Column<string>(type: "nvarchar(250)", nullable: false),
            DisabilityName = table.Column<string>(type: "nvarchar(250)", nullable: false),
            Pensioner = table.Column<bool>(type: "bit", nullable: false),
            MonthlyIncome = table.Column<int>(type: "int", nullable: true),
            LiableForMilitaryService = table.Column<bool>(type: "bit", nullable: false),
            PassportSeries = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
            PassportNumber = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
            PassportIssuedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
            PassportIssuedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            IdentificationNumber = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Clients", x => x.ID);
            table.ForeignKey(
              name: "FK_Clients_Cities_ActualResidenceCityName",
              column: x => x.ActualResidenceCityName,
              principalTable: "Cities",
              principalColumn: "Name",
              onDelete: ReferentialAction.Restrict);
            table.ForeignKey(
              name: "FK_Clients_Cities_RegistrationCityName",
              column: x => x.RegistrationCityName,
              principalTable: "Cities",
              principalColumn: "Name",
              onDelete: ReferentialAction.Restrict);
            table.ForeignKey(
              name: "FK_Clients_Disabilities_DisabilityName",
              column: x => x.DisabilityName,
              principalTable: "Disabilities",
              principalColumn: "Name",
              onDelete: ReferentialAction.Restrict);
            table.ForeignKey(
              name: "FK_Clients_MaritalStatuses_MaritalStatusName",
              column: x => x.MaritalStatusName,
              principalTable: "MaritalStatuses",
              principalColumn: "Name",
              onDelete: ReferentialAction.Restrict);
            table.ForeignKey(
              name: "FK_Clients_Nationalities_NationalityName",
              column: x => x.NationalityName,
              principalTable: "Nationalities",
              principalColumn: "Name",
              onDelete: ReferentialAction.Restrict);
          });

      migrationBuilder.CreateTable(
          name: "Accounts",
          columns: table => new
          {
            Number = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
            DebitValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            CreditValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            AccountPlanNumber = table.Column<string>(type: "nvarchar(4)", nullable: false),
            OwnerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Accounts", x => x.Number);
            table.ForeignKey(
              name: "FK_Accounts_AccountPlans_AccountPlanNumber",
              column: x => x.AccountPlanNumber,
              principalTable: "AccountPlans",
              principalColumn: "Number",
              onDelete: ReferentialAction.Restrict);
            table.ForeignKey(
              name: "FK_Accounts_Clients_OwnerID",
              column: x => x.OwnerID,
              principalTable: "Clients",
              principalColumn: "ID",
              onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "Deposits",
          columns: table => new
          {
            ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            MainAccountNumber = table.Column<string>(type: "nvarchar(13)", nullable: false),
            PercentAccountNumber = table.Column<string>(type: "nvarchar(13)", nullable: false),
            ClientID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            DepositPlanID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Deposits", x => x.ID);
            table.ForeignKey(
              name: "FK_Deposits_Accounts_MainAccountNumber",
              column: x => x.MainAccountNumber,
              principalTable: "Accounts",
              principalColumn: "Number",
              onDelete: ReferentialAction.Restrict);
            table.ForeignKey(
              name: "FK_Deposits_Accounts_PercentAccountNumber",
              column: x => x.PercentAccountNumber,
              principalTable: "Accounts",
              principalColumn: "Number",
              onDelete: ReferentialAction.Restrict);
            table.ForeignKey(
              name: "FK_Deposits_Clients_ClientID",
              column: x => x.ClientID,
              principalTable: "Clients",
              principalColumn: "ID",
              onDelete: ReferentialAction.Restrict);
            table.ForeignKey(
              name: "FK_Deposits_DepositPlans_DepositPlanID",
              column: x => x.DepositPlanID,
              principalTable: "DepositPlans",
              principalColumn: "ID",
              onDelete: ReferentialAction.Restrict);
          });

      migrationBuilder.CreateTable(
          name: "Transactions",
          columns: table => new
          {
            ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            TransactionDay = table.Column<DateTime>(type: "datetime2", nullable: false),
            TransferToAccountNumber = table.Column<string>(type: "nvarchar(13)", nullable: false),
            TransferFromAccountNumber = table.Column<string>(type: "nvarchar(13)", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Transactions", x => x.ID);
            table.ForeignKey(
              name: "FK_Transactions_Accounts_TransferFromAccountNumber",
              column: x => x.TransferFromAccountNumber,
              principalTable: "Accounts",
              principalColumn: "Number",
              onDelete: ReferentialAction.Restrict);
            table.ForeignKey(
              name: "FK_Transactions_Accounts_TransferToAccountNumber",
              column: x => x.TransferToAccountNumber,
              principalTable: "Accounts",
              principalColumn: "Number",
              onDelete: ReferentialAction.Restrict);
          });

      migrationBuilder.InsertData(
        table: "AccountPlans",
        columns: new[] { "Number", "Name", "Type" },
        values: new object[,]
        {
          { "3014", "Passive account for Individuals", 0 },
          { "2400", "Active account for Individuals", 1 },
          { "1010", "Bank cashbox account", 1 },
          { "7327", "Bank Development Fund account", 0 }
        });

      migrationBuilder.InsertData(
        table: "Cities",
        column: "Name",
        values: new object[]
        {
          "Sydney",
          "Basel",
          "Copenhagen",
          "Frankfurt",
          "Düsseldorf",
          "Geneva",
          "Munich",
          "Vancouver",
          "Zürich",
          "Vienna",
          "Auckland"
        });

      migrationBuilder.InsertData(
        table: "DepositPlans",
        columns: new[] { "ID", "DayPeriod", "Name", "Percent", "Revocable" },
        values: new object[,]
        {
          { new Guid("d8ffaf98-6dcb-4310-a76d-39d0a2b7ed48"), 20, "Standard", 0.01m, true },
          { new Guid("979f2c2e-f263-43b3-aca6-800fa0a3668f"), 40, "Standard+", 0.05m, false },
          { new Guid("464fe5a5-1621-4078-9258-cc6d9bca5147"), 100, "Medium", 0.1m, false },
          { new Guid("5125376b-1fb8-4e1d-80ee-df7a5504cf9b"), 220, "Ultra", 0.4m, true }
        });

      migrationBuilder.InsertData(
        table: "Disabilities",
        column: "Name",
        values: new object[]
        {
          "None",
          "Grade 1",
          "Grade 2",
          "Grade 3"
        });

      migrationBuilder.InsertData(
        table: "MaritalStatuses",
        column: "Name",
        values: new object[]
        {
          "Separated",
          "Registered partnership",
          "Divorced",
          "Single",
          "Married",
          "Widowed"
        });

      migrationBuilder.InsertData(
        table: "Nationalities",
        column: "Name",
        values: new object[]
        {
          "Vatican citizen",
          "Ugandan",
          "Turkish",
          "Swiss",
          "Swedish",
          "Scottish",
          "Polish",
          "Norwegian",
          "Liechtenstein citizen",
          "Greek",
          "German",
          "Georgian",
          "French"
        });

      migrationBuilder.InsertData(
        table: "Nationalities",
        column: "Name",
        values: new object[]
        {
          "Czech",
          "Belarusian",
          "Austrian",
          "Venezuelan",
          "Japanese",
          "Welsh"
        });

      migrationBuilder.InsertData(
        table: "Clients",
        columns: new[] { "ID", "ActualResidenceAddress", "ActualResidenceCityName", "BirthPlace", "Birthday", "DisabilityName", "Email", "Gender", "HomePhoneNumber", "IdentificationNumber", "LiableForMilitaryService", "MaritalStatusName", "MobilePhoneNumber", "MonthlyIncome", "Name", "NationalityName", "PassportIssuedBy", "PassportIssuedDate", "PassportNumber", "PassportSeries", "Patronymic", "Pensioner", "Position", "RegistrationAddress", "RegistrationCityName", "Surname", "WorkPlace" },
        values: new object[] { new Guid("627de68a-7c1e-4983-9345-61351783b9e7"), "Praterstrasse 72", "Vienna", "Nibelheim", new DateTime(1987, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "None", null, 1, null, "8463627K730PB2", true, "Single", null, null, "Lockhart", "Austrian", "Österreichische Staatsdruckerei", new DateTime(2003, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "0926088", "DD", "Rokkuhāto", false, "Chief Financial Officer", "Praterstrasse 72", "Vienna", "Tifa", "Bank" });

      migrationBuilder.InsertData(
        table: "Accounts",
        columns: new[] { "Number", "AccountPlanNumber", "Balance", "CreditValue", "DebitValue", "OwnerID" },
        values: new object[] { "1", "7327", 0m, 0m, 0m, new Guid("627de68a-7c1e-4983-9345-61351783b9e7") });

      migrationBuilder.CreateIndex(
        name: "IX_Accounts_AccountPlanNumber",
        table: "Accounts",
        column: "AccountPlanNumber");

      migrationBuilder.CreateIndex(
        name: "IX_Accounts_OwnerID",
        table: "Accounts",
        column: "OwnerID");

      migrationBuilder.CreateIndex(
        name: "IX_Clients_ActualResidenceCityName",
        table: "Clients",
        column: "ActualResidenceCityName");

      migrationBuilder.CreateIndex(
        name: "IX_Clients_DisabilityName",
        table: "Clients",
        column: "DisabilityName");

      migrationBuilder.CreateIndex(
        name: "IX_Clients_IdentificationNumber",
        table: "Clients",
        column: "IdentificationNumber",
        unique: true);

      migrationBuilder.CreateIndex(
        name: "IX_Clients_MaritalStatusName",
        table: "Clients",
        column: "MaritalStatusName");

      migrationBuilder.CreateIndex(
        name: "IX_Clients_NationalityName",
        table: "Clients",
        column: "NationalityName");

      migrationBuilder.CreateIndex(
        name: "IX_Clients_PassportSeries_PassportNumber",
        table: "Clients",
        columns: new[] { "PassportSeries", "PassportNumber" },
        unique: true);

      migrationBuilder.CreateIndex(
        name: "IX_Clients_RegistrationCityName",
        table: "Clients",
        column: "RegistrationCityName");

      migrationBuilder.CreateIndex(
        name: "IX_Deposits_ClientID",
        table: "Deposits",
        column: "ClientID");

      migrationBuilder.CreateIndex(
        name: "IX_Deposits_DepositPlanID",
        table: "Deposits",
        column: "DepositPlanID");

      migrationBuilder.CreateIndex(
        name: "IX_Deposits_MainAccountNumber",
        table: "Deposits",
        column: "MainAccountNumber");

      migrationBuilder.CreateIndex(
        name: "IX_Deposits_PercentAccountNumber",
        table: "Deposits",
        column: "PercentAccountNumber");

      migrationBuilder.CreateIndex(
        name: "IX_Transactions_TransferFromAccountNumber",
        table: "Transactions",
        column: "TransferFromAccountNumber");

      migrationBuilder.CreateIndex(
        name: "IX_Transactions_TransferToAccountNumber",
        table: "Transactions",
        column: "TransferToAccountNumber");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
        name: "Deposits");

      migrationBuilder.DropTable(
        name: "Transactions");

      migrationBuilder.DropTable(
        name: "DepositPlans");

      migrationBuilder.DropTable(
        name: "Accounts");

      migrationBuilder.DropTable(
        name: "AccountPlans");

      migrationBuilder.DropTable(
        name: "Clients");

      migrationBuilder.DropTable(
        name: "Cities");

      migrationBuilder.DropTable(
        name: "Disabilities");

      migrationBuilder.DropTable(
        name: "MaritalStatuses");

      migrationBuilder.DropTable(
        name: "Nationalities");
    }
  }
}