using System;
using System.Web;
using System.IO;
using System.Web.UI.WebControls;

using System.Net;
using System.Text.RegularExpressions;

public partial class GoogleExchangeRate : System.Web.UI.Page
{
	public string FeedBack
	{
		set 
		{ 
			feedBack.Text = value;
		}
	}

	public double FromAmount
	{
		get 
		{ 
			double fromValue = -1;
			Double.TryParse(fromAmount.Text, out fromValue);
			return fromValue;
		}
	}

	public string FromCurrency
	{
		get { return fromCurrency.Text.Trim(); }
	}

	public string ToCurrency
	{
		get { return toCurrency.Text.Trim(); }
	}
	
	public decimal Convert(decimal amount, string fromCurrency, string toCurrency)
    {
		WebClient web = new WebClient();

		string url = string.Format
		(
			"http://www.google.com/ig/calculator?hl=en&q={2}{0}%3D%3F{1}", 
			FromCurrency,
			ToCurrency,
			FromAmount
		);

		string response = web.DownloadString(url);

		Regex regex = new Regex("rhs: \\\"(\\d*.\\d*)");
		Match match = regex.Match(response);

		decimal rate = System.Convert.ToDecimal(match.Groups[1].Value);

		//Response.Write( rate );
		feedBack.Text = rate.ToString();
		return rate;
	}
	
	protected void Submit_Click(object sender, EventArgs e)
	{
		Convert(1, "AUD", "USD");
	}
}
