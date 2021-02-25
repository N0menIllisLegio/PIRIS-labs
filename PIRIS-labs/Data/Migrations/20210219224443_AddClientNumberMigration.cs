using Microsoft.EntityFrameworkCore.Migrations;

namespace PIRIS_labs.Migrations
{
  public partial class AddClientNumberMigration: Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AddColumn<int>(
        name: "Number",
        table: "Clients",
        type: "int",
        nullable: false,
        defaultValue: 0).Annotation("SqlServer:Identity", "1, 1");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropColumn(
        name: "Number",
        table: "Clients");
    }
  }
}