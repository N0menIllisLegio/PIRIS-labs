using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PIRIS_labs.Migrations
{
  public partial class AddCreditMigration: Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
        name: "CreditPlans",
        columns: table => new
        {
          ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
          MonthPeriod = table.Column<int>(type: "int", nullable: false),
          Percent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
          MinAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
          Anuity = table.Column<bool>(type: "bit", nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_CreditPlans", x => x.ID);
        });

      migrationBuilder.CreateTable(
        name: "Currency",
        columns: table => new
        {
          Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
          Symbol = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
          Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Currency", x => x.Code);
        });

      migrationBuilder.CreateTable(
        name: "Credits",
        columns: table => new
        {
          ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
          EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
          Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
          MainAccountNumber = table.Column<string>(type: "nvarchar(13)", nullable: false),
          PercentAccountNumber = table.Column<string>(type: "nvarchar(13)", nullable: false),
          ClientID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          CreditPlanID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Credits", x => x.ID);
          table.ForeignKey(
            name: "FK_Credits_Accounts_MainAccountNumber",
            column: x => x.MainAccountNumber,
            principalTable: "Accounts",
            principalColumn: "Number",
            onDelete: ReferentialAction.Restrict);
          table.ForeignKey(
            name: "FK_Credits_Accounts_PercentAccountNumber",
            column: x => x.PercentAccountNumber,
            principalTable: "Accounts",
            principalColumn: "Number",
            onDelete: ReferentialAction.Restrict);
          table.ForeignKey(
            name: "FK_Credits_Clients_ClientID",
            column: x => x.ClientID,
            principalTable: "Clients",
            principalColumn: "ID",
            onDelete: ReferentialAction.Cascade);
          table.ForeignKey(
            name: "FK_Credits_CreditPlans_CreditPlanID",
            column: x => x.CreditPlanID,
            principalTable: "CreditPlans",
            principalColumn: "ID",
            onDelete: ReferentialAction.Cascade);
        });

      migrationBuilder.InsertData(
        table: "CreditPlans",
        columns: new[] { "ID", "Anuity", "MinAmount", "MonthPeriod", "Name", "Percent" },
        values: new object[,]
        {
          { new Guid("a64f6381-32b4-423e-b9dd-498418dde886"), true, 100m, 60, "Standard", 11.25m },
          { new Guid("8904c876-7c2a-40c3-b5d9-b5bf0cb3c0be"), false, null, 80, "Standard+", 13.33m },
          { new Guid("d228a00e-cc18-457d-90ba-184d229a333c"), false, 10000000m, 120, "Medium", 8.75m },
          { new Guid("ab981561-fb5e-4ce3-a965-95a6de19a85b"), true, null, 120, "Ultra", 21.0m }
        });

      migrationBuilder.InsertData(
        table: "Currency",
        columns: new[] { "Name", "Code", "Symbol" },
        values: new object[,]
        {
          { "Czech koruna", "CZK", "Kč" },
          { "Euro", "EUR", "€" },
          { "Pounds sterling", "GBP", "£" },
          { "Russian ruble", "RUB", "₽" },
          { "Polish zloty", "PLN", "zł" },
          { "US dollar", "USD", "$" },
          { "Belarusian ruble", "BYR", "Br" }
        });

      migrationBuilder.CreateIndex(
        name: "IX_Credits_ClientID",
        table: "Credits",
        column: "ClientID");

      migrationBuilder.CreateIndex(
        name: "IX_Credits_CreditPlanID",
        table: "Credits",
        column: "CreditPlanID");

      migrationBuilder.CreateIndex(
        name: "IX_Credits_MainAccountNumber",
        table: "Credits",
        column: "MainAccountNumber");

      migrationBuilder.CreateIndex(
        name: "IX_Credits_PercentAccountNumber",
        table: "Credits",
        column: "PercentAccountNumber");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "Credits");

      migrationBuilder.DropTable(
          name: "Currency");

      migrationBuilder.DropTable(
          name: "CreditPlans");
    }
  }
}
