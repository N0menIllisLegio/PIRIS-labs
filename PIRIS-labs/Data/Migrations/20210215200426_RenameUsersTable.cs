using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PIRIS_labs.Migrations
{
  public partial class RenameUsersTable: Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey(
        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
        table: "AspNetUserClaims");

      migrationBuilder.DropForeignKey(
        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
        table: "AspNetUserLogins");

      migrationBuilder.DropForeignKey(
        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
        table: "AspNetUserRoles");

      migrationBuilder.DropForeignKey(
        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
        table: "AspNetUserTokens");

      migrationBuilder.DropTable(
        name: "AspNetUsers");

      migrationBuilder.CreateTable(
        name: "Clients",
        columns: table => new
        {
          Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          Surname = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
          Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
          Patronymic = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
          Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
          Male = table.Column<bool>(type: "bit", nullable: false),
          BirthPlace = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
          ActualResidenceCityName = table.Column<string>(type: "nvarchar(250)", nullable: true),
          ActualResidenceAddress = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
          HomePhoneNumber = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
          MobilePhoneNumber = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
          WorkPlace = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
          Position = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
          RegistrationCityName = table.Column<string>(type: "nvarchar(250)", nullable: true),
          RegistrationAddress = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
          MaritalStatusName = table.Column<string>(type: "nvarchar(250)", nullable: true),
          NationalityName = table.Column<string>(type: "nvarchar(250)", nullable: true),
          DisabilityName = table.Column<string>(type: "nvarchar(250)", nullable: true),
          Pensioner = table.Column<bool>(type: "bit", nullable: false),
          MonthlyIncome = table.Column<int>(type: "int", nullable: true),
          LiableForMilitaryService = table.Column<bool>(type: "bit", nullable: false),
          PassportSeries = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
          PassportNumber = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
          PassportIssuedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
          PassportIssuedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
          IdentificationNumber = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
          Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
          EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
          PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Clients", x => x.Id);
          table.ForeignKey(
            name: "FK_Clients_Cities_ActualResidenceCityName",
            column: x => x.ActualResidenceCityName,
            principalTable: "Cities",
            principalColumn: "Name",
            onDelete: ReferentialAction.Restrict);
          table.ForeignKey(
            name: "FK_Clients_Cities_RegistrationCityName",
            column: x => x.RegistrationCityName,
            principalTable: "Cities",
            principalColumn: "Name",
            onDelete: ReferentialAction.Restrict);
          table.ForeignKey(
            name: "FK_Clients_Disabilities_DisabilityName",
            column: x => x.DisabilityName,
            principalTable: "Disabilities",
            principalColumn: "Name",
            onDelete: ReferentialAction.Restrict);
          table.ForeignKey(
            name: "FK_Clients_MaritalStatuses_MaritalStatusName",
            column: x => x.MaritalStatusName,
            principalTable: "MaritalStatuses",
            principalColumn: "Name",
            onDelete: ReferentialAction.Restrict);
          table.ForeignKey(
            name: "FK_Clients_Nationalities_NationalityName",
            column: x => x.NationalityName,
            principalTable: "Nationalities",
            principalColumn: "Name",
            onDelete: ReferentialAction.Restrict);
        });

      migrationBuilder.CreateIndex(
        name: "IX_Clients_ActualResidenceCityName",
        table: "Clients",
        column: "ActualResidenceCityName");

      migrationBuilder.CreateIndex(
        name: "IX_Clients_DisabilityName",
        table: "Clients",
        column: "DisabilityName");

      migrationBuilder.CreateIndex(
        name: "IX_Clients_MaritalStatusName",
        table: "Clients",
        column: "MaritalStatusName");

      migrationBuilder.CreateIndex(
        name: "IX_Clients_NationalityName",
        table: "Clients",
        column: "NationalityName");

      migrationBuilder.CreateIndex(
        name: "IX_Clients_RegistrationCityName",
        table: "Clients",
        column: "RegistrationCityName");

      migrationBuilder.AddForeignKey(
        name: "FK_AspNetUserClaims_Clients_UserId",
        table: "AspNetUserClaims",
        column: "UserId",
        principalTable: "Clients",
        principalColumn: "Id",
        onDelete: ReferentialAction.Cascade);

      migrationBuilder.AddForeignKey(
        name: "FK_AspNetUserLogins_Clients_UserId",
        table: "AspNetUserLogins",
        column: "UserId",
        principalTable: "Clients",
        principalColumn: "Id",
        onDelete: ReferentialAction.Cascade);

      migrationBuilder.AddForeignKey(
        name: "FK_AspNetUserRoles_Clients_UserId",
        table: "AspNetUserRoles",
        column: "UserId",
        principalTable: "Clients",
        principalColumn: "Id",
        onDelete: ReferentialAction.Cascade);

      migrationBuilder.AddForeignKey(
        name: "FK_AspNetUserTokens_Clients_UserId",
        table: "AspNetUserTokens",
        column: "UserId",
        principalTable: "Clients",
        principalColumn: "Id",
        onDelete: ReferentialAction.Cascade);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey(
        name: "FK_AspNetUserClaims_Clients_UserId",
        table: "AspNetUserClaims");

      migrationBuilder.DropForeignKey(
        name: "FK_AspNetUserLogins_Clients_UserId",
        table: "AspNetUserLogins");

      migrationBuilder.DropForeignKey(
        name: "FK_AspNetUserRoles_Clients_UserId",
        table: "AspNetUserRoles");

      migrationBuilder.DropForeignKey(
        name: "FK_AspNetUserTokens_Clients_UserId",
        table: "AspNetUserTokens");

      migrationBuilder.DropTable(
        name: "Clients");

      migrationBuilder.CreateTable(
        name: "AspNetUsers",
        columns: table => new
        {
          Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          ActualResidenceAddress = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
          ActualResidenceCityName = table.Column<string>(type: "nvarchar(250)", nullable: true),
          BirthPlace = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
          Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
          DisabilityName = table.Column<string>(type: "nvarchar(250)", nullable: true),
          Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
          EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
          HomePhoneNumber = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
          IdentificationNumber = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
          LiableForMilitaryService = table.Column<bool>(type: "bit", nullable: false),
          Male = table.Column<bool>(type: "bit", nullable: false),
          MaritalStatusName = table.Column<string>(type: "nvarchar(250)", nullable: true),
          MobilePhoneNumber = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
          MonthlyIncome = table.Column<int>(type: "int", nullable: true),
          Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
          NationalityName = table.Column<string>(type: "nvarchar(250)", nullable: true),
          PassportIssuedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
          PassportIssuedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
          PassportNumber = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
          PassportSeries = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
          PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
          Patronymic = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
          Pensioner = table.Column<bool>(type: "bit", nullable: false),
          Position = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
          RegistrationAddress = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
          RegistrationCityName = table.Column<string>(type: "nvarchar(250)", nullable: true),
          Surname = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
          WorkPlace = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_AspNetUsers", x => x.Id);
          table.ForeignKey(
            name: "FK_AspNetUsers_Cities_ActualResidenceCityName",
            column: x => x.ActualResidenceCityName,
            principalTable: "Cities",
            principalColumn: "Name",
            onDelete: ReferentialAction.Restrict);
          table.ForeignKey(
            name: "FK_AspNetUsers_Cities_RegistrationCityName",
            column: x => x.RegistrationCityName,
            principalTable: "Cities",
            principalColumn: "Name",
            onDelete: ReferentialAction.Restrict);
          table.ForeignKey(
            name: "FK_AspNetUsers_Disabilities_DisabilityName",
            column: x => x.DisabilityName,
            principalTable: "Disabilities",
            principalColumn: "Name",
            onDelete: ReferentialAction.Restrict);
          table.ForeignKey(
            name: "FK_AspNetUsers_MaritalStatuses_MaritalStatusName",
            column: x => x.MaritalStatusName,
            principalTable: "MaritalStatuses",
            principalColumn: "Name",
            onDelete: ReferentialAction.Restrict);
          table.ForeignKey(
            name: "FK_AspNetUsers_Nationalities_NationalityName",
            column: x => x.NationalityName,
            principalTable: "Nationalities",
            principalColumn: "Name",
            onDelete: ReferentialAction.Restrict);
        });

      migrationBuilder.CreateIndex(
        name: "IX_AspNetUsers_ActualResidenceCityName",
        table: "AspNetUsers",
        column: "ActualResidenceCityName");

      migrationBuilder.CreateIndex(
        name: "IX_AspNetUsers_DisabilityName",
        table: "AspNetUsers",
        column: "DisabilityName");

      migrationBuilder.CreateIndex(
        name: "IX_AspNetUsers_MaritalStatusName",
        table: "AspNetUsers",
        column: "MaritalStatusName");

      migrationBuilder.CreateIndex(
        name: "IX_AspNetUsers_NationalityName",
        table: "AspNetUsers",
        column: "NationalityName");

      migrationBuilder.CreateIndex(
        name: "IX_AspNetUsers_RegistrationCityName",
        table: "AspNetUsers",
        column: "RegistrationCityName");

      migrationBuilder.AddForeignKey(
        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
        table: "AspNetUserClaims",
        column: "UserId",
        principalTable: "AspNetUsers",
        principalColumn: "Id",
        onDelete: ReferentialAction.Cascade);

      migrationBuilder.AddForeignKey(
        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
        table: "AspNetUserLogins",
        column: "UserId",
        principalTable: "AspNetUsers",
        principalColumn: "Id",
        onDelete: ReferentialAction.Cascade);

      migrationBuilder.AddForeignKey(
        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
        table: "AspNetUserRoles",
        column: "UserId",
        principalTable: "AspNetUsers",
        principalColumn: "Id",
        onDelete: ReferentialAction.Cascade);

      migrationBuilder.AddForeignKey(
        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
        table: "AspNetUserTokens",
        column: "UserId",
        principalTable: "AspNetUsers",
        principalColumn: "Id",
        onDelete: ReferentialAction.Cascade);
    }
  }
}
