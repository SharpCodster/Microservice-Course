using Ardalis.Specification;
using System.Linq.Expressions;
using VivaioInCloud.Common.Abstraction.Entities;

namespace VivaioInCloud.Common.Specifications
{
    public class BaseQueryStringSpecification<T> : Specification<T>
        where T : class, IIdentified, new()
    {
        protected BaseQueryStringSpecification() : base()
        {
        }

        private string _query;

        public override string ToString()
        {
            return _query;
        }

        public BaseQueryStringSpecification(Dictionary<string, string> queryString) : this()
        {
            var queryStringToLower = queryString.ToDictionary(_ => _.Key.ToLower(), X => X.Value?.ToLower());

            _query = "all";
            var list = queryStringToLower.Select(_ => $"{_.Key}={_.Value}").ToList();
            if (list != null && list.Count > 0)
            {
                _query = list.Aggregate((a, b) => $"{a}&{b}");
            }

            ApplyOrderBy(queryStringToLower);
            ApplySkipTake(queryStringToLower);
        }

        private void ApplySkipTake(Dictionary<string, string> queryString)
        {
            int take = 10;
            string sizeKey = "pagesize";
            if (queryString.ContainsKey(sizeKey))
            {
                int pageSize = Convert.ToInt32(queryString[sizeKey]);
                take = pageSize;
            }

            int skip = 0;
            string pageKey = "page";
            if (queryString.ContainsKey(pageKey))
            {
                int page = Convert.ToInt32(queryString[pageKey]);
                skip = (page - 1) * take;
            }

            Query.Skip(skip).Take(take);
        }

        private void ApplyOrderBy(Dictionary<string, string> queryString)
        {
            string key = "orderby";

            if (queryString.ContainsKey(key))
            {
                string orderByPropery = queryString[key];

                if (orderByPropery.Contains("desc"))
                {
                    orderByPropery = orderByPropery.Replace("desc", "").Trim();
                    Query.OrderByDescending(GetOrderByProperty(orderByPropery));
                }
                else
                {
                    orderByPropery = orderByPropery.Replace("asc", "").Trim();
                    Query.OrderBy(GetOrderByProperty(orderByPropery));
                }
            }
        }

        private Expression<Func<T, object>> GetOrderByProperty(string orderByPropery)
        {
            var properties = typeof(T).GetProperties();
            var property = properties.FirstOrDefault(_ => _.Name.ToLower() == orderByPropery);
            var parameter = Expression.Parameter(typeof(T), "_");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var body = MemberExpression.Convert(propertyAccess, typeof(object));
            var sortExpression = Expression.Lambda<Func<T, object>>(body, parameter);
            //var orderByExpression = Expression.Lambda<Func<T, object>>(propertyAccess, parameter);
            return sortExpression;
        }
    }
}
