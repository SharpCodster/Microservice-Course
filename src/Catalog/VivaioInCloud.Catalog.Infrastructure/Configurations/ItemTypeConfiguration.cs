using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VivaioInCloud.Catalog.Entities.Models;
using VivaioInCloud.Common;
using VivaioInCloud.Common.Infrastructure.Configurations;

namespace VivaioInCloud.Catalog.Infrastructure.Configurations
{
    public class ItemTypeConfiguration : IEntityTypeConfiguration<ItemType>
    {
        public void Configure(EntityTypeBuilder<ItemType> builder)
        {
            builder.ToTable("ItemTypes", "dbo");

            CommonConfigs.ConfigureId<ItemType>(builder);
            CommonConfigs.ConfigureAudit<ItemType>(builder);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnOrder(1);


            builder.HasData
            (
                GetNewItem("210bec9a-b503-41cc-b95b-4de49191175a", "alberi-ornamentali"),
                GetNewItem("235d0b4b-5046-4759-8e7d-d60873e1f7e8", "accessori"),
                GetNewItem("32781f4c-381a-449a-a16b-3c57690d599a", "potatura"),
                GetNewItem("46981d42-de4a-4084-8aae-6ddff896434c", "terriccio"),
                GetNewItem("572c7be0-bfdc-4ae9-a056-ad568df6a4bc", "diserbante"),
                GetNewItem("64ca104f-eb10-4539-9319-c667d1cbdfc0", "piante-da-interno"),
                GetNewItem("67d10465-8b17-479a-9859-83d16b11dd84", "piante-da-esterno"),
                GetNewItem("7da220d3-70ef-424d-9bfd-bfd4d290664d", "alberi-da-frutto"),
                GetNewItem("9cf6ab99-7a88-40b2-8d19-23868dcafd03", "vasi"),
                GetNewItem("a50108a3-aa1a-4ed8-aed6-500b906830c9", "prato"),
                GetNewItem("a5475794-16f9-4c66-9e39-9e48d94941b9", "barbecue"),
                GetNewItem("ba4a9ede-54eb-4768-875f-36da8a6d94bc", "cura-e-manutenzione"),
                GetNewItem("cdcd18a8-9df4-4224-984d-e8d0ffe2ad2b", "serre"),
                GetNewItem("ce826748-979b-4e75-b79a-37b11e19dedf", "gazebo"),
                GetNewItem("d68fb54d-0369-488b-8d16-38970ff26896", "rose")
            );
        }

        private ItemType GetNewItem(string id, string name)
        {
            return new ItemType
            {
                Id = id,
                Name = name,
                IsDeleted = false,
                CreatedAtUtc = SolutionConstants.Seeding.DATE,
                UpdatedAtUtc = SolutionConstants.Seeding.DATE,
                CreatedBy = SolutionConstants.Seeding.USER,
                UpdatedBy = SolutionConstants.Seeding.USER
            };
        }
    }
}
