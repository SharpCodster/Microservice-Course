using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaioInCloud.Common.Infrastructure.Configurations;
using VivaioInCloud.Notification.Entities.Models;

namespace VivaioInCloud.Notification.Infrastructure.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts", "dbo");

            CommonConfigs.ConfigureId<Contact>(builder);
            CommonConfigs.ConfigureAudit<Contact>(builder);

            builder.Property(x => x.Name)
                .HasColumnOrder(1);

            builder.Property(x => x.Surname)
                .HasColumnOrder(2);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnOrder(3);


            //builder.HasOne(x => x.Category)
            //    .WithMany(x => x.Items)
            //    .HasForeignKey(x => x.CategoryId)
            //    .IsRequired(false)
            //    .OnDelete(DeleteBehavior.NoAction);


        }
    }
}

