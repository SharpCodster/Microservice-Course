using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VivaioInCloud.Catalog.Infrastructure.Migrations
{
    public partial class SeedItemTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "ItemTypes",
                columns: new[] { "Id", "CreatedAtUtc", "CreatedBy", "IsDeleted", "Name", "UpdatedAtUtc", "UpdatedBy" },
                values: new object[,]
                {
                    { "210BEC9A-B503-41CC-B95B-4DE49191175A", new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), "SEEDER", false, "alberi-ornamentali", new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "235D0B4B-5046-4759-8E7D-D60873E1F7E8", new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), "SEEDER", false, "accessori", new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "32781F4C-381A-449A-A16B-3C57690D599A", new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), "SEEDER", false, "potatura", new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "46981D42-DE4A-4084-8AAE-6DDFF896434C", new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), "SEEDER", false, "terriccio", new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "572C7BE0-BFDC-4AE9-A056-AD568DF6A4BC", new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), "SEEDER", false, "diserbante", new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "64CA104F-EB10-4539-9319-C667D1CBDFC0", new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), "SEEDER", false, "piante-da-interno", new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "67D10465-8B17-479A-9859-83D16B11DD84", new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), "SEEDER", false, "piante-da-esterno", new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "7DA220D3-70EF-424D-9BFD-BFD4D290664D", new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), "SEEDER", false, "alberi-da-frutto", new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "9CF6AB99-7A88-40B2-8D19-23868DCAFD03", new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), "SEEDER", false, "vasi", new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "A50108A3-AA1A-4ED8-AED6-500B906830C9", new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), "SEEDER", false, "prato", new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "A5475794-16F9-4C66-9E39-9E48D94941B9", new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), "SEEDER", false, "barbecue", new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "BA4A9EDE-54EB-4768-875F-36DA8A6D94BC", new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), "SEEDER", false, "cura-e-manutenzione", new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "CDCD18A8-9DF4-4224-984D-E8D0FFE2AD2B", new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), "SEEDER", false, "serre", new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "CE826748-979B-4E75-B79A-37B11E19DEDF", new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), "SEEDER", false, "gazebo", new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "D68FB54D-0369-488B-8D16-38970FF26896", new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), "SEEDER", false, "rose", new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), "SEEDER" }
                });
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: "210BEC9A-B503-41CC-B95B-4DE49191175A");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: "235D0B4B-5046-4759-8E7D-D60873E1F7E8");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: "32781F4C-381A-449A-A16B-3C57690D599A");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: "46981D42-DE4A-4084-8AAE-6DDFF896434C");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: "572C7BE0-BFDC-4AE9-A056-AD568DF6A4BC");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: "64CA104F-EB10-4539-9319-C667D1CBDFC0");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: "67D10465-8B17-479A-9859-83D16B11DD84");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: "7DA220D3-70EF-424D-9BFD-BFD4D290664D");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: "9CF6AB99-7A88-40B2-8D19-23868DCAFD03");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: "A50108A3-AA1A-4ED8-AED6-500B906830C9");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: "A5475794-16F9-4C66-9E39-9E48D94941B9");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: "BA4A9EDE-54EB-4768-875F-36DA8A6D94BC");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: "CDCD18A8-9DF4-4224-984D-E8D0FFE2AD2B");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: "CE826748-979B-4E75-B79A-37B11E19DEDF");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: "D68FB54D-0369-488B-8D16-38970FF26896");
        }
    }
}
