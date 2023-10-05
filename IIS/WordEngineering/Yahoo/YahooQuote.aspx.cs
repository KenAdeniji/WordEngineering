using System;
using System.Data;
using System.Diagnostics;
using System.Configuration;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Web.Services ;
using System.Net;
using System.IO;
using System.Text;
using System.Collections.Generic;

public partial class Yahoo_YahooQuote : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Refresh();
    }

    private void Refresh()
    {
        List<StockQuote> stockQuote = new List<StockQuote>();
        string[] symbols = Symbols;
        string emblems = Request.QueryString["Symbols"];
        if (!String.IsNullOrEmpty(emblems)) { symbols = emblems.Split(EmblemsSeparator); }
        foreach (string symbol in symbols)
        {
            stockQuote.Add
            (
                new StockQuote
                {
                    Symbol = symbol,
                    Quote = RetrieveQuote(symbol)
                }
            );
        }

        DataList1.DataSource = stockQuote;
        DataList1.DataBind();
        Label3.Text = DateTime.Now.ToLongTimeString();
    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {
        //Update();
    }

    private string RetrieveQuote(string symbol)
    {
        string responseFromServer = null;
        try
        {
            string requestUrl = String.Format(RequestUrl, symbol);
            WebRequest request = WebRequest.Create(requestUrl);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            responseFromServer = reader.ReadToEnd();
            reader.Close();
            response.Close();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        return responseFromServer;
    }

    private static readonly char[] EmblemsSeparator = new char[] { ',' };
    private const string RequestUrl = @"http://quote.yahoo.com/d/quotes.csv?s={0}&f=pc";
    private static readonly string[] Symbols = new string[] { "AAPL", "MSFT", "IBM" };
    private class StockQuote
    {
        public string Symbol { get; set; }
        public string Quote{get; set;}
    }
}
