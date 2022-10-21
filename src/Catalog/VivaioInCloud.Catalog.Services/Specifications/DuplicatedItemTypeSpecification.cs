using Ardalis.Specification;
using VivaioInCloud.Catalog.Entities.Models;

namespace VivaioInCloud.Catalog.Services.Specifications
{
    public class DuplicatedItemTypeSpecification : Specification<ItemType>
    {
        public DuplicatedItemTypeSpecification(string id, string name)
        {
            Query
                .Where(v => !v.IsDeleted
                    && v.Id != id
                    && v.Name == name)
                .AsNoTracking()
            ;
        }
    }
}
