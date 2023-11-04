/*
	2023-11-04T04:58:00	http://www.c-sharpcorner.com/blogs/convert-number-to-words-in-c-sharp
		 Amit Mohanty
			Amit Mohanty [Top 50]
			Senior Software Engineer | Author | Dreamer | Believer | Learner !!
	2023-11-04T05:33:00	http://ourcodeworld.com/articles/read/353/how-to-convert-numbers-to-words-number-spelling-in-javascript			
*/
using System;

namespace ProcessCode
{
    public static partial class NumberToWords  
    {  
        private static string[] units = { "Zero", "One", "Two", "Three",  
        "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven",  
        "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",  
        "Seventeen", "Eighteen", "Nineteen" };  
        private static String[] tens = { "", "", "Twenty", "Thirty", "Forty",  
        "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };  
      
        public static string ConvertAmount(this double amount)  
        {  
            try  
            {  
                Int64 amount_int = (Int64)amount;  
                Int64 amount_dec = (Int64)Math.Round((amount - (double)(amount_int)) * 100);  
                if (amount_dec == 0)  
                {  
                    return Convert(amount_int) + " Only.";  
                }  
                else  
                {  
                    return Convert(amount_int) + " Point " + Convert(amount_dec) + " Only.";  
                }  
            }  
            catch (Exception e)  
            {  
                // TODO: handle exception  
            }  
            return "";  
        }  
      
        public static string Convert(this Int64 i)  
        {  
            if (i < 20)  
            {  
                return units[i];  
            }  
            if (i < 100)  
            {  
                return tens[i / 10] + ((i % 10 > 0) ? " " + Convert(i % 10) : "");  
            }  
            if (i < 1000)  
            {  
                return units[i / 100] + " Hundred"  
                        + ((i % 100 > 0) ? " And " + Convert(i % 100) : "");  
            }  
            if (i < 100000)  
            {           return Convert(i / 1000) + " Thousand "  
                        + ((i % 1000 > 0) ? " " + Convert(i % 1000) : "");  
            }  
            if (i < 10000000)  
            {  
                return Convert(i / 100000) + " Lakh "  
                        + ((i % 100000 > 0) ? " " + Convert(i % 100000) : "");  
            }  
            if (i < 1000000000)  
            {  
                return Convert(i / 10000000) + " Crore "  
                        + ((i % 10000000 > 0) ? " " + Convert(i % 10000000) : "");  
            }  
            return Convert(i / 1000000000) + " Arab "  
                    + ((i % 1000000000 > 0) ? " " + Convert(i % 1000000000) : "");  
        }  
    
		public static void Main(string[] args)  
		{  
			try  
			{  
				Console.WriteLine("Enter a Number to convert to words");  
				string number = Console.ReadLine();  
				number = ConvertAmount(double.Parse(number));  
		  
				Console.WriteLine("Number in words is \n{0}", number);  
				Console.ReadKey();  
			}  
			catch (Exception ex)  
			{  
				Console.WriteLine(ex.Message);  
			}  
		}
	}	
}
