#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;
using System.Globalization;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Xml;
#endregion

namespace InformationInTransit.UserInterface
{
    #region SpreadsheetXmlForExcelHandler definition
    public partial class SpreadsheetXmlForExcelHandler : IHttpHandler
    {
        #region Public Methods
        public void ProcessRequest(HttpContext context)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["NorthWind"].ConnectionString;
            SqlConnection sqlConnection;
            String orderRequested;

            orderRequested = (string) context.Request["OrderId"];

            if (String.Compare(orderRequested, String.Empty, true, CultureInfo.InvariantCulture) < 0)
            {
                string commandText = "SELECT OrderID from Orders";
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                IDataReader dataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(context.Server.MapPath("SpreadsheetXmlForExcelHeader.html"));
                XmlElement xmlElementParent = (XmlElement)xmlDocument.DocumentElement.GetElementsByTagName("select").Item(0);
                XmlElement xmlElementChild;
                String orderId;
                while (dataReader.Read())
                {
                    orderId = dataReader.GetInt32(0).ToString();
                    xmlElementChild = xmlDocument.CreateElement("option");
                    xmlElementChild.SetAttribute("value", orderId);
                    xmlElementChild.InnerText = orderId;
                    xmlElementParent.AppendChild(xmlElementChild);
                }
                dataReader.Close(); //CommandBehavior.CloseConnection, closes the connection. No need for an explicit sqlConnection.
                context.Response.Write(xmlDocument.InnerXml);
            }
            else
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                DataSet dataSet = new DataSet("Order");
                String sqlStatement = String.Format(SqlCustomerOrderFormat, orderRequested);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter
                (
                    sqlStatement,
                    sqlConnection
                );
                sqlDataAdapter.Fill(dataSet, "Customer");
                sqlStatement = String.Format(SqlProductOrderDetailsFormat, orderRequested);
                sqlDataAdapter = new SqlDataAdapter
                (
                    sqlStatement,
                    sqlConnection
                );
                sqlDataAdapter.Fill(dataSet, "Item");
                sqlConnection.Close();
                SendResults(context, dataSet);
                context.Response.End();
            }
        }

        private void SendResults(HttpContext context, DataSet dataSet)
        {
            context.Response.ContentType = "text/xml";
            context.Response.Output.Write(dataSet.GetXml());
            context.Response.End();
        }
        #endregion

        #region Public Properties
        public bool IsReusable
        {
            get { return true; }
        }
        #endregion

        #region Constants
        public const string SqlCustomerOrderFormat = "SELECT OrderId, CompanyName, Address, City, Region, PostalCode, Country, Freight " +
            " FROM Customers " +
            " INNER JOIN Orders ON Customers.CustomerId = Orders.CustomerId " +
            " WHERE Orders.OrderId = {0}";
        public const string SqlProductOrderDetailsFormat = "SELECT Products.ProductName, [Order Details].Quantity, " +
            " [Order Details].UnitPrice * [Quantity] * (1-[Discount]) AS ItemTotal " +
            " FROM Products INNER JOIN [Order Details] ON Products.ProductId = [Order Details].ProductId " +
            " WHERE [Order Details].OrderId = {0}";
        #endregion
    }
    #endregion
}
