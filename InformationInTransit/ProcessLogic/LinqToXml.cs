using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
using System.Xml.Linq;

namespace InformationInTransit.ProcessLogic
{
    public class LinqToXml
    {
        public static void Main(string[] argv)
        {
            /*
            XElement bibleKJVFromFile = XElement.Load(@"\WordOfGod\Comforter_-_BibleKJV.xml");
            XmlDocumentBuild();
            XElement xElementFunctionalConstruction = XElementFunctionalConstruction();
            */

            ProcessPurchaseOrder();
        }

        public static XElement Load(string filename)
        {
            XElement xElement = XElement.Load(filename);
            return xElement;
        }

        public static void ProcessPurchaseOrder()
        {
            XElement purchaseOrder = Load(PurchaseOrder);
            IEnumerable<string> partNos =
                from item in purchaseOrder.Descendants("Item")
                select (string)item.Attribute("PartNumber");

            System.Console.WriteLine("Obtain the part number attribute value for every item element in the purchase order");
            foreach (string partNumber in partNos)
            {
                System.Console.WriteLine(partNumber);
            }

            //A list, sorted in part number order, of the items with a value greater than $100. 
            IEnumerable<XElement> valuesGreaterThan100 =
                from item in purchaseOrder.Descendants("Item")
                where (int)item.Element("Quantity") *
                (decimal)item.Element("USPrice") > 100
                orderby (string)item.Element("PartNumber")
                select item;

            System.Console.WriteLine("A list, sorted in part number order, of the items with a value greater than $100.");
            
            foreach (XElement valueGreaterThan100 in valuesGreaterThan100)
            {
                System.Console.WriteLine(valueGreaterThan100.Attribute("PartNumber").Value);
            }
        }

        public static XmlDocument XmlDocumentBuild()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement name = doc.CreateElement("name");
            name.InnerText = "Patrick Hines";
            XmlElement phone1 = doc.CreateElement("phone");
            phone1.SetAttribute("type", "home");
            phone1.InnerText = "206-555-0144";
            XmlElement phone2 = doc.CreateElement("phone");
            phone2.SetAttribute("type", "work");
            phone2.InnerText = "425-555-0145";
            XmlElement street1 = doc.CreateElement("street1");
            street1.InnerText = "123 Main St";
            XmlElement city = doc.CreateElement("city");
            city.InnerText = "Mercer Island";
            XmlElement state = doc.CreateElement("state");
            state.InnerText = "WA";
            XmlElement postal = doc.CreateElement("postal");
            postal.InnerText = "68042";
            XmlElement address = doc.CreateElement("address");
            address.AppendChild(street1);
            address.AppendChild(city);
            address.AppendChild(state);
            address.AppendChild(postal);
            XmlElement contact = doc.CreateElement("contact");
            contact.AppendChild(name);
            contact.AppendChild(phone1);
            contact.AppendChild(phone2);
            contact.AppendChild(address);
            XmlElement contacts = doc.CreateElement("contacts");
            contacts.AppendChild(contact);
            doc.AppendChild(contacts);
            return doc;
        }

        public static XElement XElementFunctionalConstruction()
        {
            XElement contacts =
                new XElement("contacts",
                    new XElement("contact",
                        new XElement("name", "Patrick Hines"),
                        new XElement("phone", "206-555-0144",
                           new XAttribute("type", "home")),
                        new XElement("phone", "425-555-0145",
                            new XAttribute("type", "work")),
                        new XElement("address",
                            new XElement("street1", "123 Main St"),
                            new XElement("city", "Mercer Island"),
                            new XElement("state", "WA"),
                            new XElement("postal", "68042")
                        )
                    )
                );
            return contacts;
        }

        public static XDocument XDocumentFunctionalConstruction()
        {
            XDocument contactsDoc =
                new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XComment("LINQ to XML Contacts XML Example"),
                    new XProcessingInstruction("MyApp", "123-44-4444"),
                    new XElement("contacts",
                        new XElement("contact",
                            new XElement("name", "Patrick Hines"),
                            new XElement("phone", "206-555-0144"),
                            new XElement("address",
                                new XElement("street1", "123 Main St"),
                                new XElement("city", "Mercer Island"),
                                new XElement("state", "WA"),
                                new XElement("postal", "68042")
                                        )
                                    )
                                )
                            );
            return contactsDoc;
        }

        public static XElement XElementParse()
        {
            XElement xmlTree = XElement.Parse("<Root> <Child> </Child> </Root>");
            Console.WriteLine(xmlTree);
            return xmlTree;
        }

        public const string PurchaseOrder = "PurchaseOrder.xml";
    }
}
