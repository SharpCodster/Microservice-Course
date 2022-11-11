using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VivaioInCloud.Common;
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


            builder.HasData(
                GetNewItem("13017f42-1786-4d94-9702-6e687f578a47", "user1@microsoft.com", "John", "Doe"),
                GetNewItem("7a63bbf1-4346-4aa7-a273-358f66224527", "user2@microsoft.com", "Paul", "Leen")
            );
        }

        private Contact GetNewItem(string id, string email, string name, string surname)
        {
            return new Contact
            {
                Id = id,
                Email = email,
                Name = name,
                Surname = surname,
                IsDeleted = false,
                CreatedAtUtc = SolutionConstants.Seeding.DATE,
                UpdatedAtUtc = SolutionConstants.Seeding.DATE,
                CreatedBy = SolutionConstants.Seeding.USER,
                UpdatedBy = SolutionConstants.Seeding.USER
            };
        }
    }
}

