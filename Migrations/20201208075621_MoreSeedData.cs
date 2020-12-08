using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone_VV.Migrations
{
    public partial class MoreSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "TransactionID", "AccountID", "IsTransactionActive", "TransactionCategory", "TransactionDate", "TransactionSource", "TransactionValue" },
                values: new object[,]
                {
                    { 21, 4, true, "Housing", new DateTime(2020, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill Payment", 1750.0 },
                    { 22, 4, true, "Food", new DateTime(2020, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill Payment", 750.0 },
                    { 23, 4, true, "Transportation", new DateTime(2020, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill Payment", 750.0 },
                    { 24, 4, true, "Utilities", new DateTime(2020, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill Payment", 500.0 },
                    { 25, 4, true, "Debt Payments", new DateTime(2020, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill Payment", 500.0 },
                    { 26, 4, true, "Savings", new DateTime(2020, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill Payment", 250.0 },
                    { 27, 4, true, "Clothing", new DateTime(2020, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill Payment", 125.0 },
                    { 28, 4, true, "Health", new DateTime(2020, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill Payment", 125.0 },
                    { 29, 4, true, "Other", new DateTime(2020, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill Payment", 250.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 29);
        }
    }
}
