using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone_VV.Migrations
{
    public partial class UpdatedInititalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Client",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.UpdateData(
                table: "Client",
                keyColumn: "ClientID",
                keyValue: 1,
                column: "Address",
                value: "154 South Gate Blwd");

            migrationBuilder.UpdateData(
                table: "Client",
                keyColumn: "ClientID",
                keyValue: 2,
                column: "Address",
                value: "1010 White Ave");

            migrationBuilder.UpdateData(
                table: "Client",
                keyColumn: "ClientID",
                keyValue: 3,
                column: "Address",
                value: "2 Century Drive");

            migrationBuilder.UpdateData(
                table: "Client",
                keyColumn: "ClientID",
                keyValue: 4,
                column: "Address",
                value: "145 Gateway DR");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Client");
        }
    }
}
