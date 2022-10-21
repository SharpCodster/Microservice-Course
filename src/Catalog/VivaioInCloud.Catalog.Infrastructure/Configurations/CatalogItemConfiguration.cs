using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VivaioInCloud.Catalog.Entities.Models;
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


        }
    }
}
