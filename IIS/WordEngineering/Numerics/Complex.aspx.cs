using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Numerics;

namespace WordEngineering
{
    /// <summary>
    /// 2014-04-12 Complex.aspx.cs created.
    /// 2014-04-11 i-programmer.info/programming/c/1068-not-so-complex-numbers-in-c.html
    /// </summary>
    public partial class ComplexPage : System.Web.UI.Page
    {
		public String FeedBack
		{
			get 
			{ 
				return feedBack.Text;
			}
			set
			{
				 feedBack.Text = value.ToString();
			}	
		}

		public Complex FirstNumber
		{
			get 
			{ 
				Complex numberParse = DeriveComplex(firstNumber.Text);
				return numberParse;
			}
			set
			{
				 firstNumber.Text = value.ToString();
			}	
		}

		public Complex SecondNumber
		{
			get 
			{ 
				Complex numberParse = DeriveComplex(secondNumber.Text);
				return numberParse;
			}
			set
			{
				 secondNumber.Text = value.ToString();
			}	
		}
		
		protected void Page_Load(object sender, EventArgs e)
        {
			if (Page.IsPostBack == false)
			{
				FirstNumber = new Complex(11, 11);
				SecondNumber = new Complex(11, 11);
			}
        }
		
        protected void Submit_Click(object sender, EventArgs e)
        {
			Complex add = FirstNumber + SecondNumber;
			FeedBack = String.Format
			(
				FeedBackFormat,
				add
			);
	    }
        
		public static Complex DeriveComplex(string complexString) //a + bi
		{
			complexString = complexString.Replace(" ", String.Empty);
			int position = complexString.IndexOf('+');
			
			string realString = complexString.Substring(0, position);
			double realNumber = 0;
			bool parse = Double.TryParse(realString, out realNumber);
			
			string imaginaryString = complexString.Substring(position + 1, complexString.Length - position - 2);
			double imaginaryNumber = 0;
			parse = Double.TryParse(imaginaryString, out imaginaryNumber);
			
			return new Complex((int)realNumber, (int)imaginaryNumber);
		}
		
        public const string FeedBackFormat = 
			@"Add: {0}<br/>"; 
    }
}
