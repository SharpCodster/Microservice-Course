using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VivaioInCloud.Common.Abstraction.Contexts;
using VivaioInCloud.Common.Entities.Dtos;
using VivaioInCloud.Common.Entities.Models;
using VivaioInCloud.Common.Options;

namespace VivaioInCloud.Common.Contexts
{
    public class RequestContextProvider : IRequestContextProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CorrelationIdOptions _correlationIdOptions;

        public RequestContextProvider(IHttpContextAccessor httpContextAccessor, IOptions<CorrelationIdOptions> correlationIdOptions)
        {
            _correlationIdOptions = correlationIdOptions.Value;
            _httpContextAccessor = httpContextAccessor;
        }

        public RequestContext GetRequestContexAsync()
        {
            var user = CreateUserFromRequestAsync();
            var correlationId = GetCorrelationIdFromRequestAsync();

            return new RequestContext
            {
                User = user,
                CorrelationId = correlationId,
                Query = _httpContextAccessor.HttpContext.Request.Query
            };
        }

        private string GetCorrelationIdFromRequestAsync()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            string correlationId = "HttpContextNull";

            if (httpContext != null && httpContext.Request != null && httpContext.Request.Headers != null)
            {
                if (httpContext.Request.Headers.TryGetValue(_correlationIdOptions.Header, out StringValues requestCorrelationId))
                {
                    correlationId = requestCorrelationId;
                }
            }
            return correlationId;
        }

        private UserDto CreateUserFromRequestAsync()
        {
            var httpContext = _httpContextAccessor.HttpContext;



            var user = httpContext?.User;
            var userIdentity = user?.Identity;
            var userClaims = user?.Claims?.ToArray() ?? new Claim[] { };

            var userRoles = userClaims.Where(_ => _.Type == ClaimTypes.Role).Select(_ => _.Value).ToArray();
            var userNames = userClaims.Where(_ => _.Type == ClaimTypes.Name).Select(_ => _.Value).ToArray();
            var userIds = userClaims.Where(_ => _.Type == ClaimTypes.NameIdentifier).Select(_ => _.Value).ToArray();


            return new UserDto
            {
                Principal = user,
                UserName = userIdentity?.Name,
                UserClaims = userClaims,
                UserRoles = userRoles
            };
        }

        public T GetQueryStringValue<T>(string parameterName)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            httpContext.Request.Query.TryGetValue(parameterName, out StringValues stringValues);

            if (stringValues == default(StringValues))
                return default(T);

            var value = stringValues.FirstOrDefault();

            if (value == null)
                return default(T);

            var result = Convert.ChangeType(value, typeof(T));

            return (T)result;
        }
    }
}
