using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone_VV.Migrations
{
    public partial class AddedIsTransactionActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsTransactionActive",
                table: "Transaction",
                type: "bool",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 1,
                column: "IsTransactionActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 2,
                column: "IsTransactionActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 3,
                column: "IsTransactionActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 4,
                column: "IsTransactionActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 5,
                column: "IsTransactionActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 6,
                column: "IsTransactionActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 7,
                column: "IsTransactionActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 8,
                column: "IsTransactionActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 9,
                column: "IsTransactionActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 10,
                column: "IsTransactionActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 11,
                column: "IsTransactionActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 12,
                column: "IsTransactionActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 13,
                column: "IsTransactionActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 14,
                column: "IsTransactionActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 15,
                column: "IsTransactionActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 16,
                column: "IsTransactionActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 17,
                column: "IsTransactionActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 18,
                column: "IsTransactionActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 19,
                column: "IsTransactionActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "TransactionID",
                keyValue: 20,
                column: "IsTransactionActive",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTransactionActive",
                table: "Transaction");
        }
    }
}
