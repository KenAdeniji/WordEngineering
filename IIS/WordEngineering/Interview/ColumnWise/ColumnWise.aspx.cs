using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;

namespace WordEngineering
{
    public partial class ColumnWise : System.Web.UI.Page
    {
        // Format any given string array "columnwise" into 3 compact html columns (notice the example output is ordered by column, not by row)
        // The last row is only row that can be short (i.e.  the last row can have zero, one or two empty cells. no other row can have empty cells)
        // Display your output in an HTML table like the one below (Response.Write is fine)
        //
        // <table>
        // <tr><td>item 1</td><td>item 5</td><td>item 8</td></tr>
        // <tr><td>item 2</td><td>item 6</td><td>item 9</td></tr>
        // <tr><td>item 3</td><td>item 7</td><td>item 10</td></tr>
        // <tr><td>item 4</td><td></td><td></td></tr>
        // </table>
        //
        // Take your time and do a good job. This is part of our interview process.
        // The program must run and deliver a correct result for you to be considered as a candidate.
        // We will also evaluate your coding style. Please take the time to show us your best work in  
        // - choice of tools and approach
        // - code structure
        // - variable and method naming
        // - understandability 
        // - efficiency
        //
        // PLEASE be sure to check and provide a variety of test cases
        // Extra credit for flexibility, gorgeous output and general awesomeness

        //sample test case 
        string[] sampleTestCase1 = { "item 1", "item 2", "item 3", "item 4", "item 5", "item 6", "item 7", "item 8", "item 9", "item 10", "item 11" };
		int ColumnsCount = 3;

        protected void Page_Load(object sender, EventArgs e)
        {

            // Write your code here to create your html output using sampleTestCase1 and other test cases
			int itemCount = 0;
			int itemsLength = sampleTestCase1.Length;
			int itemPosition = 0;
			StringBuilder sb = new StringBuilder();
			sb.Append("<table>");
			foreach (string sample in sampleTestCase1)
			{
				itemPosition = itemCount % ColumnsCount;
				if (itemPosition == 0)
				{
					sb.Append("<tr>");
				}
				sb.AppendFormat("<td>{0}</td>", sample);
				++itemCount;
				if (itemPosition == 2)
				{
					sb.Append("</tr>");
				}	
			}
			if ( itemCount > 0)
			{
				sb.Append("</tr></table>");
			}
			Response.Write(sb);
        }
    }
}
