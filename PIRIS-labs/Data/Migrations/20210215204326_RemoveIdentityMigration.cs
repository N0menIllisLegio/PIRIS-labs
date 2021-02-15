using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PIRIS_labs.Migrations
{
  public partial class RemoveIdentityMigration: Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
        name: "AspNetRoleClaims");

      migrationBuilder.DropTable(
        name: "AspNetUserClaims");

      migrationBuilder.DropTable(
        name: "AspNetUserLogins");

      migrationBuilder.DropTable(
        name: "AspNetUserRoles");

      migrationBuilder.DropTable(
        name: "AspNetUserTokens");

      migrationBuilder.DropTable(
        name: "AspNetRoles");

      migrationBuilder.DropColumn(
        name: "EmailConfirmed",
        table: "Clients");

      migrationBuilder.DropColumn(
        name: "PasswordHash",
        table: "Clients");

      migrationBuilder.RenameColumn(
        name: "Id",
        table: "Clients",
        newName: "ID");

      migrationBuilder.AlterColumn<string>(
        name: "Email",
        table: "Clients",
        type: "nvarchar(250)",
        maxLength: 250,
        nullable: true,
        oldClrType: typeof(string),
        oldType: "nvarchar(256)",
        oldMaxLength: 256,
        oldNullable: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.RenameColumn(
        name: "ID",
        table: "Clients",
        newName: "Id");

      migrationBuilder.AlterColumn<string>(
        name: "Email",
        table: "Clients",
        type: "nvarchar(256)",
        maxLength: 256,
        nullable: true,
        oldClrType: typeof(string),
        oldType: "nvarchar(250)",
        oldMaxLength: 250,
        oldNullable: true);

      migrationBuilder.AddColumn<bool>(
        name: "EmailConfirmed",
        table: "Clients",
        type: "bit",
        nullable: false,
        defaultValue: false);

      migrationBuilder.AddColumn<string>(
        name: "PasswordHash",
        table: "Clients",
        type: "nvarchar(max)",
        nullable: true);

      migrationBuilder.CreateTable(
        name: "AspNetRoles",
        columns: table => new
        {
          Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
          Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
          NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_AspNetRoles", x => x.Id);
        });

      migrationBuilder.CreateTable(
        name: "AspNetUserClaims",
        columns: table => new
        {
          Id = table.Column<int>(type: "int", nullable: false)
                .Annotation("SqlServer:Identity", "1, 1"),
          ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
          ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
          UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
          table.ForeignKey(
            name: "FK_AspNetUserClaims_Clients_UserId",
            column: x => x.UserId,
            principalTable: "Clients",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
        });

      migrationBuilder.CreateTable(
        name: "AspNetUserLogins",
        columns: table => new
        {
          LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
          ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
          ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
          UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
          table.ForeignKey(
            name: "FK_AspNetUserLogins_Clients_UserId",
            column: x => x.UserId,
            principalTable: "Clients",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
        });

      migrationBuilder.CreateTable(
        name: "AspNetUserTokens",
        columns: table => new
        {
          UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
          Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
          Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
          table.ForeignKey(
            name: "FK_AspNetUserTokens_Clients_UserId",
            column: x => x.UserId,
            principalTable: "Clients",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
        });

      migrationBuilder.CreateTable(
        name: "AspNetRoleClaims",
        columns: table => new
        {
          Id = table.Column<int>(type: "int", nullable: false)
                .Annotation("SqlServer:Identity", "1, 1"),
          ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
          ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
          RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
          table.ForeignKey(
            name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
            column: x => x.RoleId,
            principalTable: "AspNetRoles",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
        });

      migrationBuilder.CreateTable(
        name: "AspNetUserRoles",
        columns: table => new
        {
          UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
          table.ForeignKey(
            name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
            column: x => x.RoleId,
            principalTable: "AspNetRoles",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
          table.ForeignKey(
            name: "FK_AspNetUserRoles_Clients_UserId",
            column: x => x.UserId,
            principalTable: "Clients",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
        });

      migrationBuilder.CreateIndex(
        name: "IX_AspNetRoleClaims_RoleId",
        table: "AspNetRoleClaims",
        column: "RoleId");

      migrationBuilder.CreateIndex(
        name: "RoleNameIndex",
        table: "AspNetRoles",
        column: "NormalizedName",
        unique: true,
        filter: "[NormalizedName] IS NOT NULL");

      migrationBuilder.CreateIndex(
        name: "IX_AspNetUserClaims_UserId",
        table: "AspNetUserClaims",
        column: "UserId");

      migrationBuilder.CreateIndex(
        name: "IX_AspNetUserLogins_UserId",
        table: "AspNetUserLogins",
        column: "UserId");

      migrationBuilder.CreateIndex(
        name: "IX_AspNetUserRoles_RoleId",
        table: "AspNetUserRoles",
        column: "RoleId");
    }
  }
}
