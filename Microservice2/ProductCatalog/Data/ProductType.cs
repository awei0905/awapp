using System;
using System.Collections.Generic;

namespace ProductCatalog.Data
{
    public partial class ProductType
    {
        public ProductType()
        {
            ProductItemTypes = new HashSet<ProductItemType>();
        }

        public int ProductTypeId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<ProductItemType> ProductItemTypes { get; set; }
    }
}
