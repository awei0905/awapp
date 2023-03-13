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
        public int Quantity { get; set; }
        public string ImageUrl { get; set; } = null!;
    }
}
