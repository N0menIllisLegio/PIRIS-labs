using Microsoft.EntityFrameworkCore.Migrations;

namespace PIRIS_labs.Migrations
{
  public partial class AddDepositClosedColumnMigration: Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AddColumn<bool>(
        name: "Closed",
        table: "Deposits",
        type: "bit",
        nullable: false,
        defaultValue: false);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropColumn(
        name: "Closed",
        table: "Deposits");
    }
  }
}
