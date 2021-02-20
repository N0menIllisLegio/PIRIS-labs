using Microsoft.EntityFrameworkCore.Migrations;

namespace PIRIS_labs.Migrations
{
  public partial class AddClientsAccountNumberColumnMigration: Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AddColumn<int>(
        name: "ClientsAccountNumber",
        table: "Accounts",
        type: "int",
        nullable: true,
        computedColumnSql: "CAST(SUBSTRING([Number], 10, 3) AS INT)",
        stored: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropColumn(
        name: "ClientsAccountNumber",
        table: "Accounts");
    }
  }
}