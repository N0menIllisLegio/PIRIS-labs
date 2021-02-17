using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PIRIS_labs.Migrations
{
  public partial class DepositEntitiesMigration: Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "AccountPlans",
          columns: table => new
          {
            ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            AccountNumber = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
            AccountName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
            AccountType = table.Column<int>(type: "int", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_AccountPlans", x => x.ID);
          });

      migrationBuilder.CreateTable(
          name: "Accounts",
          columns: table => new
          {
            ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            AccountNumber = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
            DebitValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            CreditValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            AccountPlanID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Accounts", x => x.ID);
            table.ForeignKey(
                      name: "FK_Accounts_AccountPlans_AccountPlanID",
                      column: x => x.AccountPlanID,
                      principalTable: "AccountPlans",
                      principalColumn: "ID",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "DepositPlans",
          columns: table => new
          {
            ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
            Percent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            DayPeriod = table.Column<int>(type: "int", nullable: false),
            Revocable = table.Column<bool>(type: "bit", nullable: false),
            MainAccountPlanID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            PercentAccountPlanID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_DepositPlans", x => x.ID);
            table.ForeignKey(
                      name: "FK_DepositPlans_AccountPlans_MainAccountPlanID",
                      column: x => x.MainAccountPlanID,
                      principalTable: "AccountPlans",
                      principalColumn: "ID",
                      onDelete: ReferentialAction.Restrict);
            table.ForeignKey(
                      name: "FK_DepositPlans_AccountPlans_PercentAccountPlanID",
                      column: x => x.PercentAccountPlanID,
                      principalTable: "AccountPlans",
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
            DebetAccountID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            CreditAccountID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Transactions", x => x.ID);
            table.ForeignKey(
                      name: "FK_Transactions_Accounts_CreditAccountID",
                      column: x => x.CreditAccountID,
                      principalTable: "Accounts",
                      principalColumn: "ID",
                      onDelete: ReferentialAction.Restrict);
            table.ForeignKey(
                      name: "FK_Transactions_Accounts_DebetAccountID",
                      column: x => x.DebetAccountID,
                      principalTable: "Accounts",
                      principalColumn: "ID",
                      onDelete: ReferentialAction.Restrict);
          });

      migrationBuilder.CreateTable(
          name: "Deposits",
          columns: table => new
          {
            ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            MainAccountID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            PercentAccountID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            ClientID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            DepositPlanID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Deposits", x => x.ID);
            table.ForeignKey(
                      name: "FK_Deposits_Accounts_MainAccountID",
                      column: x => x.MainAccountID,
                      principalTable: "Accounts",
                      principalColumn: "ID",
                      onDelete: ReferentialAction.Restrict);
            table.ForeignKey(
                      name: "FK_Deposits_Accounts_PercentAccountID",
                      column: x => x.PercentAccountID,
                      principalTable: "Accounts",
                      principalColumn: "ID",
                      onDelete: ReferentialAction.Restrict);
            table.ForeignKey(
                      name: "FK_Deposits_Clients_ClientID",
                      column: x => x.ClientID,
                      principalTable: "Clients",
                      principalColumn: "ID",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_Deposits_DepositPlans_DepositPlanID",
                      column: x => x.DepositPlanID,
                      principalTable: "DepositPlans",
                      principalColumn: "ID",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateIndex(
          name: "IX_Accounts_AccountPlanID",
          table: "Accounts",
          column: "AccountPlanID");

      migrationBuilder.CreateIndex(
          name: "IX_DepositPlans_MainAccountPlanID",
          table: "DepositPlans",
          column: "MainAccountPlanID");

      migrationBuilder.CreateIndex(
          name: "IX_DepositPlans_PercentAccountPlanID",
          table: "DepositPlans",
          column: "PercentAccountPlanID");

      migrationBuilder.CreateIndex(
          name: "IX_Deposits_ClientID",
          table: "Deposits",
          column: "ClientID");

      migrationBuilder.CreateIndex(
          name: "IX_Deposits_DepositPlanID",
          table: "Deposits",
          column: "DepositPlanID");

      migrationBuilder.CreateIndex(
          name: "IX_Deposits_MainAccountID",
          table: "Deposits",
          column: "MainAccountID");

      migrationBuilder.CreateIndex(
          name: "IX_Deposits_PercentAccountID",
          table: "Deposits",
          column: "PercentAccountID");

      migrationBuilder.CreateIndex(
          name: "IX_Transactions_CreditAccountID",
          table: "Transactions",
          column: "CreditAccountID");

      migrationBuilder.CreateIndex(
          name: "IX_Transactions_DebetAccountID",
          table: "Transactions",
          column: "DebetAccountID");
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
    }
  }
}
