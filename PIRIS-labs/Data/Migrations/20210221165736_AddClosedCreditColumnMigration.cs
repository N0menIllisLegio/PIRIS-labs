using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PIRIS_labs.Migrations
{
  public partial class AddClosedCreditColumnMigration: Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropPrimaryKey(
        name: "PK_Currency",
        table: "Currency");

      migrationBuilder.AlterColumn<string>(
        name: "Symbol",
        table: "Currency",
        type: "nvarchar(10)",
        maxLength: 10,
        nullable: false,
        defaultValue: String.Empty,
        oldClrType: typeof(string),
        oldType: "nvarchar(10)",
        oldMaxLength: 10,
        oldNullable: true);

      migrationBuilder.AlterColumn<string>(
        name: "Code",
        table: "Currency",
        type: "nvarchar(20)",
        maxLength: 20,
        nullable: false,
        defaultValue: String.Empty,
        oldClrType: typeof(string),
        oldType: "nvarchar(20)",
        oldMaxLength: 20,
        oldNullable: true);

      migrationBuilder.AddColumn<bool>(
        name: "Closed",
        table: "Credits",
        type: "bit",
        nullable: false,
        defaultValue: false);

      migrationBuilder.AddPrimaryKey(
        name: "PK_Currency",
        table: "Currency",
        column: "Code");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropPrimaryKey(
        name: "PK_Currency",
        table: "Currency");

      migrationBuilder.DropColumn(
        name: "Closed",
        table: "Credits");

      migrationBuilder.AlterColumn<string>(
        name: "Symbol",
        table: "Currency",
        type: "nvarchar(10)",
        maxLength: 10,
        nullable: true,
        oldClrType: typeof(string),
        oldType: "nvarchar(10)",
        oldMaxLength: 10);

      migrationBuilder.AlterColumn<string>(
        name: "Code",
        table: "Currency",
        type: "nvarchar(20)",
        maxLength: 20,
        nullable: true,
        oldClrType: typeof(string),
        oldType: "nvarchar(20)",
        oldMaxLength: 20);

      migrationBuilder.AddPrimaryKey(
        name: "PK_Currency",
        table: "Currency",
        column: "Name");
    }
  }
}
