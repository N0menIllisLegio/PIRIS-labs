using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PIRIS_labs.Migrations
{
  public partial class AddCreditCardMigration: Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
        name: "CreditCards",
        columns: table => new
        {
          Number = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
          EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
          PIN = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
          OwnerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          CreditAccountNumber = table.Column<string>(type: "nvarchar(13)", nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_CreditCards", x => x.Number);
          table.ForeignKey(
            name: "FK_CreditCards_Accounts_CreditAccountNumber",
            column: x => x.CreditAccountNumber,
            principalTable: "Accounts",
            principalColumn: "Number",
            onDelete: ReferentialAction.Cascade);
          table.ForeignKey(
            name: "FK_CreditCards_Clients_OwnerID",
            column: x => x.OwnerID,
            principalTable: "Clients",
            principalColumn: "ID",
            onDelete: ReferentialAction.Restrict);
        });

      migrationBuilder.CreateIndex(
        name: "IX_CreditCards_CreditAccountNumber",
        table: "CreditCards",
        column: "CreditAccountNumber");

      migrationBuilder.CreateIndex(
        name: "IX_CreditCards_OwnerID",
        table: "CreditCards",
        column: "OwnerID");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
        name: "CreditCards");
    }
  }
}
