using System;
using System.Collections.Generic;

namespace ProductCatalog.Data
{
    public partial class ProductCatalogType
    {
        public ProductCatalogType()
        {
            ProductItems = new HashSet<ProductItem>();
        }

        public int ProductCatelogId { get; set; }
        public string Name { get; set; } = null!;
        public string Subname { get; set; } = null!;

        public virtual ICollection<ProductItem> ProductItems { get; set; }
    }
}
