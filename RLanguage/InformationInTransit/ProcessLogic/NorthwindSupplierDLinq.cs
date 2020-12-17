using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace InformationInTransit.ProcessLogic
{
    [Table(Name = "Suppliers")]
    public class NorthwindSupplierDLinq
    {
        [Column(IsPrimaryKey = true, CanBeNull = false)]
        public int SupplierID{ get; set; }

        [Column(CanBeNull = false)]
        public string CompanyName { get; set; }

        [Column]
        public string ContactName { get; set; }

        private EntitySet<NorthwindProductDLinq> products = null;
        [Association(Storage = "products", OtherKey = "SupplierID", ThisKey = "SupplierID")]
        public EntitySet<NorthwindProductDLinq> Products
        {
            get { return this.products; }
            set { this.products.Assign(value); }
        }
    }
}
