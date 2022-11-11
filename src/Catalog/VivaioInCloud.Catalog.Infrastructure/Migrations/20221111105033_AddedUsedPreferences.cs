using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VivaioInCloud.Catalog.Infrastructure.Migrations
{
    public partial class AddedUsedPreferences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserPreferences",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    OwnerId = table.Column<string>(type: "text", nullable: false),
                    ItemTypeId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPreferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPreferences_ItemTypes_ItemTypeId",
                        column: x => x.ItemTypeId,
                        principalSchema: "dbo",
                        principalTable: "ItemTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPreferences_ItemTypeId",
                schema: "dbo",
                table: "UserPreferences",
                column: "ItemTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPreferences",
                schema: "dbo");
        }
    }
}
