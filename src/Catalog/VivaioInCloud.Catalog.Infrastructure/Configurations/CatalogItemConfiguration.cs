using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VivaioInCloud.Catalog.Entities.Models;
using VivaioInCloud.Common;
using VivaioInCloud.Common.Infrastructure.Configurations;

namespace VivaioInCloud.Catalog.Infrastructure.Configurations
{
    public class CatalogItemConfiguration : IEntityTypeConfiguration<CatalogItem>
    {
        public void Configure(EntityTypeBuilder<CatalogItem> builder)
        {
            builder.ToTable("CatalogItems", "dbo");

            CommonConfigs.ConfigureId<CatalogItem>(builder);
            CommonConfigs.ConfigureAudit<CatalogItem>(builder);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasColumnOrder(1);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnOrder(2);

            builder.Property(x => x.CategoryId)
                .HasColumnOrder(3);


            builder.HasOne(x => x.Category)
                .WithMany(x => x.Items)
                .HasForeignKey(x => x.CategoryId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);


            string loremIpsum = @"Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

            builder.HasData
            (
                GetNewItem("a36f7001-25ca-4a8e-9206-7f0580007fcc", "210bec9a-b503-41cc-b95b-4de49191175a", "Baobab", loremIpsum),
                GetNewItem("41c8c8d9-ee66-4bdb-9e41-f40cc24bf653", "210bec9a-b503-41cc-b95b-4de49191175a", "Cipresso", loremIpsum),
                GetNewItem("f300bad3-6a51-4874-a4c9-ae0de46bb1e3", "210bec9a-b503-41cc-b95b-4de49191175a", "Pino", loremIpsum),
                GetNewItem("c54b5a2b-a3de-485c-b4da-98ca35ac3c4e", "235d0b4b-5046-4759-8e7d-d60873e1f7e8", "Guanti", loremIpsum),
                GetNewItem("eee10013-3831-446e-9a0e-754f327c7af3", "32781f4c-381a-449a-a16b-3c57690d599a", "Cesoie", loremIpsum),
                GetNewItem("39be91a5-0f25-4fc7-869a-6225f89d8764", "46981d42-de4a-4084-8aae-6ddff896434c", "Letame Buono", loremIpsum),
                GetNewItem("188ad023-a2d4-4874-b84a-12a528e35073", "572c7be0-bfdc-4ae9-a056-ad568df6a4bc", "Kill 'Em All", loremIpsum),
                GetNewItem("281407cb-0008-43fc-ac68-4f924b6edaa8", "64ca104f-eb10-4539-9319-c667d1cbdfc0", "Orchidea", loremIpsum),
                GetNewItem("3c9eb92e-d41e-474e-98e2-c3b529a28850", "64ca104f-eb10-4539-9319-c667d1cbdfc0", "Mangia Fumo", loremIpsum),
                GetNewItem("b40b820d-f2f4-47c2-8213-c15f0c3346db", "64ca104f-eb10-4539-9319-c667d1cbdfc0", "Pianta Carnivora", loremIpsum),
                GetNewItem("ec4948f9-3892-4371-a460-a877007d80c1", "64ca104f-eb10-4539-9319-c667d1cbdfc0", "Grassa", loremIpsum),
                GetNewItem("4ebeb1b3-85e2-4715-b0b4-5f6a111be9f7", "64ca104f-eb10-4539-9319-c667d1cbdfc0", "Carnivora", loremIpsum),
                GetNewItem("fef09731-61ed-4617-a14b-34bab5b978dd", "7da220d3-70ef-424d-9bfd-bfd4d290664d", "Cigliegio", loremIpsum),
                GetNewItem("b4b3f08e-8c41-49b6-9767-b606b369fc77", "7da220d3-70ef-424d-9bfd-bfd4d290664d", "Pesco", loremIpsum),
                GetNewItem("51f52191-a956-4dfe-9dca-858270681a2d", "7da220d3-70ef-424d-9bfd-bfd4d290664d", "Pero", loremIpsum),
                GetNewItem("18cc9a4e-5b6c-4d9f-bd97-82b660d83f81", "7da220d3-70ef-424d-9bfd-bfd4d290664d", "Banano", loremIpsum),
                GetNewItem("314011b0-57c8-458d-8267-fe93549d01fb", "7da220d3-70ef-424d-9bfd-bfd4d290664d", "Avocado", loremIpsum),
                GetNewItem("31623bc9-5c07-48df-86d2-84f0b592d823", "a50108a3-aa1a-4ed8-aed6-500b906830c9", "Bello Verde", loremIpsum),
                GetNewItem("3c375fe9-3625-4ffd-8693-21bdc963451d", "a5475794-16f9-4c66-9e39-9e48d94941b9", "Master Griller", loremIpsum),
                GetNewItem("315ffca6-1e96-4bc9-bbdb-85c1abeff49f", "a5475794-16f9-4c66-9e39-9e48d94941b9", "Caverman", loremIpsum),
                GetNewItem("23b121b4-60f7-4bd1-acd3-d9d9ac639132", "cdcd18a8-9df4-4224-984d-e8d0ffe2ad2b", "Piccola", loremIpsum),
                GetNewItem("ac191fca-d358-46f9-ae17-28dfc9759566", "cdcd18a8-9df4-4224-984d-e8d0ffe2ad2b", "Media", loremIpsum),
                GetNewItem("e9581aba-cbde-4dbc-a0c4-51ff798dee11", "cdcd18a8-9df4-4224-984d-e8d0ffe2ad2b", "Grande", loremIpsum)
            );
        }

        private CatalogItem GetNewItem(string id, string catId, string title, string description)
        {
            return new CatalogItem
            {
                Id = id,
                CategoryId = catId,
                Title = title,
                Description = description,
                IsDeleted = false,
                CreatedAtUtc = SolutionConstants.Seeding.DATE,
                UpdatedAtUtc = SolutionConstants.Seeding.DATE,
                CreatedBy = SolutionConstants.Seeding.USER,
                UpdatedBy = SolutionConstants.Seeding.USER
            };
        }
    }
}
