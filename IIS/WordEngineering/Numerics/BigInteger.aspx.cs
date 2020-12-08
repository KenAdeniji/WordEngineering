using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Numerics;

namespace WordEngineering
{
    public partial class BigIntegerPage : System.Web.UI.Page
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

		public BigInteger FirstNumber
		{
			get 
			{ 
				BigInteger numberParse = 0;
				BigInteger.TryParse(firstNumber.Text, out numberParse);
				return numberParse;
			}
			set
			{
				 firstNumber.Text = value.ToString();
			}	
		}

		public BigInteger SecondNumber
		{
			get 
			{ 
				BigInteger numberParse = 0;
				BigInteger.TryParse(secondNumber.Text, out numberParse);
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
				FirstNumber = Int64.MaxValue;
				SecondNumber = Int64.MaxValue;
			}
        }
		
        protected void Submit_Click(object sender, EventArgs e)
        {
			BigInteger add = BigInteger.Add(FirstNumber, SecondNumber);
			BigInteger divide = BigInteger.Divide(FirstNumber, SecondNumber);
			BigInteger greatestCommonDivisor = BigInteger.GreatestCommonDivisor(FirstNumber, SecondNumber);
			BigInteger max = BigInteger.Max(FirstNumber, SecondNumber);
			BigInteger min = BigInteger.Min(FirstNumber, SecondNumber);
			BigInteger multiply = BigInteger.Multiply(FirstNumber, SecondNumber);
			//BigInteger pow = BigInteger.Pow(FirstNumber, (int)SecondNumber);
			FeedBack = String.Format
			(
				FeedBackFormat,
				add,
				divide,
				greatestCommonDivisor,
				max,
				min,
				multiply
			);
	    }
        
        public const string FeedBackFormat = 
			@"Add: {0}<br/>Divide: {1}<br/>GreatestCommonDivisor: {2}<br/>Max: {3}<br/>Min: {4}<br/>Multiply: {5}<br/>"; 
    }
}
