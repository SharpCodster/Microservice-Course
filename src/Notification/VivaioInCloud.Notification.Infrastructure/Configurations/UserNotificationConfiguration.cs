using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VivaioInCloud.Common;
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


            builder.HasData(
                GetNewItem("88ecfb97-e769-478c-ab43-6617a616563b", "13017f42-1786-4d94-9702-6e687f578a47", true, "Test message"),
                GetNewItem("6cf186a7-4914-4dcc-b676-c45c998c3c71", "7a63bbf1-4346-4aa7-a273-358f66224527", true, "Test Message 2")
            );
        }

        private UserNotification GetNewItem(string id, string userId, bool delivered, string message)
        {
            return new UserNotification
            {
                Id = id,
                UserId = userId,
                Delivered = delivered,
                Message = message,
                IsDeleted = false,
                CreatedAtUtc = SolutionConstants.Seeding.DATE,
                UpdatedAtUtc = SolutionConstants.Seeding.DATE,
                CreatedBy = SolutionConstants.Seeding.USER,
                UpdatedBy = SolutionConstants.Seeding.USER
            };
        }
    }
}
