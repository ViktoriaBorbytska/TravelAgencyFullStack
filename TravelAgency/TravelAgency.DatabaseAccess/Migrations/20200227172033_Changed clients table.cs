using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAgency.DatabaseAccess.Migrations
{
    public partial class Changedclientstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Clients",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Clients");
        }
    }
}
