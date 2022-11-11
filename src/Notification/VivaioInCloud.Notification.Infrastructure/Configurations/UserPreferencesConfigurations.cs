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

            builder.HasData
            (
                GetNewItem("9598fc44-35ea-4cc9-8740-5982d5b2192a", "13017f42-1786-4d94-9702-6e687f578a47", "64ca104f-eb10-4539-9319-c667d1cbdfc0"),
                GetNewItem("856f98a8-f0c8-4299-9e44-b083595470de", "13017f42-1786-4d94-9702-6e687f578a47", "a5475794-16f9-4c66-9e39-9e48d94941b9"),
                GetNewItem("4107308d-4bd2-44cf-824f-f8dafe02bffa", "13017f42-1786-4d94-9702-6e687f578a47", "64ca104f-eb10-4539-9319-c667d1cbdfc0"),
                GetNewItem("33d25f4c-2e88-4a7c-9bd0-0498332e9a15", "7a63bbf1-4346-4aa7-a273-358f66224527", "210bec9a-b503-41cc-b95b-4de49191175a"),
                GetNewItem("9d02f944-b1e3-41e8-89c0-e6507be198c2", "7a63bbf1-4346-4aa7-a273-358f66224527", "235d0b4b-5046-4759-8e7d-d60873e1f7e8"),
                GetNewItem("f11f51b1-33b6-49fe-a20e-a959221d7f5f", "7a63bbf1-4346-4aa7-a273-358f66224527", "32781f4c-381a-449a-a16b-3c57690d599a"),
                GetNewItem("ef1e8568-48b8-4eb4-802b-ebb270185fef", "7a63bbf1-4346-4aa7-a273-358f66224527", "46981d42-de4a-4084-8aae-6ddff896434c"),
                GetNewItem("9cfad8e0-84e8-47db-8d43-3f025eebfa74", "7a63bbf1-4346-4aa7-a273-358f66224527", "572c7be0-bfdc-4ae9-a056-ad568df6a4bc"),
                GetNewItem("fce90719-cae6-4a1f-a3ad-e29e3aee2442", "7a63bbf1-4346-4aa7-a273-358f66224527", "64ca104f-eb10-4539-9319-c667d1cbdfc0"),
                GetNewItem("c3ee743d-d8c1-4e2f-b85a-65b97defb885", "7a63bbf1-4346-4aa7-a273-358f66224527", "67d10465-8b17-479a-9859-83d16b11dd84"),
                GetNewItem("c2b74088-7458-4a68-a092-a22a2323cce0", "7a63bbf1-4346-4aa7-a273-358f66224527", "7da220d3-70ef-424d-9bfd-bfd4d290664d"),
                GetNewItem("bdb88ebe-9af2-43c9-b873-e9ce4cc400a3", "7a63bbf1-4346-4aa7-a273-358f66224527", "9cf6ab99-7a88-40b2-8d19-23868dcafd03"),
                GetNewItem("a8258483-4717-40c2-b669-4d1167f54c5c", "7a63bbf1-4346-4aa7-a273-358f66224527", "a50108a3-aa1a-4ed8-aed6-500b906830c9"),
                GetNewItem("fc73e8d5-3f06-40e8-88a7-d10a4c7e22c5", "7a63bbf1-4346-4aa7-a273-358f66224527", "a5475794-16f9-4c66-9e39-9e48d94941b9"),
                GetNewItem("b9456542-7e0a-4126-96c1-bc894f708541", "7a63bbf1-4346-4aa7-a273-358f66224527", "ba4a9ede-54eb-4768-875f-36da8a6d94bc"),
                GetNewItem("611543e5-c9fa-4aa5-a8e9-5329aa49e28d", "7a63bbf1-4346-4aa7-a273-358f66224527", "cdcd18a8-9df4-4224-984d-e8d0ffe2ad2b"),
                GetNewItem("58ea9fc4-1c83-448c-879a-34eda5bda428", "7a63bbf1-4346-4aa7-a273-358f66224527", "ce826748-979b-4e75-b79a-37b11e19dedf"),
                GetNewItem("4bdc9d4f-20ed-4613-91e8-c7d7081aff9a", "7a63bbf1-4346-4aa7-a273-358f66224527", "d68fb54d-0369-488b-8d16-38970ff26896")
            );
        }

        private UserPreference GetNewItem(string id, string userId, string typeId)
        {
            return new UserPreference
            {
                Id = id,
                UserId = userId,
                TypeId = typeId
            };
        }
    }
}
