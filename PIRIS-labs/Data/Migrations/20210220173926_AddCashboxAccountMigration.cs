using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PIRIS_labs.Migrations
{
  public partial class AddCashboxAccountMigration: Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.InsertData(
        table: "Accounts",
        columns: new[] { "Number", "AccountPlanNumber", "Balance", "CreditValue", "DebitValue", "OwnerID" },
        values: new object[] { "1010000010027", "1010", 0m, 0m, 0m, new Guid("627de68a-7c1e-4983-9345-61351783b9e7") });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DeleteData(
        table: "Accounts",
        keyColumn: "Number",
        keyValue: "1010000010027");
    }
  }
}
