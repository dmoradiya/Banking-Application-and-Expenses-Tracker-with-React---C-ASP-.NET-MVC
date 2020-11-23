using System;
using Microsoft.EntityFrameworkCore.Metadata;
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
                    ClientID = table.Column<int>(type: "int(10)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmailAddress = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    Password = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    PhoneNumber = table.Column<string>(type: "char(15)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    FirstName = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    LastName = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    Address = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    City = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    Province = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    PostalCode = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientID);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountID = table.Column<int>(type: "int(10)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClientID = table.Column<int>(type: "int(10)", nullable: false),
                    AccountType = table.Column<string>(type: "varchar(30)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    AccountBalance = table.Column<double>(type: "double(15,2)", nullable: false),
                    AccountInterest = table.Column<double>(type: "double(10,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bool", nullable: false)
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
                    TransactionID = table.Column<int>(type: "int(10)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AccountID = table.Column<int>(type: "int(10)", nullable: false),
                    TransactionSource = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    TransactionCategory = table.Column<string>(type: "varchar(30)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    TransactionValue = table.Column<double>(type: "double(10,2)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "date", nullable: false)
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
                    { 1, "154 South Gate Blwd", "Edmonton", new DateTime(1989, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "johndoe123@gmail.com", "John", "Doe", "John123!Unknown", "7804188874", "T8N3A4", "AB" },
                    { 2, "1010 White Ave", "London", new DateTime(1880, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "trevorbelmont123@gmail.com", "Trevor", "Belmont", "Draculasux@lif3", "7804442121", "Z4A2B1", "ON" },
                    { 3, "2 Century Drive", "Edmonton", new DateTime(1999, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "richardrich@gmail.com", "Richard", "Rich", "Therich123!@#", "7771115454", "T8N3E1", "AB" },
                    { 4, "145 Gateway DR", "Edmonton", new DateTime(1979, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "brokeasajoke@gmail.com", "Bruce", "Hunter", "password123", "7809198888", "T8N6Y3", "AB" }
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountID", "AccountBalance", "AccountInterest", "AccountType", "ClientID", "IsActive" },
                values: new object[,]
                {
                    { 1, 2189.4299999999998, 0.02, "Chequing", 1, true },
                    { 2, 4.0, 0.0, "Chequing", 2, true },
                    { 3, 77850.0, 0.070000000000000007, "Chequing", 3, true },
                    { 4, 174.09999999999999, 0.01, "Chequing", 4, true }
                });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "TransactionID", "AccountID", "TransactionCategory", "TransactionDate", "TransactionSource", "TransactionValue" },
                values: new object[,]
                {
                    { 1, 1, "Income", new DateTime(2020, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Allgood Engineering Inc.", 2001.8599999999999 },
                    { 18, 4, "Expense_Rent", new DateTime(2020, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Axion Rental Agency", -800.0 },
                    { 17, 4, "Income", new DateTime(2020, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seven Eleven", 1100.3199999999999 },
                    { 16, 3, "Income_Investments", new DateTime(2020, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gold Hand Investments Inc.", 22100.0 },
                    { 15, 3, "Income_Investments", new DateTime(2020, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gold Hand Investments Inc.", 43750.0 },
                    { 14, 3, "Expense_Recreation", new DateTime(2020, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Central Avionics", -3000.0 },
                    { 13, 3, "Income", new DateTime(2020, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gold Hand Investments Inc.", 7500.0 },
                    { 12, 3, "Income", new DateTime(2020, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gold Hand Investments Inc.", 7500.0 },
                    { 11, 2, "Expense_Food", new DateTime(2020, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wallachia Market", -1.0 },
                    { 10, 2, "Income", new DateTime(2020, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bank of Wallachia", 5.0 },
                    { 9, 1, "Income_Investments", new DateTime(2020, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gold Hand Investments Inc.", 750.0 },
                    { 8, 1, "Income_Investments", new DateTime(2020, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gold Hand Investments Inc.", 320.0 },
                    { 7, 1, "Income_Investments", new DateTime(2020, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gold Hand Investments Inc.", 110.0 },
                    { 6, 1, "Income_Investments", new DateTime(2020, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gold Hand Investments Inc.", 430.0 },
                    { 5, 1, "Expense_Health", new DateTime(2020, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ironman Gym Membership Fee", -30.0 },
                    { 4, 1, "Expense_Groceries", new DateTime(2020, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Superstore", -71.439999999999998 },
                    { 3, 1, "Expense_Vehicle", new DateTime(2020, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jonathan's Car Repairs", -200.99000000000001 },
                    { 2, 1, "Expense_Rent", new DateTime(2020, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Axion Rental Agency", -1100.0 },
                    { 19, 4, "Expense_Vehicle", new DateTime(2020, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "St. Albert Transit", -41.990000000000002 },
                    { 20, 4, "Expense_Groceries", new DateTime(2020, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Superstore", -84.230000000000004 }
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
