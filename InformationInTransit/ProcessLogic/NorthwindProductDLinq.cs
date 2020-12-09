using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace InformationInTransit.ProcessLogic
{
    [Table(Name = "Products")]
    public partial class NorthwindProductDLinq
    {
        [Column(IsPrimaryKey = true, CanBeNull = false)]
        public int ProductID{ get; set; }

        [Column(CanBeNull = false)]
        public string ProductName { get; set; }

        [Column]
        public int? SupplierID { get; set; }

        [Column(DbType = "money")]
        public decimal? UnitPrice { get; set; }

        private EntityRef<NorthwindSupplierDLinq> supplier;

        /*
         * The private supplier field is a reference to an instance of the Supplier
         * entity class. The public Supplier property provides access to this reference.
         * The Association attribute specifies how DLINQ locates and populates the data 
         * for this property. The Storage parameter identifies the private field used to 
         * store the reference to the Supplier object. The ThisKey parameter indicates 
         * which property in the Product entity class DLINQ should use to locate the 
         * Supplier to reference for this product, and the OtherKey parameter specifies
         * which property in the Supplier table DLINQ should match against the value 
         * for the ThisKey parameter. In this example, The Product and Supplier tables 
         * are joined across the SupplierID property in both entities.
        */
        [Association(Storage = "supplier", ThisKey = "SupplierID", OtherKey = "SupplierID")]
        public NorthwindSupplierDLinq Supplier
        {
            get { return this.supplier.Entity; }
            set { this.supplier.Entity = value; }
        }
    }
}
