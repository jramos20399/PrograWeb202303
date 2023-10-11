﻿namespace FrontEnd.Models
{
    public class ProductViewModel
    {

        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int? SupplierId { get; set; }
        public IEnumerable<SupplierViewModel> Suppliers { get; set; }


        public int? CategoryId { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; }

        public string? QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
    }
}
