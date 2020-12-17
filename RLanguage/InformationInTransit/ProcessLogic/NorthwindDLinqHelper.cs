using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace InformationInTransit.ProcessLogic
{
    public static partial class NorthwindDLinqHelper
    {
        public static void Main(string[] argv)
        {
            /*
                QueryProduct();
                QueryProductAndSupplier();
                QueryProductExtraSupplier();
            */
            QuerySupplierExtraProducts();
        }

        public static void QueryProduct()
        {
            DataContext db = new DataContext("Integrated Security=true; Initial Catalog=Northwind; Data Source=(local)");

            Table<NorthwindProductDLinq> products = db.GetTable<NorthwindProductDLinq>();
            var productsQuery = from p in products
                                select p;
            foreach (var product in productsQuery)
            {
                Console.WriteLine
                (
                    "ID: {0}, Name: {1}, Supplier: {2}, Price: {3:C}",
                    product.ProductID,
                    product.ProductName,
                    product.SupplierID,
                    product.UnitPrice
                );
            }

            NorthwindProductDLinq singleProduct = products.Single(p => p.ProductID == 27);
            Console.WriteLine("Name: {0}", singleProduct.ProductName);
        }

        public static void QueryProductAndSupplier()
        {
            DataContext db = new DataContext("Integrated Security=true; Initial Catalog=Northwind; Data Source=(local)");

            Table<NorthwindProductDLinq> products = db.GetTable<NorthwindProductDLinq>();

            Table<NorthwindSupplierDLinq> suppliers = db.GetTable<NorthwindSupplierDLinq>();

            var productsAndSuppliersQuery = from p in products
                                       join s in suppliers
                                       on p.SupplierID equals s.SupplierID
                                       select new { p.ProductName, s.CompanyName, s.ContactName };

            foreach (var productAndSupplier in productsAndSuppliersQuery)
            {
                Console.WriteLine
                (
                    "Product: {0}, Supplier Company: {1}, Supplier Contact: {2}",
                    productAndSupplier.ProductName,
                    productAndSupplier.CompanyName,
                    productAndSupplier.ContactName
                );
            }
        }

        public static void QueryProductExtraSupplier()
        {
            DataContext db = new DataContext("Integrated Security=true; Initial Catalog=Northwind; Data Source=(local)");

            Table<NorthwindProductDLinq> products = db.GetTable<NorthwindProductDLinq>();
            var productsQuery = from p in products
                                select p;
            foreach (var product in productsQuery)
            {
                Console.WriteLine
                (
                    "Product: {0}, Supplier's Company: {1}",
                    product.ProductName,
                    product.Supplier.CompanyName
                );
            }
        }

        public static void QuerySupplierExtraProducts()
        {
            DataContext db = new DataContext("Integrated Security=true; Initial Catalog=Northwind; Data Source=(local)");

            Table<NorthwindSupplierDLinq> suppliers = db.GetTable<NorthwindSupplierDLinq>();

            DataLoadOptions loadOptions = new DataLoadOptions();
            loadOptions.LoadWith<NorthwindSupplierDLinq>(s => s.Products);

            db.LoadOptions = loadOptions;

            var suppliersAndProducts = from s in suppliers
                                       select s;

            foreach (var supplier in suppliersAndProducts)
            {
                Console.WriteLine("Supplier name: {0}", supplier.CompanyName);
                Console.WriteLine("Products supplied");
                foreach (var product in supplier.Products)
                {
                    Console.WriteLine("\t{0}", product.ProductName);
                }
                Console.WriteLine();
            }
        }
    }
}
