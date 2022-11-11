using Ardalis.Specification;
using VivaioInCloud.Common.Abstraction.Entities;

namespace VivaioInCloud.Common.Specifications
{
    public class GetOnlyUserRecordsSpecification<T> : Specification<T>
        where T : class, IUserOwnedRecord
    {
        public GetOnlyUserRecordsSpecification(string userId) : base()
        {
            Query
                .Where(v => v.OwnerId == userId)
                .AsNoTracking()
            ;
        }

    }
}

