using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VivaioInCloud.Identity.Infrastructure.Migrations
{
    public partial class AddedNameSurname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "ApplicationUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                schema: "dbo",
                table: "ApplicationUsers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                schema: "dbo",
                table: "ApplicationUsers");

            migrationBuilder.DropColumn(
                name: "Surname",
                schema: "dbo",
                table: "ApplicationUsers");
        }
    }
}
