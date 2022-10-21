using VivaioInCloud.Common.Abstraction.Entities;

namespace VivaioInCloud.Common.Entities.Models
{
    public abstract class BaseEntity : IIdentified
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}
