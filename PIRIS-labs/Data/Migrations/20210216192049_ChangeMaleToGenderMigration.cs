using Microsoft.EntityFrameworkCore.Migrations;

namespace PIRIS_labs.Migrations
{
  public partial class ChangeMaleToGenderMigration: Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropColumn(
        name: "Male",
        table: "Clients");

      migrationBuilder.AddColumn<int>(
        name: "Gender",
        table: "Clients",
        type: "int",
        nullable: false,
        defaultValue: 0);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropColumn(
        name: "Gender",
        table: "Clients");

      migrationBuilder.AddColumn<bool>(
        name: "Male",
        table: "Clients",
        type: "bit",
        nullable: false,
        defaultValue: false);
    }
  }
}
