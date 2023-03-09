using System;
using System.Collections.Generic;

namespace ProductCatalog.Data
{
    public partial class ProductItem
    {
        public int ProductItemId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public string PictureFileName { get; set; } = null!;
        public int ProductCatalogTypeId { get; set; }

        public virtual ProductCatalogType ProductCatalogType { get; set; } = null!;
    }
}
