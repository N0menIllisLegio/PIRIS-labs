using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PIRIS_labs.Migrations
{
  public partial class InitialMigration: Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
        name: "AspNetRoles",
        columns: table => new
        {
          Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
          NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
          ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_AspNetRoles", x => x.Id);
        });

      migrationBuilder.CreateTable(
        name: "Cities",
        columns: table => new
        {
          Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Cities", x => x.Name);
        });

      migrationBuilder.CreateTable(
        name: "Disabilities",
        columns: table => new
        {
          Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Disabilities", x => x.Name);
        });

      migrationBuilder.CreateTable(
        name: "MaritalStatuses",
        columns: table => new
        {
          Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_MaritalStatuses", x => x.Name);
        });

      migrationBuilder.CreateTable(
        name: "Nationalities",
        columns: table => new
        {
          Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Nationalities", x => x.Name);
        });

      migrationBuilder.CreateTable(
        name: "AspNetRoleClaims",
        columns: table => new
        {
          Id = table.Column<int>(type: "int", nullable: false)
                .Annotation("SqlServer:Identity", "1, 1"),
          RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
          ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
        name: "AspNetUsers",
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

      migrationBuilder.CreateTable(
        name: "AspNetUserClaims",
        columns: table => new
        {
          Id = table.Column<int>(type: "int", nullable: false)
                .Annotation("SqlServer:Identity", "1, 1"),
          UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
          ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
          table.ForeignKey(
            name: "FK_AspNetUserClaims_AspNetUsers_UserId",
            column: x => x.UserId,
            principalTable: "AspNetUsers",
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
            name: "FK_AspNetUserLogins_AspNetUsers_UserId",
            column: x => x.UserId,
            principalTable: "AspNetUsers",
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
            name: "FK_AspNetUserRoles_AspNetUsers_UserId",
            column: x => x.UserId,
            principalTable: "AspNetUsers",
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
            name: "FK_AspNetUserTokens_AspNetUsers_UserId",
            column: x => x.UserId,
            principalTable: "AspNetUsers",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
        });

      migrationBuilder.InsertData(
        table: "Cities",
        column: "Name",
        values: new object[]
        {
          "Yerpolis",
          "Flufield",
          "Zheanford",
          "Graepding",
          "Osheles",
          "Ephoni",
          "Streah",
          "Amport",
          "Mucaster",
          "Shagas",
          "Qribert",
          "Khetmore",
          "Dorough",
          "Stranta",
          "Jeka",
          "Qesa",
          "Olislas",
          "Icofield",
          "Justin",
          "Shixrith",
          "Ingdence",
          "Andsas",
          "Qexpolis",
          "Encedon",
          "Zhexson",
          "Dekdale",
          "Purgh",
          "Jine",
          "Fleim",
          "Andville",
          "Enslens",
          "Ijefbridge",
          "Vluddon",
          "Cluebridge",
          "Besding",
          "Keedlas",
          "Plando",
          "Breka",
          "Bison",
          "Bruusginia"
        });

      migrationBuilder.InsertData(
        table: "Disabilities",
        column: "Name",
        values: new object[]
        {
          "Mental Disorders",
          "Neurological Disorders",
          "Congenital Disorders that Affect Multiple Body Systems",
          "Endocrine Disorders",
          "Skin Disorders",
          "Digestive System",
          "Genitourinary Disorders",
          "Cardiovascular System",
          "Respiratory Disorders",
          "Special Senses and Speech",
          "Musculoskeletal System",
          "Hematological Disorders",
          "Immune System Disorders",
          "Cancer (Malignant Neoplastic Diseases)"
        });

      migrationBuilder.InsertData(
        table: "MaritalStatuses",
        column: "Name",
        values: new object[]
        {
          "Separated",
          "Registered partnership",
          "Divorced",
          "Widowed",
          "Married",
          "Single"
        });

      migrationBuilder.InsertData(
        table: "Nationalities",
        column: "Name",
        values: new object[]
        {
          "Mozambican",
          "Namibian",
          "Nauruan",
          "Nepalese",
          "New Zealander",
          "Nicaraguan",
          "Nigerian",
          "Nigerien",
          "Niuean",
          "North Korean",
          "Northern Irish",
          "Norwegian",
          "Omani",
          "Pakistani",
          "Palauan",
          "Palestinian",
          "Panamanian",
          "Papua New Guinean",
          "Paraguayan",
          "Peruvian",
          "Pitcairn Islander",
          "Polish",
          "Portuguese",
          "Prydeinig"
        });

      migrationBuilder.InsertData(
        table: "Nationalities",
        column: "Name",
        values: new object[]
        {
          "Mosotho",
          "Moroccan",
          "Montserratian",
          "Montenegrin",
          "Latvian",
          "Lebanese",
          "Liberian",
          "Libyan",
          "Liechtenstein citizen",
          "Lithuanian",
          "Luxembourger",
          "Macanese",
          "Macedonian",
          "Malagasy",
          "Malawian",
          "Puerto Rican",
          "Malaysian",
          "Malian",
          "Maltese",
          "Marshallese",
          "Martiniquais",
          "Mauritanian",
          "Mauritian",
          "Mexican",
          "Micronesian",
          "Moldovan",
          "Monegasque",
          "Mongolian",
          "Maldivian",
          "Qatari",
          "Swiss",
          "Russian",
          "Taiwanese",
          "Tajik",
          "Tanzanian",
          "Thai",
          "Togolese",
          "Tongan",
          "Trinidadian",
          "Tristanian",
          "Tunisian",
          "Turkish"
        });

      migrationBuilder.InsertData(
        table: "Nationalities",
        column: "Name",
        values: new object[]
        {
          "Turkmen",
          "Syrian",
          "Turks and Caicos Islander",
          "Ugandan",
          "Ukrainian",
          "Uruguayan",
          "Uzbek",
          "Vatican citizen",
          "Venezuelan",
          "Vietnamese",
          "Vincentian",
          "Wallisian",
          "Welsh",
          "Yemeni",
          "Tuvaluan",
          "Lao",
          "Swedish",
          "Swazi",
          "Rwandan",
          "Salvadorean",
          "Sammarinese",
          "Samoan",
          "Sao Tomean",
          "Saudi Arabian",
          "Scottish",
          "Senegalese",
          "Serbian",
          "Sierra Leonean",
          "Singaporean",
          "Slovak",
          "Slovenian",
          "Solomon Islander",
          "Somali",
          "South African",
          "South Korean",
          "South Sudanese",
          "Spanish",
          "Sri Lankan",
          "St Helenian",
          "St Lucian",
          "Stateless",
          "Sudanese"
        });

      migrationBuilder.InsertData(
        table: "Nationalities",
        column: "Name",
        values: new object[]
        {
          "Surinamese",
          "Romanian",
          "Kyrgyz",
          "Ghanaian",
          "Kosovan",
          "Burkinan",
          "Burmese",
          "Burundian",
          "Cambodian",
          "Cameroonian",
          "Canadian",
          "Cape Verdean",
          "Cayman Islander",
          "Central African",
          "Chadian",
          "Chilean",
          "Bulgarian",
          "Chinese",
          "Citizen of Bosnia and Herzegovina",
          "Citizen of Guinea-Bissau",
          "Citizen of Kiribati",
          "Citizen of Seychelles",
          "Citizen of the Dominican Republic",
          "Citizen of Vanuatu",
          "Colombian",
          "Comoran",
          "Congolese (Congo)",
          "Congolese (DRC)",
          "Cook Islander",
          "Citizen of Antigua and Barbuda",
          "Bruneian",
          "British Virgin Islander",
          "British",
          "Afghan",
          "Albanian",
          "Algerian",
          "American",
          "Andorran",
          "Angolan",
          "Anguillan",
          "Argentine",
          "Armenian"
        });

      migrationBuilder.InsertData(
        table: "Nationalities",
        column: "Name",
        values: new object[]
        {
          "Australian",
          "Austrian",
          "Azerbaijani",
          "Bahamian",
          "Bahraini",
          "Bangladeshi",
          "Barbadian",
          "Belarusian",
          "Belgian",
          "Belizean",
          "Beninese",
          "Bermudian",
          "Bhutanese",
          "Bolivian",
          "Botswanan",
          "Brazilian",
          "Costa Rican",
          "Kuwaiti",
          "Croatian",
          "Cymraes",
          "Grenadian",
          "Guamanian",
          "Guatemalan",
          "Guinean",
          "Guyanese",
          "Haitian",
          "Honduran",
          "Hong Konger",
          "Hungarian",
          "Icelandic",
          "Indian",
          "Greenlandic",
          "Indonesian",
          "Iraqi",
          "Irish",
          "Israeli",
          "Italian",
          "Ivorian",
          "Jamaican",
          "Japanese",
          "Jordanian",
          "Kazakh"
        });

      migrationBuilder.InsertData(
        table: "Nationalities",
        column: "Name",
        values: new object[]
        {
          "Kenyan",
          "Kittitian",
          "Iranian",
          "Greek",
          "Gibraltarian",
          "Zambian",
          "Cymro",
          "Cypriot",
          "Czech",
          "Danish",
          "Djiboutian",
          "Dominican",
          "Dutch",
          "East Timorese",
          "Ecuadorean",
          "Egyptian",
          "Emirati",
          "English",
          "Equatorial Guinean",
          "Eritrean",
          "Estonian",
          "Ethiopian",
          "Faroese",
          "Fijian",
          "Filipino",
          "Finnish",
          "French",
          "Gabonese",
          "Gambian",
          "Georgian",
          "German",
          "Cuban",
          "Zimbabwean"
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
    }

    protected override void Down(MigrationBuilder migrationBuilder)
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

      migrationBuilder.DropTable(
        name: "AspNetUsers");

      migrationBuilder.DropTable(
        name: "Cities");

      migrationBuilder.DropTable(
        name: "Disabilities");

      migrationBuilder.DropTable(
        name: "MaritalStatuses");

      migrationBuilder.DropTable(
        name: "Nationalities");
    }
  }
}
