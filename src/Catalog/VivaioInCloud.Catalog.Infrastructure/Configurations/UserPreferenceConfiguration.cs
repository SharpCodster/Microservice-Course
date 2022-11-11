using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VivaioInCloud.Catalog.Entities.Models;
using VivaioInCloud.Common.Infrastructure.Configurations;

namespace VivaioInCloud.Catalog.Infrastructure.Configurations
{
    public class UserPreferenceConfiguration : IEntityTypeConfiguration<UserPreference>
    {
        public void Configure(EntityTypeBuilder<UserPreference> builder)
        {
            builder.ToTable("UserPreferences", "dbo");

            CommonConfigs.ConfigureId<UserPreference>(builder);

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

            builder.HasData
            (
                GetNewItem("31db58f7-d710-4b43-a568-dffd582a6b2a", "13017f42-1786-4d94-9702-6e687f578a47", "64ca104f-eb10-4539-9319-c667d1cbdfc0"),
                GetNewItem("35ca3132-2ea5-42b6-bbb2-35e57365b4ac", "13017f42-1786-4d94-9702-6e687f578a47", "a5475794-16f9-4c66-9e39-9e48d94941b9"),
                GetNewItem("51b69010-08bf-44f3-aaa9-94bc4855bf70", "13017f42-1786-4d94-9702-6e687f578a47", "64ca104f-eb10-4539-9319-c667d1cbdfc0"),
                GetNewItem("cf648d46-8e18-4f08-bf6a-f38c53006a42", "7a63bbf1-4346-4aa7-a273-358f66224527", "210bec9a-b503-41cc-b95b-4de49191175a"),
                GetNewItem("7fa4edf6-6b08-45ff-ac29-266be4592457", "7a63bbf1-4346-4aa7-a273-358f66224527", "235d0b4b-5046-4759-8e7d-d60873e1f7e8"),
                GetNewItem("16de1826-184b-4baa-9dd8-e05b886ee4a3", "7a63bbf1-4346-4aa7-a273-358f66224527", "32781f4c-381a-449a-a16b-3c57690d599a"),
                GetNewItem("2150b65b-40da-43e9-8eaf-335ea59678bd", "7a63bbf1-4346-4aa7-a273-358f66224527", "46981d42-de4a-4084-8aae-6ddff896434c"),
                GetNewItem("c4a047b2-227d-4337-8e49-d908d08e02c3", "7a63bbf1-4346-4aa7-a273-358f66224527", "572c7be0-bfdc-4ae9-a056-ad568df6a4bc"),
                GetNewItem("c392b522-c068-45da-9b7c-ed0e97b7af7e", "7a63bbf1-4346-4aa7-a273-358f66224527", "64ca104f-eb10-4539-9319-c667d1cbdfc0"),
                GetNewItem("d03c8746-715b-4006-b340-95eb981b7c09", "7a63bbf1-4346-4aa7-a273-358f66224527", "67d10465-8b17-479a-9859-83d16b11dd84"),
                GetNewItem("5c1674e5-13ff-4377-a772-cf1a9251dac1", "7a63bbf1-4346-4aa7-a273-358f66224527", "7da220d3-70ef-424d-9bfd-bfd4d290664d"),
                GetNewItem("b0705c45-b1b2-414b-a077-c5a9b6b325bb", "7a63bbf1-4346-4aa7-a273-358f66224527", "9cf6ab99-7a88-40b2-8d19-23868dcafd03"),
                GetNewItem("28584503-2dd7-4534-9b38-162aa29078ad", "7a63bbf1-4346-4aa7-a273-358f66224527", "a50108a3-aa1a-4ed8-aed6-500b906830c9"),
                GetNewItem("c5513422-5ec3-49f9-9797-74ce19b68989", "7a63bbf1-4346-4aa7-a273-358f66224527", "a5475794-16f9-4c66-9e39-9e48d94941b9"),
                GetNewItem("db7ada8d-f91e-4116-8cba-785c1518f908", "7a63bbf1-4346-4aa7-a273-358f66224527", "ba4a9ede-54eb-4768-875f-36da8a6d94bc"),
                GetNewItem("20c155e4-724e-4c23-97d8-25b280a90375", "7a63bbf1-4346-4aa7-a273-358f66224527", "cdcd18a8-9df4-4224-984d-e8d0ffe2ad2b"),
                GetNewItem("9095b093-1163-4d71-83cc-82fa87fa9c7e", "7a63bbf1-4346-4aa7-a273-358f66224527", "ce826748-979b-4e75-b79a-37b11e19dedf"),
                GetNewItem("4029e41f-6816-4243-8499-8a57656d6af0", "7a63bbf1-4346-4aa7-a273-358f66224527", "d68fb54d-0369-488b-8d16-38970ff26896")
            );
        }

        private UserPreference GetNewItem(string id, string userId, string typeId)
        {
            return new UserPreference
            {
                Id = id,
                OwnerId = userId,
                ItemTypeId = typeId
            };
        }
    }
}
