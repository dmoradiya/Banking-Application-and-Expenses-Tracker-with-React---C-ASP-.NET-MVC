using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone_VV.Migrations
{
    public partial class EncryptedPasswords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Client",
                keyColumn: "ClientID",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$VA8lRhjgEsQvSrmoeWzyo.2U3j.LTkqpxcYwJZgf4aX5zGMifwrde");

            migrationBuilder.UpdateData(
                table: "Client",
                keyColumn: "ClientID",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$95Aao/mZ8sq7dimAwqRoS.ZWdK0Id7X6cqigHuz9kMl./rGbPzhKy");

            migrationBuilder.UpdateData(
                table: "Client",
                keyColumn: "ClientID",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$vzGYLnnCNrh1ua6.fKhyBuCrpaPKbkC9kMd49Xh.n7EuZtZBmrUpq");

            migrationBuilder.UpdateData(
                table: "Client",
                keyColumn: "ClientID",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$ROC9MfwZPA1V2OflUsXNsusWjyMyWWKymHI4Spi2fMqFYuIH1Aivm");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Client",
                keyColumn: "ClientID",
                keyValue: 1,
                column: "Password",
                value: "John123!Unknown");

            migrationBuilder.UpdateData(
                table: "Client",
                keyColumn: "ClientID",
                keyValue: 2,
                column: "Password",
                value: "Draculasux@lif3");

            migrationBuilder.UpdateData(
                table: "Client",
                keyColumn: "ClientID",
                keyValue: 3,
                column: "Password",
                value: "Therich123!@#");

            migrationBuilder.UpdateData(
                table: "Client",
                keyColumn: "ClientID",
                keyValue: 4,
                column: "Password",
                value: "password123@JOKE");
        }
    }
}
