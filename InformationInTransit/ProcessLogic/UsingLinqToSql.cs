using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq;

//using NorthwindDataContext;

/*
namespace InformationInTransit.ProcessLogic
{
    /// <summary>
    /// http://weblogs.asp.net/scottgu/archive/2007/05/19/using-linq-to-sql-part-1.aspx
    /// </summary>
    public static partial class UsingLinqToSql
    {
        public static void Main(string[] argv)
        {
            CustomEntityObjectValidationSupport();
        }

        public static void Single()
        {
            NorthwindDataContext db = new NorthwindDataContext(DatabaseConnectionString);
            Product product = db.Products.Single(p => p.ProductName == "Chef Anton's Cajun Seasoning");
            ObjectDumper.Write(product);
            product.UnitPrice = product.UnitPrice;
            product.UnitsInStock = product.UnitsInStock;
            db.SubmitChanges();
        }

        public static void InsertANewCategoryAndTwoNewProducts()
        {
            Categories category = new Categories();
            category.CategoryName = "Scott's Toys";

            Products products1 = new Products();
            products1.ProductName = "Toy 1";

            Products products2 = new Products();
            products2.ProductName = "Toy 2";

            category.Products.Add(products1);
            category.Products.Add(products2);

            NorthwindDataContext db = new NorthwindDataContext(DatabaseConnectionString);
            //db.Categories.InsertOnSubmit(category);
            db.SubmitChanges();
        }

        public static void DeleteProducts()
        {
            NorthwindDataContext db = new NorthwindDataContext(DatabaseConnectionString);
            var toyProducts = from p in db.Products where p.ProductName.Contains("Toy") select p;
            db.Products.DeleteAllOnSubmit(toyProducts);
            var toyCategories = from c in db.Categories where c.CategoryName.Contains("Toy") select c;
            db.Categories.DeleteAllOnSubmit(toyCategories);
            db.SubmitChanges();
        }

        public static void StoredProcedure()
        {
            NorthwindDataContext db = new NorthwindDataContext(DatabaseConnectionString);
            var products = db.CustOrderHist("Vinet");
            ObjectDumper.Write(products);
        }

        public static void ServerSidePaging()
        {
            NorthwindDataContext db = new NorthwindDataContext(DatabaseConnectionString);
            var products = (from p in db.Products where p.Categories.CategoryName.StartsWith("C") select p).Skip(0).Take(10);
            ObjectDumper.Write(products);
        }

        public static void ProductOrderDetails()
        {
            NorthwindDataContext db = new NorthwindDataContext(DatabaseConnectionString);
            var products = from p in db.Products where p.OrderDetails.Count > 5 select p;
            ObjectDumper.Write(products);
        }

        public static void AnonymousType()
        {
            NorthwindDataContext db = new NorthwindDataContext(DatabaseConnectionString);
            var products = from p in db.Products where p.Categories.CategoryName == "Beverages" select new { ID = p.ProductID, Name = p.ProductName };
            ObjectDumper.Write(products);
        }

        public static void ExtensionMethod()
        {
            NorthwindDataContext db = new NorthwindDataContext(DatabaseConnectionString);
            var products = from p in db.Products
                           where p.Categories.CategoryName == "Beverages"
                           select new 
                           { 
                               ID = p.ProductID,
                               Name = p.ProductName,
                               NumOrders = p.OrderDetails.Count,
                               Revenue = p.OrderDetails.Sum(o => o.UnitPrice * o.Quantity)
                           };
            ObjectDumper.Write(products);
        }

        public static void NoProductsOrderedAndPriceExceeds100()
        {
            NorthwindDataContext db = new NorthwindDataContext(DatabaseConnectionString);
            var products = from p in db.Products
                           where
                           p.OrderDetails.Count == 0 
                           &&
                           p.UnitPrice > 100
                           select p;
            ObjectDumper.Write(products);
        }

        public static void InsertingANewProduct()
        {
            NorthwindDataContext db = new NorthwindDataContext(DatabaseConnectionString);
            Products p = new Products();
            p.ProductName = "Scott's Special Product";
            p.UnitPrice = 999;
            p.UnitsInStock = 1;
            p.CategoryID = 1;
            db.Products.InsertOnSubmit(p);
            db.SubmitChanges();
        }

        public static void DeletingProducts()
        {
            NorthwindDataContext db = new NorthwindDataContext(DatabaseConnectionString);
            var lameProducts = from p in db.Products
                               where p.OrderDetails.Count > 0 && p.Discontinued 
                               select p;
            db.Products.DeleteAllOnSubmit(lameProducts);
            db.SubmitChanges();
        }

        public static void UpdatesAcrossRelationships()
        {
            NorthwindDataContext db = new NorthwindDataContext(DatabaseConnectionString);

            //Retrieve beverages category
            Categories beverage = db.Categories.Single(c => c.CategoryName == "Beverages");

            //Create new product
            Products myProduct = new Products();
            myProduct.ProductName = "Scott's Toy Product";
            myProduct.UnitPrice = 44;
            myProduct.UnitsInStock = 5;

            //Associate product with beverage category
            beverage.Products.Add(myProduct);

            db.SubmitChanges();
        }

        public static void StoreCustomer()
        {
            NorthwindDataContext db = new NorthwindDataContext(DatabaseConnectionString);

            //Retrieve product details
            Products chai = db.Products.Single(p => p.ProductName == "Chai");
            Products tofu = db.Products.Single(p => p.ProductName == "Tofu");

            //Create new Order and Order line items for products
            Orders myOrder = new Orders();
            myOrder.OrderDate = DateTime.Now;
            myOrder.RequiredDate = DateTime.Now.AddDays(1);
            myOrder.Freight = 34;

            OrderDetails myItem1 = new OrderDetails();
            myItem1.Products = chai;
            myItem1.Quantity = 23;

            OrderDetails myItem2 = new OrderDetails();
            myItem2.Products = tofu;
            myItem2.Quantity = 3;

            //Associate new order and order line items together
            myOrder.OrderDetails.Add(myItem1);
            myOrder.OrderDetails.Add(myItem2);

            //Retrieve customer details
            Customers myCustomer = db.Customers.Single(c => c.CompanyName == "Berglunds snabbköp");

            //Add the order to the customer's Orders collection
            myCustomer.Orders.Add(myOrder);

            db.SubmitChanges();
        }

        public static void CustomEntityObjectValidationSupport()
        {
            NorthwindDataContext db = new NorthwindDataContext(DatabaseConnectionString);
            Orders myOrder = new Orders();
            myOrder.OrderDate = DateTime.Now;
            myOrder.RequiredDate = DateTime.Now.AddDays(-1);
            db.Orders.InsertOnSubmit(myOrder);
            db.SubmitChanges();
        }

        public const string DatabaseConnectionString = @"Data Source=(local);Initial Catalog=NorthwindDataContext;Persist Security Info=True;Integrated Security=SSPI";
    }
}

namespace NorthwindDataContext
{
    public partial class Orders
    {
        partial void OnValidate(); // defining declaration
        partial void OnValidate()
        {
            if (RequiredDate < OrderDate)
            {
                throw new Exception("Deliver date is before Order date.");
            }
        }
    }
}
*/
