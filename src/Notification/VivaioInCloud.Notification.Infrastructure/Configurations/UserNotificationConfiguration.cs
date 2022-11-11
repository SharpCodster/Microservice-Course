using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VivaioInCloud.Common.Infrastructure.Configurations;
using VivaioInCloud.Notification.Entities.Models;

namespace VivaioInCloud.Notification.Infrastructure.Configurations
{
    public class UserNotificationConfiguration : IEntityTypeConfiguration<UserNotification>
    {
        public void Configure(EntityTypeBuilder<UserNotification> builder)
        {
            builder.ToTable("UserNotifications", "dbo");

            CommonConfigs.ConfigureId<UserNotification>(builder);
            CommonConfigs.ConfigureAudit<UserNotification>(builder);

            builder.Property(x => x.UserId)
                .HasColumnOrder(1);

            builder.Property(x => x.Delivered)
                .HasColumnOrder(2);

            builder.Property(x => x.Message)
                .IsRequired()
                .HasColumnOrder(3);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Notifications)
                .HasForeignKey(x => x.UserId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
