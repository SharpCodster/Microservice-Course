using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VivaioInCloud.Common.Abstraction.Entities;

namespace VivaioInCloud.Common.Infrastructure.Configurations
{
    public static class CommonConfigs
    {
        public static void ConfigureId<T>(EntityTypeBuilder<T> builder) where T : class, IIdentified
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .HasColumnOrder(0);
        }

        public static void ConfigureAudit<T>(EntityTypeBuilder<T> builder) where T : class, IAuditableUtc
        {
            builder.Property(x => x.CreatedAtUtc)
                .HasColumnName("CreatedAtUtc")
                .IsRequired()
                .HasColumnOrder(1000);

            builder.Property(x => x.CreatedBy)
                .HasColumnName("CreatedBy")
                .IsRequired()
                .HasMaxLength(180)
                .HasColumnOrder(1001);

            builder.Property(x => x.UpdatedAtUtc)
                .HasColumnName("UpdatedAtUtc")
                .IsRequired()
                .HasColumnOrder(1002);

            builder.Property(x => x.UpdatedBy)
                .HasColumnName("UpdatedBy")
                .HasMaxLength(180)
                .IsRequired()
                .HasColumnOrder(1003);

            builder.Property(x => x.IsDeleted)
                .HasColumnName("IsDeleted")
                .IsRequired()
                .HasColumnOrder(1004);
        }
    }
}