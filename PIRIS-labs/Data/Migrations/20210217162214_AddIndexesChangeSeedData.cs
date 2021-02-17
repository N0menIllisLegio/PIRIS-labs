using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PIRIS_labs.Migrations
{
  public partial class AddIndexesChangeSeedData: Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey(
          name: "FK_Clients_Cities_ActualResidenceCityName",
          table: "Clients");

      migrationBuilder.DropForeignKey(
          name: "FK_Clients_Cities_RegistrationCityName",
          table: "Clients");

      migrationBuilder.DropForeignKey(
          name: "FK_Clients_Disabilities_DisabilityName",
          table: "Clients");

      migrationBuilder.DropForeignKey(
          name: "FK_Clients_MaritalStatuses_MaritalStatusName",
          table: "Clients");

      migrationBuilder.DropForeignKey(
          name: "FK_Clients_Nationalities_NationalityName",
          table: "Clients");

      migrationBuilder.DeleteData(
          table: "Cities",
          keyColumn: "Name",
          keyValue: "Amport");

      migrationBuilder.DeleteData(
          table: "Cities",
          keyColumn: "Name",
          keyValue: "Andsas");

      migrationBuilder.DeleteData(
          table: "Cities",
          keyColumn: "Name",
          keyValue: "Andville");

      migrationBuilder.DeleteData(
          table: "Cities",
          keyColumn: "Name",
          keyValue: "Bison");

      migrationBuilder.DeleteData(
          table: "Cities",
          keyColumn: "Name",
          keyValue: "Breka");

      migrationBuilder.DeleteData(
          table: "Cities",
          keyColumn: "Name",
          keyValue: "Bruusginia");

      migrationBuilder.DeleteData(
          table: "Cities",
          keyColumn: "Name",
          keyValue: "Cluebridge");

      migrationBuilder.DeleteData(
          table: "Cities",
          keyColumn: "Name",
          keyValue: "Dekdale");

      migrationBuilder.DeleteData(
          table: "Cities",
          keyColumn: "Name",
          keyValue: "Encedon");

      migrationBuilder.DeleteData(
          table: "Cities",
          keyColumn: "Name",
          keyValue: "Enslens");

      migrationBuilder.DeleteData(
          table: "Cities",
          keyColumn: "Name",
          keyValue: "Ephoni");

      migrationBuilder.DeleteData(
          table: "Cities",
          keyColumn: "Name",
          keyValue: "Flufield");

      migrationBuilder.DeleteData(
          table: "Cities",
          keyColumn: "Name",
          keyValue: "Graepding");

      migrationBuilder.DeleteData(
          table: "Cities",
          keyColumn: "Name",
          keyValue: "Ijefbridge");

      migrationBuilder.DeleteData(
          table: "Cities",
          keyColumn: "Name",
          keyValue: "Ingdence");

      migrationBuilder.DeleteData(
          table: "Cities",
          keyColumn: "Name",
          keyValue: "Justin");

      migrationBuilder.DeleteData(
          table: "Cities",
          keyColumn: "Name",
          keyValue: "Khetmore");

      migrationBuilder.DeleteData(
          table: "Cities",
          keyColumn: "Name",
          keyValue: "Mucaster");

      migrationBuilder.DeleteData(
          table: "Cities",
          keyColumn: "Name",
          keyValue: "Osheles");

      migrationBuilder.DeleteData(
          table: "Cities",
          keyColumn: "Name",
          keyValue: "Plando");

      migrationBuilder.DeleteData(
          table: "Cities",
          keyColumn: "Name",
          keyValue: "Qexpolis");

      migrationBuilder.DeleteData(
          table: "Cities",
          keyColumn: "Name",
          keyValue: "Qribert");

      migrationBuilder.DeleteData(
          table: "Cities",
          keyColumn: "Name",
          keyValue: "Shagas");

      migrationBuilder.DeleteData(
          table: "Cities",
          keyColumn: "Name",
          keyValue: "Shixrith");

      migrationBuilder.DeleteData(
          table: "Cities",
          keyColumn: "Name",
          keyValue: "Streah");

      migrationBuilder.DeleteData(
          table: "Cities",
          keyColumn: "Name",
          keyValue: "Vluddon");

      migrationBuilder.DeleteData(
          table: "Cities",
          keyColumn: "Name",
          keyValue: "Zheanford");

      migrationBuilder.DeleteData(
          table: "Cities",
          keyColumn: "Name",
          keyValue: "Zhexson");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Afghan");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Albanian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Algerian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "American");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Andorran");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Angolan");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Anguillan");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Argentine");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Armenian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Australian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Azerbaijani");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Bahamian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Bahraini");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Bangladeshi");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Barbadian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Belgian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Belizean");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Beninese");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Bermudian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Bhutanese");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Bolivian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Botswanan");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Brazilian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "British");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "British Virgin Islander");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Bruneian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Bulgarian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Burkinan");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Burmese");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Burundian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Cambodian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Cameroonian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Canadian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Cape Verdean");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Cayman Islander");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Central African");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Chadian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Chilean");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Chinese");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Citizen of Antigua and Barbuda");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Citizen of Bosnia and Herzegovina");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Citizen of Guinea-Bissau");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Citizen of Kiribati");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Citizen of Seychelles");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Citizen of the Dominican Republic");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Citizen of Vanuatu");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Colombian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Comoran");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Congolese (Congo)");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Congolese (DRC)");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Cook Islander");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Costa Rican");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Croatian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Cuban");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Cymraes");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Cymro");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Cypriot");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Danish");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Djiboutian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Dominican");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Dutch");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "East Timorese");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Ecuadorean");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Egyptian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Emirati");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "English");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Equatorial Guinean");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Eritrean");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Estonian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Ethiopian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Faroese");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Fijian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Filipino");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Finnish");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Gabonese");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Gambian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Ghanaian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Gibraltarian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Greenlandic");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Grenadian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Guamanian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Guatemalan");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Guinean");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Guyanese");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Haitian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Honduran");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Hong Konger");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Hungarian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Icelandic");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Indian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Indonesian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Iranian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Iraqi");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Irish");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Israeli");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Italian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Ivorian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Jamaican");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Jordanian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Kazakh");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Kenyan");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Kittitian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Kosovan");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Kuwaiti");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Kyrgyz");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Lao");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Latvian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Lebanese");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Liberian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Libyan");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Lithuanian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Luxembourger");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Macanese");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Macedonian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Malagasy");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Malawian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Malaysian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Maldivian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Malian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Maltese");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Marshallese");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Martiniquais");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Mauritanian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Mauritian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Mexican");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Micronesian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Moldovan");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Monegasque");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Mongolian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Montenegrin");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Montserratian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Moroccan");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Mosotho");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Mozambican");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Namibian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Nauruan");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Nepalese");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "New Zealander");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Nicaraguan");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Nigerian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Nigerien");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Niuean");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "North Korean");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Northern Irish");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Omani");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Pakistani");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Palauan");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Palestinian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Panamanian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Papua New Guinean");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Paraguayan");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Peruvian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Pitcairn Islander");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Portuguese");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Prydeinig");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Puerto Rican");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Qatari");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Romanian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Russian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Rwandan");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Salvadorean");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Sammarinese");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Samoan");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Sao Tomean");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Saudi Arabian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Senegalese");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Serbian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Sierra Leonean");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Singaporean");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Slovak");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Slovenian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Solomon Islander");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Somali");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "South African");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "South Korean");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "South Sudanese");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Spanish");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Sri Lankan");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "St Helenian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "St Lucian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Stateless");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Sudanese");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Surinamese");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Swazi");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Syrian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Taiwanese");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Tajik");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Tanzanian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Thai");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Togolese");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Tongan");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Trinidadian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Tristanian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Tunisian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Turkmen");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Turks and Caicos Islander");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Tuvaluan");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Ukrainian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Uruguayan");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Uzbek");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Vietnamese");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Vincentian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Wallisian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Yemeni");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Zambian");

      migrationBuilder.DeleteData(
          table: "Nationalities",
          keyColumn: "Name",
          keyValue: "Zimbabwean");

      migrationBuilder.AlterColumn<string>(
          name: "RegistrationCityName",
          table: "Clients",
          type: "nvarchar(250)",
          nullable: false,
          defaultValue: String.Empty,
          oldClrType: typeof(string),
          oldType: "nvarchar(250)",
          oldNullable: true);

      migrationBuilder.AlterColumn<string>(
          name: "NationalityName",
          table: "Clients",
          type: "nvarchar(250)",
          nullable: false,
          defaultValue: String.Empty,
          oldClrType: typeof(string),
          oldType: "nvarchar(250)",
          oldNullable: true);

      migrationBuilder.AlterColumn<string>(
          name: "MaritalStatusName",
          table: "Clients",
          type: "nvarchar(250)",
          nullable: false,
          defaultValue: String.Empty,
          oldClrType: typeof(string),
          oldType: "nvarchar(250)",
          oldNullable: true);

      migrationBuilder.AlterColumn<string>(
          name: "DisabilityName",
          table: "Clients",
          type: "nvarchar(250)",
          nullable: false,
          defaultValue: String.Empty,
          oldClrType: typeof(string),
          oldType: "nvarchar(250)",
          oldNullable: true);

      migrationBuilder.AlterColumn<string>(
          name: "ActualResidenceCityName",
          table: "Clients",
          type: "nvarchar(250)",
          nullable: false,
          defaultValue: String.Empty,
          oldClrType: typeof(string),
          oldType: "nvarchar(250)",
          oldNullable: true);

      migrationBuilder.InsertData(
          table: "Disabilities",
          column: "Name",
          value: "None");

      migrationBuilder.CreateIndex(
          name: "IX_Clients_IdentificationNumber",
          table: "Clients",
          column: "IdentificationNumber",
          unique: true);

      migrationBuilder.CreateIndex(
          name: "IX_Clients_PassportSeries_PassportNumber",
          table: "Clients",
          columns: new[] { "PassportSeries", "PassportNumber" },
          unique: true);

      migrationBuilder.AddForeignKey(
          name: "FK_Clients_Cities_ActualResidenceCityName",
          table: "Clients",
          column: "ActualResidenceCityName",
          principalTable: "Cities",
          principalColumn: "Name",
          onDelete: ReferentialAction.Restrict);

      migrationBuilder.AddForeignKey(
          name: "FK_Clients_Cities_RegistrationCityName",
          table: "Clients",
          column: "RegistrationCityName",
          principalTable: "Cities",
          principalColumn: "Name",
          onDelete: ReferentialAction.Restrict);

      migrationBuilder.AddForeignKey(
          name: "FK_Clients_Disabilities_DisabilityName",
          table: "Clients",
          column: "DisabilityName",
          principalTable: "Disabilities",
          principalColumn: "Name",
          onDelete: ReferentialAction.Restrict);

      migrationBuilder.AddForeignKey(
          name: "FK_Clients_MaritalStatuses_MaritalStatusName",
          table: "Clients",
          column: "MaritalStatusName",
          principalTable: "MaritalStatuses",
          principalColumn: "Name",
          onDelete: ReferentialAction.Restrict);

      migrationBuilder.AddForeignKey(
          name: "FK_Clients_Nationalities_NationalityName",
          table: "Clients",
          column: "NationalityName",
          principalTable: "Nationalities",
          principalColumn: "Name",
          onDelete: ReferentialAction.Restrict);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey(
          name: "FK_Clients_Cities_ActualResidenceCityName",
          table: "Clients");

      migrationBuilder.DropForeignKey(
          name: "FK_Clients_Cities_RegistrationCityName",
          table: "Clients");

      migrationBuilder.DropForeignKey(
          name: "FK_Clients_Disabilities_DisabilityName",
          table: "Clients");

      migrationBuilder.DropForeignKey(
          name: "FK_Clients_MaritalStatuses_MaritalStatusName",
          table: "Clients");

      migrationBuilder.DropForeignKey(
          name: "FK_Clients_Nationalities_NationalityName",
          table: "Clients");

      migrationBuilder.DropIndex(
          name: "IX_Clients_IdentificationNumber",
          table: "Clients");

      migrationBuilder.DropIndex(
          name: "IX_Clients_PassportSeries_PassportNumber",
          table: "Clients");

      migrationBuilder.DeleteData(
          table: "Disabilities",
          keyColumn: "Name",
          keyValue: "None");

      migrationBuilder.AlterColumn<string>(
          name: "RegistrationCityName",
          table: "Clients",
          type: "nvarchar(250)",
          nullable: true,
          oldClrType: typeof(string),
          oldType: "nvarchar(250)");

      migrationBuilder.AlterColumn<string>(
          name: "NationalityName",
          table: "Clients",
          type: "nvarchar(250)",
          nullable: true,
          oldClrType: typeof(string),
          oldType: "nvarchar(250)");

      migrationBuilder.AlterColumn<string>(
          name: "MaritalStatusName",
          table: "Clients",
          type: "nvarchar(250)",
          nullable: true,
          oldClrType: typeof(string),
          oldType: "nvarchar(250)");

      migrationBuilder.AlterColumn<string>(
          name: "DisabilityName",
          table: "Clients",
          type: "nvarchar(250)",
          nullable: true,
          oldClrType: typeof(string),
          oldType: "nvarchar(250)");

      migrationBuilder.AlterColumn<string>(
          name: "ActualResidenceCityName",
          table: "Clients",
          type: "nvarchar(250)",
          nullable: true,
          oldClrType: typeof(string),
          oldType: "nvarchar(250)");

      migrationBuilder.InsertData(
          table: "Cities",
          column: "Name",
          values: new object[]
          {
                    "Qexpolis",
                    "Khetmore",
                    "Qribert",
                    "Mucaster",
                    "Amport",
                    "Ingdence",
                    "Streah",
                    "Ephoni",
                    "Osheles",
                    "Graepding",
                    "Zheanford",
                    "Flufield",
                    "Justin",
                    "Shixrith",
                    "Shagas",
                    "Andsas",
                    "Encedon",
                    "Ijefbridge",
                    "Dekdale",
                    "Andville",
                    "Enslens",
                    "Zhexson",
                    "Vluddon",
                    "Cluebridge",
                    "Plando",
                    "Breka",
                    "Bison",
                    "Bruusginia"
          });

      migrationBuilder.InsertData(
          table: "Nationalities",
          column: "Name",
          values: new object[]
          {
                    "Nicaraguan",
                    "New Zealander",
                    "Nepalese",
                    "Nauruan",
                    "Mozambican",
                    "Mosotho",
                    "Moroccan",
                    "Nigerian",
                    "Montserratian",
                    "Namibian",
                    "Nigerien",
                    "Palauan",
                    "North Korean",
                    "Northern Irish"
          });

      migrationBuilder.InsertData(
          table: "Nationalities",
          column: "Name",
          values: new object[]
          {
                    "Omani",
                    "Pakistani",
                    "Palestinian",
                    "Panamanian",
                    "Papua New Guinean",
                    "Paraguayan",
                    "Peruvian",
                    "Montenegrin",
                    "Niuean",
                    "Mongolian",
                    "Malagasy",
                    "Moldovan",
                    "Kyrgyz",
                    "Lao",
                    "Latvian",
                    "Lebanese",
                    "Liberian",
                    "Libyan",
                    "Lithuanian",
                    "Luxembourger",
                    "Macanese",
                    "Macedonian",
                    "Monegasque",
                    "Pitcairn Islander",
                    "Malaysian",
                    "Maldivian",
                    "Malian",
                    "Maltese",
                    "Marshallese",
                    "Martiniquais",
                    "Mauritanian",
                    "Mauritian",
                    "Mexican",
                    "Micronesian",
                    "Malawian",
                    "Portuguese",
                    "Sierra Leonean",
                    "Puerto Rican",
                    "Surinamese",
                    "Swazi",
                    "Syrian",
                    "Taiwanese"
          });

      migrationBuilder.InsertData(
          table: "Nationalities",
          column: "Name",
          values: new object[]
          {
                    "Tajik",
                    "Tanzanian",
                    "Thai",
                    "Togolese",
                    "Tongan",
                    "Trinidadian",
                    "Sudanese",
                    "Tristanian",
                    "Turkmen",
                    "Turks and Caicos Islander",
                    "Tuvaluan",
                    "Ukrainian",
                    "Uruguayan",
                    "Uzbek",
                    "Vietnamese",
                    "Vincentian",
                    "Wallisian",
                    "Yemeni",
                    "Tunisian",
                    "Prydeinig",
                    "Stateless",
                    "St Helenian",
                    "Qatari",
                    "Romanian",
                    "Russian",
                    "Rwandan",
                    "Salvadorean",
                    "Sammarinese",
                    "Samoan",
                    "Sao Tomean",
                    "Saudi Arabian",
                    "Senegalese",
                    "St Lucian",
                    "Serbian",
                    "Singaporean",
                    "Slovak",
                    "Slovenian",
                    "Solomon Islander",
                    "Somali",
                    "South African",
                    "South Korean",
                    "South Sudanese"
          });

      migrationBuilder.InsertData(
          table: "Nationalities",
          column: "Name",
          values: new object[]
          {
                    "Spanish",
                    "Sri Lankan",
                    "Kuwaiti",
                    "Kosovan",
                    "Icelandic",
                    "Kenyan",
                    "Bulgarian",
                    "Burkinan",
                    "Burmese",
                    "Burundian",
                    "Cambodian",
                    "Cameroonian",
                    "Canadian",
                    "Cape Verdean",
                    "Cayman Islander",
                    "Central African",
                    "Bruneian",
                    "Chadian",
                    "Chinese",
                    "Citizen of Antigua and Barbuda",
                    "Citizen of Bosnia and Herzegovina",
                    "Citizen of Guinea-Bissau",
                    "Citizen of Kiribati",
                    "Citizen of Seychelles",
                    "Citizen of the Dominican Republic",
                    "Citizen of Vanuatu",
                    "Colombian",
                    "Comoran",
                    "Chilean",
                    "Congolese (Congo)",
                    "British Virgin Islander",
                    "Brazilian",
                    "Afghan",
                    "Albanian",
                    "Algerian",
                    "American",
                    "Andorran",
                    "Angolan",
                    "Anguillan",
                    "Argentine",
                    "Armenian",
                    "Australian"
          });

      migrationBuilder.InsertData(
          table: "Nationalities",
          column: "Name",
          values: new object[]
          {
                    "British",
                    "Azerbaijani",
                    "Bahraini",
                    "Bangladeshi",
                    "Barbadian",
                    "Belgian",
                    "Belizean",
                    "Beninese",
                    "Bermudian",
                    "Bhutanese",
                    "Bolivian",
                    "Botswanan",
                    "Bahamian",
                    "Kittitian",
                    "Congolese (DRC)",
                    "Costa Rican",
                    "Greenlandic",
                    "Grenadian",
                    "Guamanian",
                    "Guatemalan",
                    "Guinean",
                    "Guyanese",
                    "Haitian",
                    "Honduran",
                    "Hong Konger",
                    "Hungarian",
                    "Gibraltarian",
                    "Zambian",
                    "Indonesian",
                    "Iranian",
                    "Iraqi",
                    "Irish",
                    "Israeli",
                    "Italian",
                    "Ivorian",
                    "Jamaican",
                    "Jordanian",
                    "Kazakh",
                    "Indian",
                    "Cook Islander",
                    "Ghanaian",
                    "Gabonese"
          });

      migrationBuilder.InsertData(
          table: "Nationalities",
          column: "Name",
          values: new object[]
          {
                    "Croatian",
                    "Cuban",
                    "Cymraes",
                    "Cymro",
                    "Cypriot",
                    "Danish",
                    "Djiboutian",
                    "Dominican",
                    "Dutch",
                    "East Timorese",
                    "Gambian",
                    "Ecuadorean",
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
                    "Egyptian",
                    "Zimbabwean"
          });

      migrationBuilder.AddForeignKey(
          name: "FK_Clients_Cities_ActualResidenceCityName",
          table: "Clients",
          column: "ActualResidenceCityName",
          principalTable: "Cities",
          principalColumn: "Name",
          onDelete: ReferentialAction.Restrict);

      migrationBuilder.AddForeignKey(
          name: "FK_Clients_Cities_RegistrationCityName",
          table: "Clients",
          column: "RegistrationCityName",
          principalTable: "Cities",
          principalColumn: "Name",
          onDelete: ReferentialAction.Restrict);

      migrationBuilder.AddForeignKey(
          name: "FK_Clients_Disabilities_DisabilityName",
          table: "Clients",
          column: "DisabilityName",
          principalTable: "Disabilities",
          principalColumn: "Name",
          onDelete: ReferentialAction.Restrict);

      migrationBuilder.AddForeignKey(
          name: "FK_Clients_MaritalStatuses_MaritalStatusName",
          table: "Clients",
          column: "MaritalStatusName",
          principalTable: "MaritalStatuses",
          principalColumn: "Name",
          onDelete: ReferentialAction.Restrict);

      migrationBuilder.AddForeignKey(
          name: "FK_Clients_Nationalities_NationalityName",
          table: "Clients",
          column: "NationalityName",
          principalTable: "Nationalities",
          principalColumn: "Name",
          onDelete: ReferentialAction.Restrict);
    }
  }
}
