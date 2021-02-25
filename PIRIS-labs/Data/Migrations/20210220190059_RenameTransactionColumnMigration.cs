using Microsoft.EntityFrameworkCore.Migrations;

namespace PIRIS_labs.Migrations
{
  public partial class RenameTransactionColumnMigration: Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.RenameColumn(
        name: "TransactionDay",
        table: "Transactions",
        newName: "TransactionTime");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.RenameColumn(
        name: "TransactionTime",
        table: "Transactions",
        newName: "TransactionDay");
    }
  }
}
