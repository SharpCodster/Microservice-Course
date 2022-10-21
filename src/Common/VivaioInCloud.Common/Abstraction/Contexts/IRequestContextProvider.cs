using VivaioInCloud.Common.Entities.Models;

namespace VivaioInCloud.Common.Abstraction.Contexts
{
    public interface IRequestContextProvider
    {
        RequestContext GetRequestContexAsync();
        T GetQueryStringValue<T>(string parameterName);
    }
}
