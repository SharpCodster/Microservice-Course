using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VivaioInCloud.Catalog.Infrastructure.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "ItemTypes",
                columns: new[] { "Id", "CreatedAtUtc", "CreatedBy", "IsDeleted", "Name", "UpdatedAtUtc", "UpdatedBy" },
                values: new object[,]
                {
                    { "210bec9a-b503-41cc-b95b-4de49191175a", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER", false, "alberi-ornamentali", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "235d0b4b-5046-4759-8e7d-d60873e1f7e8", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER", false, "accessori", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "32781f4c-381a-449a-a16b-3c57690d599a", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER", false, "potatura", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "46981d42-de4a-4084-8aae-6ddff896434c", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER", false, "terriccio", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "572c7be0-bfdc-4ae9-a056-ad568df6a4bc", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER", false, "diserbante", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "64ca104f-eb10-4539-9319-c667d1cbdfc0", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER", false, "piante-da-interno", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "67d10465-8b17-479a-9859-83d16b11dd84", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER", false, "piante-da-esterno", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "7da220d3-70ef-424d-9bfd-bfd4d290664d", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER", false, "alberi-da-frutto", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "9cf6ab99-7a88-40b2-8d19-23868dcafd03", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER", false, "vasi", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "a50108a3-aa1a-4ed8-aed6-500b906830c9", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER", false, "prato", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "a5475794-16f9-4c66-9e39-9e48d94941b9", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER", false, "barbecue", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "ba4a9ede-54eb-4768-875f-36da8a6d94bc", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER", false, "cura-e-manutenzione", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "cdcd18a8-9df4-4224-984d-e8d0ffe2ad2b", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER", false, "serre", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "ce826748-979b-4e75-b79a-37b11e19dedf", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER", false, "gazebo", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "d68fb54d-0369-488b-8d16-38970ff26896", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER", false, "rose", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "CatalogItems",
                columns: new[] { "Id", "CategoryId", "CreatedAtUtc", "CreatedBy", "Description", "IsDeleted", "Title", "UpdatedAtUtc", "UpdatedBy" },
                values: new object[,]
                {
                    { "188ad023-a2d4-4874-b84a-12a528e35073", "572c7be0-bfdc-4ae9-a056-ad568df6a4bc", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER", "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", false, "Kill 'Em All", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "18cc9a4e-5b6c-4d9f-bd97-82b660d83f81", "7da220d3-70ef-424d-9bfd-bfd4d290664d", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER", "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", false, "Banano", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "23b121b4-60f7-4bd1-acd3-d9d9ac639132", "cdcd18a8-9df4-4224-984d-e8d0ffe2ad2b", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER", "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", false, "Piccola", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "281407cb-0008-43fc-ac68-4f924b6edaa8", "64ca104f-eb10-4539-9319-c667d1cbdfc0", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER", "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", false, "Orchidea", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "314011b0-57c8-458d-8267-fe93549d01fb", "7da220d3-70ef-424d-9bfd-bfd4d290664d", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER", "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", false, "Avocado", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "315ffca6-1e96-4bc9-bbdb-85c1abeff49f", "a5475794-16f9-4c66-9e39-9e48d94941b9", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER", "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", false, "Caverman", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "31623bc9-5c07-48df-86d2-84f0b592d823", "a50108a3-aa1a-4ed8-aed6-500b906830c9", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER", "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", false, "Bello Verde", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "39be91a5-0f25-4fc7-869a-6225f89d8764", "46981d42-de4a-4084-8aae-6ddff896434c", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER", "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", false, "Letame Buono", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "3c375fe9-3625-4ffd-8693-21bdc963451d", "a5475794-16f9-4c66-9e39-9e48d94941b9", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER", "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", false, "Master Griller", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "3c9eb92e-d41e-474e-98e2-c3b529a28850", "64ca104f-eb10-4539-9319-c667d1cbdfc0", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER", "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", false, "Mangia Fumo", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "41c8c8d9-ee66-4bdb-9e41-f40cc24bf653", "210bec9a-b503-41cc-b95b-4de49191175a", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER", "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", false, "Cipresso", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "4ebeb1b3-85e2-4715-b0b4-5f6a111be9f7", "64ca104f-eb10-4539-9319-c667d1cbdfc0", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER", "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", false, "Carnivora", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "51f52191-a956-4dfe-9dca-858270681a2d", "7da220d3-70ef-424d-9bfd-bfd4d290664d", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER", "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", false, "Pero", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "a36f7001-25ca-4a8e-9206-7f0580007fcc", "210bec9a-b503-41cc-b95b-4de49191175a", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER", "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", false, "Baobab", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "ac191fca-d358-46f9-ae17-28dfc9759566", "cdcd18a8-9df4-4224-984d-e8d0ffe2ad2b", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER", "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", false, "Media", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "b40b820d-f2f4-47c2-8213-c15f0c3346db", "64ca104f-eb10-4539-9319-c667d1cbdfc0", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER", "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", false, "Pianta Carnivora", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "b4b3f08e-8c41-49b6-9767-b606b369fc77", "7da220d3-70ef-424d-9bfd-bfd4d290664d", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER", "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", false, "Pesco", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "c54b5a2b-a3de-485c-b4da-98ca35ac3c4e", "235d0b4b-5046-4759-8e7d-d60873e1f7e8", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER", "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", false, "Guanti", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "e9581aba-cbde-4dbc-a0c4-51ff798dee11", "cdcd18a8-9df4-4224-984d-e8d0ffe2ad2b", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER", "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", false, "Grande", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "ec4948f9-3892-4371-a460-a877007d80c1", "64ca104f-eb10-4539-9319-c667d1cbdfc0", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER", "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", false, "Grassa", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "eee10013-3831-446e-9a0e-754f327c7af3", "32781f4c-381a-449a-a16b-3c57690d599a", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER", "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", false, "Cesoie", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "f300bad3-6a51-4874-a4c9-ae0de46bb1e3", "210bec9a-b503-41cc-b95b-4de49191175a", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER", "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", false, "Pino", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER" },
                    { "fef09731-61ed-4617-a14b-34bab5b978dd", "7da220d3-70ef-424d-9bfd-bfd4d290664d", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER", "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", false, "Cigliegio", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SEEDER" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "UserPreferences",
                columns: new[] { "Id", "ItemTypeId", "OwnerId" },
                values: new object[,]
                {
                    { "16de1826-184b-4baa-9dd8-e05b886ee4a3", "32781f4c-381a-449a-a16b-3c57690d599a", "7a63bbf1-4346-4aa7-a273-358f66224527" },
                    { "20c155e4-724e-4c23-97d8-25b280a90375", "cdcd18a8-9df4-4224-984d-e8d0ffe2ad2b", "7a63bbf1-4346-4aa7-a273-358f66224527" },
                    { "2150b65b-40da-43e9-8eaf-335ea59678bd", "46981d42-de4a-4084-8aae-6ddff896434c", "7a63bbf1-4346-4aa7-a273-358f66224527" },
                    { "28584503-2dd7-4534-9b38-162aa29078ad", "a50108a3-aa1a-4ed8-aed6-500b906830c9", "7a63bbf1-4346-4aa7-a273-358f66224527" },
                    { "31db58f7-d710-4b43-a568-dffd582a6b2a", "64ca104f-eb10-4539-9319-c667d1cbdfc0", "13017f42-1786-4d94-9702-6e687f578a47" },
                    { "35ca3132-2ea5-42b6-bbb2-35e57365b4ac", "a5475794-16f9-4c66-9e39-9e48d94941b9", "13017f42-1786-4d94-9702-6e687f578a47" },
                    { "4029e41f-6816-4243-8499-8a57656d6af0", "d68fb54d-0369-488b-8d16-38970ff26896", "7a63bbf1-4346-4aa7-a273-358f66224527" },
                    { "51b69010-08bf-44f3-aaa9-94bc4855bf70", "64ca104f-eb10-4539-9319-c667d1cbdfc0", "13017f42-1786-4d94-9702-6e687f578a47" },
                    { "5c1674e5-13ff-4377-a772-cf1a9251dac1", "7da220d3-70ef-424d-9bfd-bfd4d290664d", "7a63bbf1-4346-4aa7-a273-358f66224527" },
                    { "7fa4edf6-6b08-45ff-ac29-266be4592457", "235d0b4b-5046-4759-8e7d-d60873e1f7e8", "7a63bbf1-4346-4aa7-a273-358f66224527" },
                    { "9095b093-1163-4d71-83cc-82fa87fa9c7e", "ce826748-979b-4e75-b79a-37b11e19dedf", "7a63bbf1-4346-4aa7-a273-358f66224527" },
                    { "b0705c45-b1b2-414b-a077-c5a9b6b325bb", "9cf6ab99-7a88-40b2-8d19-23868dcafd03", "7a63bbf1-4346-4aa7-a273-358f66224527" },
                    { "c392b522-c068-45da-9b7c-ed0e97b7af7e", "64ca104f-eb10-4539-9319-c667d1cbdfc0", "7a63bbf1-4346-4aa7-a273-358f66224527" },
                    { "c4a047b2-227d-4337-8e49-d908d08e02c3", "572c7be0-bfdc-4ae9-a056-ad568df6a4bc", "7a63bbf1-4346-4aa7-a273-358f66224527" },
                    { "c5513422-5ec3-49f9-9797-74ce19b68989", "a5475794-16f9-4c66-9e39-9e48d94941b9", "7a63bbf1-4346-4aa7-a273-358f66224527" },
                    { "cf648d46-8e18-4f08-bf6a-f38c53006a42", "210bec9a-b503-41cc-b95b-4de49191175a", "7a63bbf1-4346-4aa7-a273-358f66224527" },
                    { "d03c8746-715b-4006-b340-95eb981b7c09", "67d10465-8b17-479a-9859-83d16b11dd84", "7a63bbf1-4346-4aa7-a273-358f66224527" },
                    { "db7ada8d-f91e-4116-8cba-785c1518f908", "ba4a9ede-54eb-4768-875f-36da8a6d94bc", "7a63bbf1-4346-4aa7-a273-358f66224527" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: "188ad023-a2d4-4874-b84a-12a528e35073");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: "18cc9a4e-5b6c-4d9f-bd97-82b660d83f81");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: "23b121b4-60f7-4bd1-acd3-d9d9ac639132");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: "281407cb-0008-43fc-ac68-4f924b6edaa8");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: "314011b0-57c8-458d-8267-fe93549d01fb");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: "315ffca6-1e96-4bc9-bbdb-85c1abeff49f");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: "31623bc9-5c07-48df-86d2-84f0b592d823");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: "39be91a5-0f25-4fc7-869a-6225f89d8764");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: "3c375fe9-3625-4ffd-8693-21bdc963451d");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: "3c9eb92e-d41e-474e-98e2-c3b529a28850");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: "41c8c8d9-ee66-4bdb-9e41-f40cc24bf653");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: "4ebeb1b3-85e2-4715-b0b4-5f6a111be9f7");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: "51f52191-a956-4dfe-9dca-858270681a2d");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: "a36f7001-25ca-4a8e-9206-7f0580007fcc");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: "ac191fca-d358-46f9-ae17-28dfc9759566");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: "b40b820d-f2f4-47c2-8213-c15f0c3346db");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: "b4b3f08e-8c41-49b6-9767-b606b369fc77");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: "c54b5a2b-a3de-485c-b4da-98ca35ac3c4e");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: "e9581aba-cbde-4dbc-a0c4-51ff798dee11");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: "ec4948f9-3892-4371-a460-a877007d80c1");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: "eee10013-3831-446e-9a0e-754f327c7af3");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: "f300bad3-6a51-4874-a4c9-ae0de46bb1e3");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: "fef09731-61ed-4617-a14b-34bab5b978dd");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: "16de1826-184b-4baa-9dd8-e05b886ee4a3");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: "20c155e4-724e-4c23-97d8-25b280a90375");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: "2150b65b-40da-43e9-8eaf-335ea59678bd");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: "28584503-2dd7-4534-9b38-162aa29078ad");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: "31db58f7-d710-4b43-a568-dffd582a6b2a");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: "35ca3132-2ea5-42b6-bbb2-35e57365b4ac");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: "4029e41f-6816-4243-8499-8a57656d6af0");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: "51b69010-08bf-44f3-aaa9-94bc4855bf70");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: "5c1674e5-13ff-4377-a772-cf1a9251dac1");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: "7fa4edf6-6b08-45ff-ac29-266be4592457");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: "9095b093-1163-4d71-83cc-82fa87fa9c7e");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: "b0705c45-b1b2-414b-a077-c5a9b6b325bb");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: "c392b522-c068-45da-9b7c-ed0e97b7af7e");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: "c4a047b2-227d-4337-8e49-d908d08e02c3");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: "c5513422-5ec3-49f9-9797-74ce19b68989");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: "cf648d46-8e18-4f08-bf6a-f38c53006a42");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: "d03c8746-715b-4006-b340-95eb981b7c09");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: "db7ada8d-f91e-4116-8cba-785c1518f908");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: "210bec9a-b503-41cc-b95b-4de49191175a");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: "235d0b4b-5046-4759-8e7d-d60873e1f7e8");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: "32781f4c-381a-449a-a16b-3c57690d599a");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: "46981d42-de4a-4084-8aae-6ddff896434c");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: "572c7be0-bfdc-4ae9-a056-ad568df6a4bc");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: "64ca104f-eb10-4539-9319-c667d1cbdfc0");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: "67d10465-8b17-479a-9859-83d16b11dd84");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: "7da220d3-70ef-424d-9bfd-bfd4d290664d");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: "9cf6ab99-7a88-40b2-8d19-23868dcafd03");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: "a50108a3-aa1a-4ed8-aed6-500b906830c9");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: "a5475794-16f9-4c66-9e39-9e48d94941b9");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: "ba4a9ede-54eb-4768-875f-36da8a6d94bc");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: "cdcd18a8-9df4-4224-984d-e8d0ffe2ad2b");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: "ce826748-979b-4e75-b79a-37b11e19dedf");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: "d68fb54d-0369-488b-8d16-38970ff26896");
        }
    }
}
