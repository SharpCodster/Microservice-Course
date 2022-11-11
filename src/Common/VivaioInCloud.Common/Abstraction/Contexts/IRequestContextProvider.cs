using VivaioInCloud.Common.Entities.Models;

namespace VivaioInCloud.Common.Abstraction.Contexts
{
    public interface IRequestContextProvider
    {
        Task<RequestContext> GetRequestContexAsync();
        T GetQueryStringValue<T>(string parameterName);
    }
}
