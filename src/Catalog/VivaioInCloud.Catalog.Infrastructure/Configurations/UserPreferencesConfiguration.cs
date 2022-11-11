using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VivaioInCloud.Catalog.Entities.Models;
using VivaioInCloud.Common.Infrastructure.Configurations;

namespace VivaioInCloud.Catalog.Infrastructure.Configurations
{
    public class UserPreferencesConfiguration : IEntityTypeConfiguration<UserPreferences>
    {
        public void Configure(EntityTypeBuilder<UserPreferences> builder)
        {
            builder.ToTable("UserPreferences", "dbo");

            CommonConfigs.ConfigureId<UserPreferences>(builder);

            builder.Property(x => x.OwnerId)
                .IsRequired()
                .HasColumnOrder(1);

            builder.Property(x => x.ItemTypeId)
                .IsRequired()
                .HasColumnOrder(2);

            builder.HasOne(x => x.ItemType)
                .WithMany(x => x.UserPreferences)
                .HasForeignKey(x => x.ItemTypeId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
