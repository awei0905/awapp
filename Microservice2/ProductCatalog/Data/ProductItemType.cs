using System;
using System.Collections.Generic;

namespace ProductCatalog.Data
{
    public partial class ProductItemType
    {
        public int ProductItemTypeId { get; set; }
        public int ProductItemId { get; set; }
        public int ProductTypeId { get; set; }

        public virtual ProductItem ProductItem { get; set; } = null!;
        public virtual ProductType ProductType { get; set; } = null!;
    }
}
