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
                    PhoneNumber = table.Column<long>(type: "bigint(15)", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    LastName = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
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
                    AccountType = table.Column<int>(type: "int(2)", nullable: false),
                    AccountBalance = table.Column<float>(type: "float(10)", nullable: false),
                    AccountInterest = table.Column<float>(type: "float(10)", nullable: false),
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
                    TransactionValue = table.Column<float>(type: "float(10)", nullable: false),
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
                columns: new[] { "ClientID", "City", "DateOfBirth", "EmailAddress", "FirstName", "LastName", "Password", "PhoneNumber", "PostalCode", "Province" },
                values: new object[,]
                {
                    { 1, "Edmonton", new DateTime(1989, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "johndoe123@gmail.com", "John", "Doe", "john123", 7804188874L, "T8N3A4", "AB" },
                    { 2, "London", new DateTime(1880, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "trevorbelmont123@gmail.com", "Trevor", "Belmont", "draculasux", 7804442121L, "Z4A2B1", "ON" },
                    { 3, "Edmonton", new DateTime(1999, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "richardrich@gmail.com", "Richard", "Rich", "rich123", 7771115454L, "T8N3E1", "AB" },
                    { 4, "Edmonton", new DateTime(1979, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "brokeasajoke@gmail.com", "Bruce", "Hunter", "broke123", 7809198888L, "T8N6Y3", "AB" }
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountID", "AccountBalance", "AccountInterest", "AccountType", "ClientID", "IsActive" },
                values: new object[,]
                {
                    { 1, 5003.23f, 0f, 0, 1, true },
                    { 2, 40000.43f, 0.03f, 1, 1, true },
                    { 3, 3.75f, 0f, 0, 2, true },
                    { 4, 75552.23f, 0f, 0, 3, true },
                    { 5, 814751f, 0.03f, 1, 3, true },
                    { 6, 753.23f, 0f, 0, 4, true }
                });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "TransactionID", "AccountID", "TransactionCategory", "TransactionDate", "TransactionSource", "TransactionValue" },
                values: new object[,]
                {
                    { 1, 1, "Income", new DateTime(2020, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Allgood Engineering Inc.", 2001.86f },
                    { 18, 6, "Expense_Rent", new DateTime(2020, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Axion Rental Agency", -800f },
                    { 17, 6, "Income", new DateTime(2020, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seven Eleven", 1100.32f },
                    { 16, 5, "Income_Investments", new DateTime(2020, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gold Hand Investments Inc.", 43000f },
                    { 15, 5, "Income_Investments", new DateTime(2020, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gold Hand Investments Inc.", 43000f },
                    { 14, 4, "Expense_Recreation", new DateTime(2020, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Central Avionics", 3000f },
                    { 13, 4, "Income", new DateTime(2020, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gold Hand Investments Inc.", 7500f },
                    { 12, 4, "Income", new DateTime(2020, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gold Hand Investments Inc.", 7500f },
                    { 11, 3, "Expense_Food", new DateTime(2020, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wallachia Market", -1f },
                    { 10, 3, "Income", new DateTime(2020, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bank of Wallachia", 4f },
                    { 9, 2, "Income_Investments", new DateTime(2020, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gold Hand Investments Inc.", 750f },
                    { 8, 2, "Income_Investments", new DateTime(2020, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gold Hand Investments Inc.", 750f },
                    { 7, 2, "Income_Investments", new DateTime(2020, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gold Hand Investments Inc.", 750f },
                    { 6, 2, "Income_Investments", new DateTime(2020, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gold Hand Investments Inc.", 750f },
                    { 5, 1, "Expense_Health", new DateTime(2020, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ironman Gym Membership Fee", -30f },
                    { 4, 1, "Expense_Groceries", new DateTime(2020, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Superstore", -71.44f },
                    { 3, 1, "Expense_Vehicle", new DateTime(2020, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jonathan's Car Repairs", -200.99f },
                    { 2, 1, "Expense_Rent", new DateTime(2020, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Axion Rental Agency", -1100f },
                    { 19, 6, "Expense_Vehicle", new DateTime(2020, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "St. Albert Transit", -41.99f },
                    { 20, 6, "Expense_Groceries", new DateTime(2020, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Superstore", -84.23f }
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
