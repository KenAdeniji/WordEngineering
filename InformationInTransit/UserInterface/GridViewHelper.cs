#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Collections.ObjectModel;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
#endregion

namespace InformationInTransit.UserInterface
{
    #region GridViewHelper definition
    public static partial class GridViewHelper
    {
        #region Methods
        public static void PageIndexChange(this GridView gridView, GridViewPageEventArgs e)
        {
            gridView.PageIndex = e.NewPageIndex;
            gridView.DataBind();
        }

        public static Collection<GridViewRow> RetrieveCheckedRows(this GridView gridView, string checkBoxId)
        {
            Collection<GridViewRow> checkedRows = new Collection<GridViewRow>();

            foreach (GridViewRow gridViewRow in gridView.Rows)
            {
                CheckBox checkBox = (CheckBox) gridViewRow.FindControl(checkBoxId);

                if (checkBox != null)
                {
                    if (checkBox.Checked)
                    {
                        checkedRows.Add(gridViewRow);
                    }
                }
            }
            return checkedRows;
        }

        public static void Sort(this GridView gridView, GridViewSortEventArgs e)
        {
            object dataSource;
            DataTable dataTable = null;
            DataView dataView;

            string sortDirection = null;
            string sortInfo = null;
            dataSource = gridView.DataSource;

            if (dataSource is DataSet)
            {
                dataTable = ((DataSet)dataSource).Tables[0];
            }
            else if (dataSource is DataTable)
            {
                dataTable = (DataTable)dataSource;
            }

            dataView = new DataView(dataTable);

            gridView.SortInfo(e, ref sortDirection, ref sortInfo);

            dataView.Sort = sortInfo;
            gridView.DataSource = dataView;
            gridView.DataBind();
        }

        public static void SortInfo
        (
            this GridView gridView,
            GridViewSortEventArgs e,
            ref string sortDirection,
            ref string sortInfo
        )
        {
            object viewStateValue;
            string sortKey = "";
            sortKey = e.SortExpression;
            sortInfo = "";
            string viewStateKey;

            viewStateKey = gridView.ClientID + e.SortExpression.ToString() + "sortDirection";
            viewStateValue = HttpContext.Current.Session[viewStateKey];
            if (viewStateValue != null)
            {
                sortDirection = viewStateValue.ToString();
            }
            if (sortDirection == "Asc") { sortDirection = "Desc"; }
            else { sortDirection = "Asc"; }
            HttpContext.Current.Session[viewStateKey] = sortDirection;

            sortInfo = sortKey.Replace(",", " " + sortDirection + ",");
            sortInfo += ' ' + sortDirection;
        }
        #endregion
    }
    #endregion
}