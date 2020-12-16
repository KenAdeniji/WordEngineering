using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Lab_Assignment_7
{
    public partial class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pin { get; set; }
        public string PhoneNumber { get; set; }
        public string CellPhoneNumber { get; set; }
        public string FaxNumber { get; set; }

        public string Header
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public void Add()
        {
            CustomerCollection.Add(this);
        }

        public static String Collate(int customerCollectionIndex)
        {
            Customer customer = Select(customerCollectionIndex);
            string collate = String.Format
                                (
                                    CollateFormat,
                                    System.Environment.NewLine,
                                    customer.FirstName,
                                    customer.LastName,
                                    customer.Pin,
                                    customer.PhoneNumber,
                                    customer.CellPhoneNumber,
                                    customer.FaxNumber
                                );
            return collate;
        }

        public static List<Customer> Find(Customer query)
        {
            System.Collections.Generic.IEnumerable<Customer> customers = 
                from    n in CustomerCollection
                where   n.FirstName.Contains(query.FirstName) &&
                        n.LastName.Contains(query.LastName) &&
                        n.Pin.Contains(query.Pin) &&
                        n.PhoneNumber.Contains(query.PhoneNumber) &&
                        n.CellPhoneNumber.Contains(query.CellPhoneNumber) &&
                        n.FaxNumber.Contains(query.FaxNumber)
                select  n;
            List<Customer> list = new List<Customer>(customers);
            return list;
        }

        public static void Remove(int customerCollectionIndex)
        {
            CustomerCollection.RemoveAt(customerCollectionIndex);
        }

        public static Customer Select(int customerCollectionIndex)
        {
            return CustomerCollection[customerCollectionIndex];
        }

        public static Collection<Customer> CustomerCollection = new Collection<Customer>();
        private const string CollateFormat = "First Name: {1}{0}LastName: {2}{0}Pin: {3}{0}Phone: {4}{0}Cell: {5}{0}Fax: {6}{0}";
    }
}
