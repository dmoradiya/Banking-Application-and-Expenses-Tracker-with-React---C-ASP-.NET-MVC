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
