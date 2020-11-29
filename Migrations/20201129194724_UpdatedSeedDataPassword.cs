using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone_VV.Migrations
{
    public partial class UpdatedSeedDataPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Client",
                keyColumn: "ClientID",
                keyValue: 4,
                column: "Password",
                value: "password123@JOKE");

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 2,
                column: "TransactionCategory",
                value: "Rent");

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 3,
                column: "TransactionValue",
                value: 200.0);

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 4,
                column: "TransactionValue",
                value: 50.0);

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 18,
                column: "TransactionCategory",
                value: "Rent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Client",
                keyColumn: "ClientID",
                keyValue: 4,
                column: "Password",
                value: "password123");

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 2,
                column: "TransactionCategory",
                value: "Rent/Mortgage");

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 3,
                column: "TransactionValue",
                value: 200.99000000000001);

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 4,
                column: "TransactionValue",
                value: 71.439999999999998);

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 18,
                column: "TransactionCategory",
                value: "Rent/Mortgage");
        }
    }
}
