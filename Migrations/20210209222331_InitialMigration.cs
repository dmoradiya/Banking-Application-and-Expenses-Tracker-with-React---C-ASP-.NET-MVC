using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone_VV.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAddress = table.Column<string>(type: "varchar(100)", nullable: false),
                    Password = table.Column<string>(type: "varchar(100)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "char(15)", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    Address = table.Column<string>(type: "varchar(100)", nullable: false),
                    City = table.Column<string>(type: "varchar(100)", nullable: false),
                    Province = table.Column<string>(type: "varchar(50)", nullable: false),
                    PostalCode = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientID);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    AccountType = table.Column<string>(type: "varchar(30)", nullable: false),
                    AccountBalance = table.Column<double>(type: "float", nullable: false),
                    Cashback = table.Column<double>(type: "float", nullable: false),
                    AccountDate = table.Column<DateTime>(type: "date", nullable: false),
                    IsActive = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountID);
                    table.ForeignKey(
                        name: "FK_Account_Client",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    TransactionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    TransactionSource = table.Column<string>(type: "varchar(50)", nullable: false),
                    TransactionCategory = table.Column<string>(type: "varchar(30)", nullable: false),
                    TransactionValue = table.Column<double>(type: "float", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "date", nullable: false),
                    IsTransactionActive = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_Transaction_Account",
                        column: x => x.AccountID,
                        principalTable: "Account",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "ClientID", "Address", "City", "DateOfBirth", "EmailAddress", "FirstName", "LastName", "Password", "PhoneNumber", "PostalCode", "Province" },
                values: new object[,]
                {
                    { 1, "154 South Gate Blwd", "Edmonton", new DateTime(1989, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "johndoe123@gmail.com", "John", "Doe", "$2a$11$VA8lRhjgEsQvSrmoeWzyo.2U3j.LTkqpxcYwJZgf4aX5zGMifwrde", "7804188874", "T8N3A4", "AB" },
                    { 2, "1010 White Ave", "London", new DateTime(1880, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "trevorbelmont123@gmail.com", "Trevor", "Belmont", "$2a$11$95Aao/mZ8sq7dimAwqRoS.ZWdK0Id7X6cqigHuz9kMl./rGbPzhKy", "7804442121", "Z4A2B1", "ON" },
                    { 3, "2 Century Drive", "Edmonton", new DateTime(1999, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "richardrich@gmail.com", "Richard", "Rich", "$2a$11$vzGYLnnCNrh1ua6.fKhyBuCrpaPKbkC9kMd49Xh.n7EuZtZBmrUpq", "7771115454", "T8N3E1", "AB" },
                    { 4, "145 Gateway DR", "Edmonton", new DateTime(1979, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "brokeasajoke@gmail.com", "Bruce", "Hunter", "$2a$11$ROC9MfwZPA1V2OflUsXNsusWjyMyWWKymHI4Spi2fMqFYuIH1Aivm", "7809198888", "T8N6Y3", "AB" }
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountID", "AccountBalance", "AccountDate", "AccountType", "Cashback", "ClientID", "IsActive" },
                values: new object[,]
                {
                    { 1, 2189.4299999999998, new DateTime(2018, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chequing", 10.02, 1, (byte)1 },
                    { 2, 20550.43, new DateTime(2018, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Savings", 23.579999999999998, 1, (byte)1 },
                    { 3, 144.0, new DateTime(2018, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chequing", 5.7999999999999998, 2, (byte)1 },
                    { 4, 77850.0, new DateTime(2018, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chequing", 100.06999999999999, 3, (byte)1 },
                    { 5, 174.09999999999999, new DateTime(2018, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chequing", 45.0, 4, (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "TransactionID", "AccountID", "IsTransactionActive", "TransactionCategory", "TransactionDate", "TransactionSource", "TransactionValue" },
                values: new object[,]
                {
                    { 1, 1, (byte)1, "Deposit", new DateTime(2020, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bank", 2001.8599999999999 },
                    { 22, 4, (byte)1, "Food", new DateTime(2020, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill Payment", 750.0 },
                    { 23, 4, (byte)1, "Transportation", new DateTime(2020, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill Payment", 750.0 },
                    { 24, 4, (byte)1, "Utilities", new DateTime(2020, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill Payment", 500.0 },
                    { 25, 4, (byte)1, "Debt Payments", new DateTime(2020, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill Payment", 500.0 },
                    { 26, 4, (byte)1, "Savings", new DateTime(2020, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill Payment", 250.0 },
                    { 27, 4, (byte)1, "Clothing", new DateTime(2020, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill Payment", 125.0 },
                    { 28, 4, (byte)1, "Health", new DateTime(2020, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill Payment", 125.0 },
                    { 21, 4, (byte)1, "Housing", new DateTime(2020, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill Payment", 1750.0 },
                    { 29, 4, (byte)1, "Other", new DateTime(2020, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill Payment", 250.0 },
                    { 31, 4, (byte)1, "Housing", new DateTime(2020, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill Payment", 1750.0 },
                    { 32, 4, (byte)1, "Food", new DateTime(2020, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill Payment", 850.0 },
                    { 33, 4, (byte)1, "Transportation", new DateTime(2020, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill Payment", 900.0 },
                    { 34, 4, (byte)1, "Utilities", new DateTime(2020, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill Payment", 500.0 },
                    { 35, 4, (byte)1, "Debt Payments", new DateTime(2020, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill Payment", 400.0 },
                    { 36, 4, (byte)1, "Savings", new DateTime(2020, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill Payment", 250.0 },
                    { 37, 4, (byte)1, "Clothing", new DateTime(2020, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill Payment", 110.0 },
                    { 30, 4, (byte)1, "Internet", new DateTime(2020, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill Payment", 60.0 },
                    { 38, 4, (byte)1, "Health", new DateTime(2020, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill Payment", 125.0 },
                    { 20, 4, (byte)1, "Internet", new DateTime(2020, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill Payment", 84.230000000000004 },
                    { 18, 4, (byte)1, "Housing", new DateTime(2020, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill Payment", 800.0 },
                    { 2, 1, (byte)1, "Housing", new DateTime(2020, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill Payment", 1100.0 },
                    { 3, 1, (byte)1, "Other", new DateTime(2020, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill Payment", 200.0 },
                    { 4, 1, (byte)1, "Food", new DateTime(2020, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill Payment", 50.0 },
                    { 5, 1, (byte)1, "Health", new DateTime(2020, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill Payment", 30.0 },
                    { 6, 1, (byte)1, "Deposit", new DateTime(2020, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "ATM", 430.0 },
                    { 7, 1, (byte)1, "Deposit", new DateTime(2020, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "ATM", 110.0 },
                    { 8, 1, (byte)1, "Deposit", new DateTime(2020, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bank", 320.0 },
                    { 19, 4, (byte)1, "Utilities", new DateTime(2020, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill Payment", 41.990000000000002 },
                    { 9, 1, (byte)1, "Deposit", new DateTime(2020, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bank", 750.0 },
                    { 11, 2, (byte)1, "Food", new DateTime(2020, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill Payment", 10.0 },
                    { 12, 3, (byte)1, "Deposit", new DateTime(2020, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bank", 7500.0 },
                    { 13, 3, (byte)1, "Deposit", new DateTime(2020, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bank", 7500.0 },
                    { 14, 3, (byte)1, "Withdraw", new DateTime(2020, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bank", 3000.0 },
                    { 15, 3, (byte)1, "Deposit", new DateTime(2020, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bank", 43750.0 },
                    { 16, 3, (byte)1, "Deposit", new DateTime(2020, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bank", 22100.0 },
                    { 17, 4, (byte)1, "Deposit", new DateTime(2020, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "ATM", 1100.3199999999999 },
                    { 10, 2, (byte)1, "Withdraw", new DateTime(2020, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "ATM", 50.0 },
                    { 39, 4, (byte)1, "Other", new DateTime(2020, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill Payment", 250.0 }
                });

            migrationBuilder.CreateIndex(
                name: "FK_Account_Client",
                table: "Account",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "FK_Transaction_Account",
                table: "Transaction",
                column: "AccountID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
