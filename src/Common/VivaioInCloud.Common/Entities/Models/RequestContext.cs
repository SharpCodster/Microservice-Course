using Microsoft.AspNetCore.Http;

namespace VivaioInCloud.Common.Entities.Models
{
    public class RequestContext
    {
        public User User { get; set; }
        public string CorrelationId { get; set; }
        public IQueryCollection Query { get; set; }
    }
}
