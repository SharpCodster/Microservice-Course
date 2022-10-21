using VivaioInCloud.Common.Entities.Models;

namespace VivaioInCloud.Catalog.Entities.Models
{
    public class ItemType : BaseAuditableEntity
    {
        public ItemType()
        {
            Items = new HashSet<CatalogItem>();
        }
       
        public string Name { get; set; }

        public virtual ICollection<CatalogItem>? Items { get; set; }
    }
}
