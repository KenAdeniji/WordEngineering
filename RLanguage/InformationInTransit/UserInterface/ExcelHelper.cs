#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
#endregion

namespace InformationInTransit.UserInterface
{
    #region ExcelHelper
    public static partial class ExcelHelper
    {
        #region Methods
        /// <summary>
        /// To export all the rows, when paging is enabled.
        ///     gridView.AllowPaging = false;
        ///     gridView.DataBind();
        ///     
        /// To export the first 100 rows.
        ///     gridView.PageSize = 100;
        ///     gridView.DataBind();
        /// </summary>
        public static void ToExcel(this GridView gv, string fileName)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader(
                "content-disposition", string.Format("attachment; filename={0}", fileName));
            HttpContext.Current.Response.ContentType = "application/ms-excel";

            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    //  Create a table to contain the grid
                    Table table = new Table();

                    //  include the gridline settings
                    table.GridLines = gv.GridLines;

                    //  add the header row to the table
                    if (gv.HeaderRow != null)
                    {
                        gv.HeaderRow.ObjectLiteralReplacement();
                        table.Rows.Add(gv.HeaderRow);
                    }

                    //  add each of the data rows to the table
                    foreach (GridViewRow row in gv.Rows)
                    {
                        row.ObjectLiteralReplacement();
                        table.Rows.Add(row);
                    }

                    //  add the footer row to the table
                    if (gv.FooterRow != null)
                    {
                        gv.FooterRow.ObjectLiteralReplacement();
                        table.Rows.Add(gv.FooterRow);
                    }

                    //  render the table into the htmlwriter
                    table.RenderControl(htw);

                    //  render the htmlwriter into the response
                    HttpContext.Current.Response.Write(sw.ToString());
                    HttpContext.Current.Response.End();
                }
            }
        }
        #endregion
    }
    #endregion
}
