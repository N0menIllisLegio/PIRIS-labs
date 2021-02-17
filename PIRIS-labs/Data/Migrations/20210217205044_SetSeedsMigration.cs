using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PIRIS_labs.Migrations
{
  public partial class SetSeedsMigration: Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.InsertData(
          table: "AccountPlans",
          columns: new[] { "ID", "AccountName", "AccountNumber", "AccountType" },
          values: new object[,]
          {
                    { new Guid("adcaecb8-86f8-4ef3-a57a-6ca703c28daa"), "Passive account for Individuals", "3014", 1 },
                    { new Guid("e89271c8-a70d-40b2-b07e-e844cd02ab95"), "Active account for Entities", "2400", 0 },
                    { new Guid("cc3aecab-f513-4d27-b7ff-265923741884"), "Bank cash desk account", "1010", 0 },
                    { new Guid("babf196b-1f70-4377-9275-adb49b200cc3"), "Bank Development Fund account", "7327", 1 }
          });

      migrationBuilder.InsertData(
          table: "DepositPlans",
          columns: new[] { "ID", "DayPeriod", "MainAccountPlanID", "Name", "Percent", "PercentAccountPlanID", "Revocable" },
          values: new object[,]
          {
                    { new Guid("be9ac5eb-fe7a-4388-9d25-687531f431eb"), 20, new Guid("adcaecb8-86f8-4ef3-a57a-6ca703c28daa"), "Standard", 0.01m, new Guid("adcaecb8-86f8-4ef3-a57a-6ca703c28daa"), true },
                    { new Guid("bce0f9c6-fc36-4ac6-a52d-f9103a3de885"), 40, new Guid("adcaecb8-86f8-4ef3-a57a-6ca703c28daa"), "Standard+", 0.05m, new Guid("adcaecb8-86f8-4ef3-a57a-6ca703c28daa"), false },
                    { new Guid("5ef7958f-a759-4206-9786-f2c0dcbc9304"), 100, new Guid("adcaecb8-86f8-4ef3-a57a-6ca703c28daa"), "Medium", 0.1m, new Guid("adcaecb8-86f8-4ef3-a57a-6ca703c28daa"), false },
                    { new Guid("5321574e-16f1-4b70-945a-66b650ed661b"), 220, new Guid("adcaecb8-86f8-4ef3-a57a-6ca703c28daa"), "Ultra", 0.4m, new Guid("adcaecb8-86f8-4ef3-a57a-6ca703c28daa"), true }
          });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DeleteData(
          table: "AccountPlans",
          keyColumn: "ID",
          keyValue: new Guid("babf196b-1f70-4377-9275-adb49b200cc3"));

      migrationBuilder.DeleteData(
          table: "AccountPlans",
          keyColumn: "ID",
          keyValue: new Guid("cc3aecab-f513-4d27-b7ff-265923741884"));

      migrationBuilder.DeleteData(
          table: "AccountPlans",
          keyColumn: "ID",
          keyValue: new Guid("e89271c8-a70d-40b2-b07e-e844cd02ab95"));

      migrationBuilder.DeleteData(
          table: "DepositPlans",
          keyColumn: "ID",
          keyValue: new Guid("5321574e-16f1-4b70-945a-66b650ed661b"));

      migrationBuilder.DeleteData(
          table: "DepositPlans",
          keyColumn: "ID",
          keyValue: new Guid("5ef7958f-a759-4206-9786-f2c0dcbc9304"));

      migrationBuilder.DeleteData(
          table: "DepositPlans",
          keyColumn: "ID",
          keyValue: new Guid("bce0f9c6-fc36-4ac6-a52d-f9103a3de885"));

      migrationBuilder.DeleteData(
          table: "DepositPlans",
          keyColumn: "ID",
          keyValue: new Guid("be9ac5eb-fe7a-4388-9d25-687531f431eb"));

      migrationBuilder.DeleteData(
          table: "AccountPlans",
          keyColumn: "ID",
          keyValue: new Guid("adcaecb8-86f8-4ef3-a57a-6ca703c28daa"));
    }
  }
}
