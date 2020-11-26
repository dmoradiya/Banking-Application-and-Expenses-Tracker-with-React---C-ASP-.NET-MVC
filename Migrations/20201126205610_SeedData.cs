using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone_VV.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "ClientID", "Address", "City", "DateOfBirth", "EmailAddress", "FirstName", "LastName", "Password", "PhoneNumber", "PostalCode", "Province" },
                values: new object[,]
                {
                    { 1, "154 South Gate Blwd", "Edmonton", new DateTime(1989, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "johndoe123@gmail.com", "John", "Doe", "John123!Unknown", "7804188874", "T8N3A4", "AB" },
                    { 2, "1010 White Ave", "London", new DateTime(1880, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "trevorbelmont123@gmail.com", "Trevor", "Belmont", "Draculasux@lif3", "7804442121", "Z4A2B1", "ON" },
                    { 3, "2 Century Drive", "Edmonton", new DateTime(1999, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "richardrich@gmail.com", "Richard", "Rich", "Therich123!@#", "7771115454", "T8N3E1", "AB" },
                    { 4, "145 Gateway DR", "Edmonton", new DateTime(1979, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "brokeasajoke@gmail.com", "Bruce", "Hunter", "password123", "7809198888", "T8N6Y3", "AB" }
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountID", "AccountBalance", "AccountDate", "AccountType", "Cashback", "ClientID", "IsActive" },
                values: new object[,]
                {
                    { 1, "$2189.43", new DateTime(2018, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chequing", "$10.02", 1, true },
                    { 2, "$4.00", new DateTime(2018, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chequing", "$5.80", 2, true },
                    { 3, "$77850.00", new DateTime(2018, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chequing", "$100.07", 3, true },
                    { 4, "$174.10", new DateTime(2018, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chequing", "$45.00", 4, true }
                });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "TransactionID", "AccountID", "IsTransactionActive", "TransactionCategory", "TransactionDate", "TransactionSource", "TransactionValue" },
                values: new object[,]
                {
                    { 1, 1, true, "Deposit", new DateTime(2020, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bank", "$2001.86" },
                    { 18, 4, true, "Rent/Mortgage", new DateTime(2020, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill Payment", "($800.00)" },
                    { 17, 4, true, "Deposit", new DateTime(2020, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "ATM", "$1100.32" },
                    { 16, 3, true, "Deposit", new DateTime(2020, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bank", "$22100.00" },
                    { 15, 3, true, "Deposit", new DateTime(2020, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bank", "$43750.00" },
                    { 14, 3, true, "Withdraw", new DateTime(2020, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bank", "($3000.00)" },
                    { 13, 3, true, "Deposit", new DateTime(2020, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bank", "$7500.00" },
                    { 12, 3, true, "Deposit", new DateTime(2020, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bank", "$7500.00" },
                    { 11, 2, true, "Food", new DateTime(2020, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill Payment", "($10.00)" },
                    { 10, 2, true, "Withdraw", new DateTime(2020, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "ATM", "($50.00)" },
                    { 9, 1, true, "Deposit", new DateTime(2020, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bank", "$750.00" },
                    { 8, 1, true, "Deposit", new DateTime(2020, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bank", "$320.00" },
                    { 7, 1, true, "Deposit", new DateTime(2020, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "ATM", "$110.00" },
                    { 6, 1, true, "Deposit", new DateTime(2020, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "ATM", "$430.00" },
                    { 5, 1, true, "Health", new DateTime(2020, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill Payment", "($30.00)" },
                    { 4, 1, true, "Food", new DateTime(2020, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill payment", "($71.44)" },
                    { 3, 1, true, "Other", new DateTime(2020, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill Payment", "($200.99)" },
                    { 2, 1, true, "Rent/Mortgage", new DateTime(2020, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill Payment", "($1100.00)" },
                    { 19, 4, true, "Utilities", new DateTime(2020, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill Payment", "($41.99)" },
                    { 20, 4, true, "Internet", new DateTime(2020, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill Payment", "($84.23)" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "AccountID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "AccountID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "AccountID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "AccountID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "ClientID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "ClientID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "ClientID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "ClientID",
                keyValue: 4);
        }
    }
}
