using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WordEngineering
{
    public partial class NumberConverterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			if (Page.IsPostBack == false)
			{
				dropDownListBase.DataSource = NumberBase;
				dropDownListBase.DataBind();
			}
        }
		
        protected void Submit_Click(object sender, EventArgs e)
        {
			string sourceNumber = source.Text;
			switch( dropDownListBase.SelectedValue )
			{
				case "Binary":
					long numberBase10 = Convert.ToInt64(sourceNumber, 2);
					
					Int64 decimalNumber = BinaryConverter.BinaryToDecimal(sourceNumber);
					long numberBase8 = DecimalConverter.DecimalToOctal(decimalNumber);
					
					string numberBase16 = DecimalConverter.DecimalToHex(decimalNumber);
					
					feedBack.Text = String.Format
					(
						ResultFormat,
						sourceNumber,	
						numberBase8,
						numberBase10,
						numberBase16
					);	
					break;
				
				case "Octal":
					Int64 octalToDecimal = Convert.ToInt64(Convert.ToString(Convert.ToInt64(sourceNumber,8), 10));	
					string octalToBinary = DecimalConverter.DecimalToBinary(octalToDecimal);
					string octalToHex = DecimalConverter.DecimalToHex(octalToDecimal);
					feedBack.Text = String.Format
					(
						ResultFormat,
						octalToBinary,
						sourceNumber,
						octalToDecimal,	
						octalToHex
					);	
					break;
					
				case "Decimal":	
					long decimalNumberBase10 = Convert.ToInt64(sourceNumber);
					string decimalNumberBase2 = DecimalConverter.DecimalToBinary(decimalNumberBase10);
					long decimalNumberBase8 = DecimalConverter.DecimalToOctal(decimalNumberBase10);
					string decimalNumberBase16 = DecimalConverter.DecimalToHex(decimalNumberBase10);
					
					feedBack.Text = String.Format
					(
						ResultFormat, 
						decimalNumberBase2,
						decimalNumberBase8,
						sourceNumber,
						decimalNumberBase16
					);	
					break;
				
				case "Hex":
					string hexToBinary = Convert.ToString(Convert.ToInt32(sourceNumber, 16), 2);
					string hexToOctal = Convert.ToString(Convert.ToInt32(sourceNumber, 16), 8);
					string hexToDecimal = Convert.ToString(Convert.ToInt32(sourceNumber, 16), 10);

					feedBack.Text = String.Format
					(
						ResultFormat, 
						hexToBinary,
						hexToOctal,
						hexToDecimal,
						sourceNumber
					);	
					break;	
            }
	    }
        
        public const string ResultFormat = "Binary: {0}<br/>Octal: {1}<br/>Decimal: {2}<br/>Hex: {3}"; 
		public static string[] NumberBase = { "Binary", "Octal", "Decimal", "Hex" };
    }
	
	public static class BinaryConverter
	{
		public static Int64 BinaryToDecimal(string bin)
		{
			long l = Convert.ToInt64(bin, 2);
			int i = (int)l;
			return i;
		}
		
		public static Int64 BinaryToOctal(string bin)
		{
			Int64 Deci = BinaryConverter.BinaryToDecimal(bin);
			return DecimalConverter.DecimalToOctal(Deci);
		}
		
		public static string BinaryToHex(string bin)
		{
			Int64 Deci = BinaryConverter.BinaryToDecimal(bin);
			return DecimalConverter.DecimalToHex(Deci);
		}
	}
	
	public static class DecimalConverter
	{
		public static string DecimalToBinary(Int64 DecimalNumber)
		{
			return Convert.ToString(Convert.ToString(Convert.ToInt64(DecimalNumber), 2));
		}
		
		public static Int64 DecimalToOctal(Int64 DecimalNumber)
	    {
	        return Convert.ToInt64(Convert.ToString(Convert.ToInt64(DecimalNumber), 8));
		}
		
		public static string DecimalToHex(Int64 DecimalNumber)
	    {
			return DecimalNumber.ToString("X"); ;
	    }
	}
}
