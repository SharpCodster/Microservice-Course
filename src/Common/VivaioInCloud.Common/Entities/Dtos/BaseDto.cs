using VivaioInCloud.Common.Abstraction.Entities;

namespace VivaioInCloud.Common.Entities.Dtos
{
    public class BaseDto : IIdentified
    {
        public string Id { get; set; }
    }
}
