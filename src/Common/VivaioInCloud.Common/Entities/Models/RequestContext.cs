using Microsoft.AspNetCore.Http;
using VivaioInCloud.Common.Entities.Dtos;

namespace VivaioInCloud.Common.Entities.Models
{
    public class RequestContext
    {
        public UserDto User { get; set; }
        public string CorrelationId { get; set; }
        public IQueryCollection Query { get; set; }
    }
}
