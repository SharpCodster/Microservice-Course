using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VivaioInCloud.Catalog.Entities.Models;
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
                new ItemType { Id = "210BEC9A-B503-41CC-B95B-4DE49191175A", CreatedAtUtc = new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), UpdatedAtUtc = new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), CreatedBy = "SEEDER", UpdatedBy = "SEEDER", IsDeleted = false, Name = "alberi-ornamentali" },
                new ItemType { Id = "235D0B4B-5046-4759-8E7D-D60873E1F7E8", CreatedAtUtc = new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), UpdatedAtUtc = new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), CreatedBy = "SEEDER", UpdatedBy = "SEEDER", IsDeleted = false, Name = "accessori" },
                new ItemType { Id = "32781F4C-381A-449A-A16B-3C57690D599A", CreatedAtUtc = new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), UpdatedAtUtc = new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), CreatedBy = "SEEDER", UpdatedBy = "SEEDER", IsDeleted = false, Name = "potatura" },
                new ItemType { Id = "46981D42-DE4A-4084-8AAE-6DDFF896434C", CreatedAtUtc = new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), UpdatedAtUtc = new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), CreatedBy = "SEEDER", UpdatedBy = "SEEDER", IsDeleted = false, Name = "terriccio" },
                new ItemType { Id = "572C7BE0-BFDC-4AE9-A056-AD568DF6A4BC", CreatedAtUtc = new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), UpdatedAtUtc = new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), CreatedBy = "SEEDER", UpdatedBy = "SEEDER", IsDeleted = false, Name = "diserbante" },
                new ItemType { Id = "64CA104F-EB10-4539-9319-C667D1CBDFC0", CreatedAtUtc = new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), UpdatedAtUtc = new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), CreatedBy = "SEEDER", UpdatedBy = "SEEDER", IsDeleted = false, Name = "piante-da-interno" },
                new ItemType { Id = "67D10465-8B17-479A-9859-83D16B11DD84", CreatedAtUtc = new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), UpdatedAtUtc = new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), CreatedBy = "SEEDER", UpdatedBy = "SEEDER", IsDeleted = false, Name = "piante-da-esterno" },
                new ItemType { Id = "7DA220D3-70EF-424D-9BFD-BFD4D290664D", CreatedAtUtc = new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), UpdatedAtUtc = new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), CreatedBy = "SEEDER", UpdatedBy = "SEEDER", IsDeleted = false, Name = "alberi-da-frutto" },
                new ItemType { Id = "9CF6AB99-7A88-40B2-8D19-23868DCAFD03", CreatedAtUtc = new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), UpdatedAtUtc = new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), CreatedBy = "SEEDER", UpdatedBy = "SEEDER", IsDeleted = false, Name = "vasi" },
                new ItemType { Id = "A50108A3-AA1A-4ED8-AED6-500B906830C9", CreatedAtUtc = new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), UpdatedAtUtc = new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), CreatedBy = "SEEDER", UpdatedBy = "SEEDER", IsDeleted = false, Name = "prato" },
                new ItemType { Id = "A5475794-16F9-4C66-9E39-9E48D94941B9", CreatedAtUtc = new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), UpdatedAtUtc = new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), CreatedBy = "SEEDER", UpdatedBy = "SEEDER", IsDeleted = false, Name = "barbecue" },
                new ItemType { Id = "BA4A9EDE-54EB-4768-875F-36DA8A6D94BC", CreatedAtUtc = new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), UpdatedAtUtc = new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), CreatedBy = "SEEDER", UpdatedBy = "SEEDER", IsDeleted = false, Name = "cura-e-manutenzione" },
                new ItemType { Id = "CDCD18A8-9DF4-4224-984D-E8D0FFE2AD2B", CreatedAtUtc = new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), UpdatedAtUtc = new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), CreatedBy = "SEEDER", UpdatedBy = "SEEDER", IsDeleted = false, Name = "serre" },
                new ItemType { Id = "CE826748-979B-4E75-B79A-37B11E19DEDF", CreatedAtUtc = new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), UpdatedAtUtc = new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), CreatedBy = "SEEDER", UpdatedBy = "SEEDER", IsDeleted = false, Name = "gazebo" },
                new ItemType { Id = "D68FB54D-0369-488B-8D16-38970FF26896", CreatedAtUtc = new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), UpdatedAtUtc = new DateTime(2022, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), CreatedBy = "SEEDER", UpdatedBy = "SEEDER", IsDeleted = false, Name = "rose" }
            );
        }
    }
}
