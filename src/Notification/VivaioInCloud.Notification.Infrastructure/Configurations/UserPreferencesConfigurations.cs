using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VivaioInCloud.Common.Infrastructure.Configurations;
using VivaioInCloud.Notification.Entities.Models;

namespace VivaioInCloud.Notification.Infrastructure.Configurations
{
    public class UserPreferencesConfigurations : IEntityTypeConfiguration<UserPreference>
    {
        public void Configure(EntityTypeBuilder<UserPreference> builder)
        {
            builder.ToTable("UserPreferences", "dbo");

            CommonConfigs.ConfigureId<UserPreference>(builder);

            builder.Property(x => x.UserId)
                .HasColumnOrder(1);

            builder.Property(x => x.TypeId)
                .HasColumnOrder(2);

            builder.HasOne(x => x.User)
                .WithMany(x => x.UserPreferences)
                .HasForeignKey(x => x.UserId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
