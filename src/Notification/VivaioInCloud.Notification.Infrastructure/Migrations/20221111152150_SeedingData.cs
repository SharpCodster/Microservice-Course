using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VivaioInCloud.Notification.Infrastructure.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Contacts",
                columns: new[] { "Id", "CreatedAtUtc", "CreatedBy", "Email", "IsDeleted", "Name", "Surname", "UpdatedAtUtc", "UpdatedBy" },
                values: new object[,]
                {
                    { "13017f42-1786-4d94-9702-6e687f578a47", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER", "user1@microsoft.com", false, "John", "Doe", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "7a63bbf1-4346-4aa7-a273-358f66224527", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER", "user2@microsoft.com", false, "Paul", "Leen", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "UserNotifications",
                columns: new[] { "Id", "CreatedAtUtc", "CreatedBy", "Delivered", "IsDeleted", "Message", "UpdatedAtUtc", "UpdatedBy", "UserId" },
                values: new object[,]
                {
                    { "6cf186a7-4914-4dcc-b676-c45c998c3c71", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER", true, false, "Test Message 2", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER", "7a63bbf1-4346-4aa7-a273-358f66224527" },
                    { "88ecfb97-e769-478c-ab43-6617a616563b", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER", true, false, "Test message", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER", "13017f42-1786-4d94-9702-6e687f578a47" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "UserPreferences",
                columns: new[] { "Id", "TypeId", "UserId" },
                values: new object[,]
                {
                    { "33d25f4c-2e88-4a7c-9bd0-0498332e9a15", "210bec9a-b503-41cc-b95b-4de49191175a", "7a63bbf1-4346-4aa7-a273-358f66224527" },
                    { "4107308d-4bd2-44cf-824f-f8dafe02bffa", "64ca104f-eb10-4539-9319-c667d1cbdfc0", "13017f42-1786-4d94-9702-6e687f578a47" },
                    { "4bdc9d4f-20ed-4613-91e8-c7d7081aff9a", "d68fb54d-0369-488b-8d16-38970ff26896", "7a63bbf1-4346-4aa7-a273-358f66224527" },
                    { "58ea9fc4-1c83-448c-879a-34eda5bda428", "ce826748-979b-4e75-b79a-37b11e19dedf", "7a63bbf1-4346-4aa7-a273-358f66224527" },
                    { "611543e5-c9fa-4aa5-a8e9-5329aa49e28d", "cdcd18a8-9df4-4224-984d-e8d0ffe2ad2b", "7a63bbf1-4346-4aa7-a273-358f66224527" },
                    { "856f98a8-f0c8-4299-9e44-b083595470de", "a5475794-16f9-4c66-9e39-9e48d94941b9", "13017f42-1786-4d94-9702-6e687f578a47" },
                    { "9598fc44-35ea-4cc9-8740-5982d5b2192a", "64ca104f-eb10-4539-9319-c667d1cbdfc0", "13017f42-1786-4d94-9702-6e687f578a47" },
                    { "9cfad8e0-84e8-47db-8d43-3f025eebfa74", "572c7be0-bfdc-4ae9-a056-ad568df6a4bc", "7a63bbf1-4346-4aa7-a273-358f66224527" },
                    { "9d02f944-b1e3-41e8-89c0-e6507be198c2", "235d0b4b-5046-4759-8e7d-d60873e1f7e8", "7a63bbf1-4346-4aa7-a273-358f66224527" },
                    { "a8258483-4717-40c2-b669-4d1167f54c5c", "a50108a3-aa1a-4ed8-aed6-500b906830c9", "7a63bbf1-4346-4aa7-a273-358f66224527" },
                    { "b9456542-7e0a-4126-96c1-bc894f708541", "ba4a9ede-54eb-4768-875f-36da8a6d94bc", "7a63bbf1-4346-4aa7-a273-358f66224527" },
                    { "bdb88ebe-9af2-43c9-b873-e9ce4cc400a3", "9cf6ab99-7a88-40b2-8d19-23868dcafd03", "7a63bbf1-4346-4aa7-a273-358f66224527" },
                    { "c2b74088-7458-4a68-a092-a22a2323cce0", "7da220d3-70ef-424d-9bfd-bfd4d290664d", "7a63bbf1-4346-4aa7-a273-358f66224527" },
                    { "c3ee743d-d8c1-4e2f-b85a-65b97defb885", "67d10465-8b17-479a-9859-83d16b11dd84", "7a63bbf1-4346-4aa7-a273-358f66224527" },
                    { "ef1e8568-48b8-4eb4-802b-ebb270185fef", "46981d42-de4a-4084-8aae-6ddff896434c", "7a63bbf1-4346-4aa7-a273-358f66224527" },
                    { "f11f51b1-33b6-49fe-a20e-a959221d7f5f", "32781f4c-381a-449a-a16b-3c57690d599a", "7a63bbf1-4346-4aa7-a273-358f66224527" },
                    { "fc73e8d5-3f06-40e8-88a7-d10a4c7e22c5", "a5475794-16f9-4c66-9e39-9e48d94941b9", "7a63bbf1-4346-4aa7-a273-358f66224527" },
                    { "fce90719-cae6-4a1f-a3ad-e29e3aee2442", "64ca104f-eb10-4539-9319-c667d1cbdfc0", "7a63bbf1-4346-4aa7-a273-358f66224527" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserNotifications",
                keyColumn: "Id",
                keyValue: "6cf186a7-4914-4dcc-b676-c45c998c3c71");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserNotifications",
                keyColumn: "Id",
                keyValue: "88ecfb97-e769-478c-ab43-6617a616563b");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: "33d25f4c-2e88-4a7c-9bd0-0498332e9a15");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: "4107308d-4bd2-44cf-824f-f8dafe02bffa");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: "4bdc9d4f-20ed-4613-91e8-c7d7081aff9a");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: "58ea9fc4-1c83-448c-879a-34eda5bda428");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: "611543e5-c9fa-4aa5-a8e9-5329aa49e28d");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: "856f98a8-f0c8-4299-9e44-b083595470de");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: "9598fc44-35ea-4cc9-8740-5982d5b2192a");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: "9cfad8e0-84e8-47db-8d43-3f025eebfa74");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: "9d02f944-b1e3-41e8-89c0-e6507be198c2");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: "a8258483-4717-40c2-b669-4d1167f54c5c");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: "b9456542-7e0a-4126-96c1-bc894f708541");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: "bdb88ebe-9af2-43c9-b873-e9ce4cc400a3");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: "c2b74088-7458-4a68-a092-a22a2323cce0");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: "c3ee743d-d8c1-4e2f-b85a-65b97defb885");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: "ef1e8568-48b8-4eb4-802b-ebb270185fef");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: "f11f51b1-33b6-49fe-a20e-a959221d7f5f");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: "fc73e8d5-3f06-40e8-88a7-d10a4c7e22c5");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: "fce90719-cae6-4a1f-a3ad-e29e3aee2442");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Contacts",
                keyColumn: "Id",
                keyValue: "13017f42-1786-4d94-9702-6e687f578a47");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Contacts",
                keyColumn: "Id",
                keyValue: "7a63bbf1-4346-4aa7-a273-358f66224527");
        }
    }
}
