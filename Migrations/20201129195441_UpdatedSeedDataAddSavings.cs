using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone_VV.Migrations
{
    public partial class UpdatedSeedDataAddSavings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountID",
                keyValue: 2,
                columns: new[] { "AccountBalance", "AccountDate", "AccountType", "Cashback", "ClientID" },
                values: new object[] { 20550.43, new DateTime(2018, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Savings", 23.579999999999998, 1 });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountID",
                keyValue: 3,
                columns: new[] { "AccountBalance", "AccountDate", "Cashback", "ClientID" },
                values: new object[] { 144.0, new DateTime(2018, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.7999999999999998, 2 });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountID",
                keyValue: 4,
                columns: new[] { "AccountBalance", "AccountDate", "Cashback", "ClientID" },
                values: new object[] { 77850.0, new DateTime(2018, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 100.06999999999999, 3 });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountID", "AccountBalance", "AccountDate", "AccountType", "Cashback", "ClientID", "IsActive" },
                values: new object[] { 5, 174.09999999999999, new DateTime(2018, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chequing", 45.0, 4, true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "AccountID",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountID",
                keyValue: 2,
                columns: new[] { "AccountBalance", "AccountDate", "AccountType", "Cashback", "ClientID" },
                values: new object[] { 144.0, new DateTime(2018, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chequing", 5.7999999999999998, 2 });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountID",
                keyValue: 3,
                columns: new[] { "AccountBalance", "AccountDate", "Cashback", "ClientID" },
                values: new object[] { 77850.0, new DateTime(2018, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 100.06999999999999, 3 });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "AccountID",
                keyValue: 4,
                columns: new[] { "AccountBalance", "AccountDate", "Cashback", "ClientID" },
                values: new object[] { 174.09999999999999, new DateTime(2018, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 45.0, 4 });
        }
    }
}
