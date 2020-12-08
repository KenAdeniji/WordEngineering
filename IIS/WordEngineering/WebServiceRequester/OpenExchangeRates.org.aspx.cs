#region Using directives
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
#endregion

#region OpenExchangeRates definition
public partial class OpenExchangeRates : System.Web.UI.Page
{
    #region Methods
    protected void Page_Load(object sender, EventArgs e)
    {
		var url = "http://openexchangerates.org/latest.json";
		var currencyRates = _download_serialized_json_data<CurrencyRates>(url); 
		//feedBack.Text = currencyRates.Rates;
		foreach( KeyValuePair<string, decimal> kvp in currencyRates.Rates )
        {
            string exchangeRate = String.Format
			(
				"Key = {0}, Value = {1} <br/>", 
                kvp.Key,
				kvp.Value
			);
			Response.Write( exchangeRate );
        }
    }
    #endregion

	private static T _download_serialized_json_data<T>(string url) where T : new() 
	{
		using (var w = new WebClient()) {
		var json_data = string.Empty;
		// attempt to download JSON data as a string
		try 
		{
			json_data = w.DownloadString(url);
		}
		catch (Exception) {}
		// if string with JSON data is not empty, deserialize it to class and return its instance 
		return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
	  }
	}
	
	public class CurrencyRates
	{
		public string Disclaimer { get; set; }
		public string License { get; set; }
		public int TimeStamp { get; set; }
		public string Base { get; set; }
		public Dictionary<string, decimal> Rates { get; set; }
	} 
}
#endregion
