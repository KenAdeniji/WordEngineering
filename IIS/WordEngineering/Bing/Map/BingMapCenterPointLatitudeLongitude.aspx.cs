using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.SqlServer.Types;
using System.Data.SqlClient;
using System.Data;

using WordEngineering;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

/*
The SQL Server's geometry data type sits well within this model.
SQL Server implements the type internally as a .NET type, and thus you can directly use the same type in your own applications. 
The type is defined in the assembly Microsoft.SqlServer.Types.dll, which by default resides in the folder C:\Program Files\Microsoft SQL Server\100\SDK\Assemblies.
*/
public partial class Bing_Map_BingMapCenterPointLatitudeLongitude : System.Web.UI.Page
{
    public const string IFrameBingSourceStringFormat = "http://www.bing.com/maps/default.aspx?cp={0}~{1}";

    public const int GridViewGeometryPoint_ColumnIndex_Points = 3;

    protected void Page_Load(object sender, EventArgs e)
    {
        RetrievePointIntoDatabase();
    }

    protected void AddPoint_Click(object sender, EventArgs e)
    {
        double x = double.Parse(latitude.Text);
        double y = double.Parse(longitude.Text);
        string desc = description.Text;

        SqlGeometry geomentry = SqlGeometry.Point(x, y, 0);

        // add to database
        string sql = "INSERT INTO [GeometryJaniJarvinen] " +
          "([points], [description]) VALUES " +
          "(@points, @description)";
        StorePointIntoDatabase
        (
            geomentry,
            sql,
            "geometry", //geography
            desc
        );
    }

    public void GridViewGeometryPoint_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        object cache = ViewState["Bing_Map_BingMapCenterPointLatitudeLongitude"];
        if (cache != null)
        {
            gridViewGeometryPoint.DataSource =
                (List<GeometryJaniJarvinenIncludeSqlGeometryMissingFromEntityFramework>)
                    cache;
            gridViewGeometryPoint.PageIndexChange(e);
        }
    }

    protected void GridViewGeometryPoint_SelectedIndexChanged(Object sender, EventArgs e)
    {

        // Get the currently selected row using the SelectedRow property.
        GridViewRow selectedGridViewRow = gridViewGeometryPoint.SelectedRow;

        System.Data.SqlTypes.SqlString points = (System.Data.SqlTypes.SqlString)
            selectedGridViewRow.Cells[GridViewGeometryPoint_ColumnIndex_Points].Text;
        SqlGeometry geometryPoint = SqlGeometry.Parse(points);
        IFrameRefresh(geometryPoint.STX, geometryPoint.STY);
    }

    protected virtual void GridViewGeometryPoint_Sorting(object sender, GridViewSortEventArgs e)
    {
        object cache = ViewState["Bing_Map_BingMapCenterPointLatitudeLongitude"];
        if (cache != null)
        {
            List<GeometryJaniJarvinenIncludeSqlGeometryMissingFromEntityFramework>
                geometryJaniJarvinens = (List<GeometryJaniJarvinenIncludeSqlGeometryMissingFromEntityFramework>)
                    cache;
            gridViewGeometryPoint.DataSource = geometryJaniJarvinens;
            string sortDirection = "";
            string sortInfo = "";
            gridViewGeometryPoint.SortInfo(e, ref sortDirection, ref sortInfo);
            switch (e.SortExpression)
            {
                case "Id":
                    if (sortDirection == "Asc")
                    {
                        geometryJaniJarvinens = geometryJaniJarvinens.OrderBy(geo => geo.Id).ToList();
                    }
                    else
                    {
                        geometryJaniJarvinens = geometryJaniJarvinens.OrderByDescending(geo => geo.Id).ToList();
                    }
                    break;
                case "Dated":
                    if (sortDirection == "Asc")
                    {
                        geometryJaniJarvinens = geometryJaniJarvinens.OrderBy(geo => geo.Dated).ToList();
                    }
                    else
                    {
                        geometryJaniJarvinens = geometryJaniJarvinens.OrderByDescending(geo => geo.Dated).ToList();
                    }
                    break;
                case "Points":
                    if (sortDirection == "Asc")
                    {
                        geometryJaniJarvinens = geometryJaniJarvinens.OrderBy(geo => geo.Points).ToList();
                    }
                    else
                    {
                        geometryJaniJarvinens = geometryJaniJarvinens.OrderByDescending(geo => geo.Points).ToList();
                    }
                    break;
                case "Description":
                    if (sortDirection == "Asc")
                    {
                        geometryJaniJarvinens = geometryJaniJarvinens.OrderBy(geo => geo.Description).ToList();
                    }
                    else
                    {
                        geometryJaniJarvinens = geometryJaniJarvinens.OrderByDescending(geo => geo.Description).ToList();
                    }
                    break;
            }
            gridViewGeometryPoint.DataSource = geometryJaniJarvinens;
            gridViewGeometryPoint.DataBind();
        }
    }

    internal void LoadPointIntoDatabase()
    {
        UserDbEntities context = new UserDbEntities();
        List<GeometryJaniJarvinen> listGeometryJaniJarvinen = null;
        listGeometryJaniJarvinen = context.GeometryJaniJarvinens.ToList();
        /*
        var geometryJaniJarvinens = from geometryJaniJarvinen in context.GeometryJaniJarvinens
                                    select new
                                    {
                                        geometryJaniJarvinen.ID,
                                        geometryJaniJarvinen.Dated,
                                        geometryJaniJarvinen.Description
                                    };
        */
        gridViewGeometryPoint.DataSource = listGeometryJaniJarvinen;
        gridViewGeometryPoint.DataBind();
    }

    internal void RetrievePointIntoDatabase()
    {
        List<GeometryJaniJarvinenIncludeSqlGeometryMissingFromEntityFramework> geometryJaniJarvinens =
            new List<GeometryJaniJarvinenIncludeSqlGeometryMissingFromEntityFramework>();

        string connectionString = DataCommand.ReadConnectionString("UserDb");

        SqlConnection sqlConnection = DataCommand.GainConnection(connectionString);

        string sql = "SELECT TOP 1000 * FROM GeometryJaniJarvinen ORDER BY ID DESC";

        IDataReader dataReader = null;
        try
        {
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);

            dataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            bool dataRead = true;

            int id;
            DateTime dated;
            SqlGeometry geometryPoint;
            String description;

            while (true)
            {
                dataRead = dataReader.Read();
                if (dataRead == false) { break; }
                id = dataReader.GetInt32(0);
                dated = dataReader.GetDateTime(1);
                geometryPoint = (SqlGeometry)dataReader.GetValue(2);
                description = dataReader.GetString(3);
                GeometryJaniJarvinenIncludeSqlGeometryMissingFromEntityFramework
                    geometryJaniJarvinen = new
                        GeometryJaniJarvinenIncludeSqlGeometryMissingFromEntityFramework()
                {
                    Id = id,
                    Dated = dated,
                    Points = geometryPoint,
                    Description = description
                };
                geometryJaniJarvinens.Add(geometryJaniJarvinen);
            }
            dataReader.Close();
            gridViewGeometryPoint.DataSource = geometryJaniJarvinens;
            gridViewGeometryPoint.DataBind();
            ViewState["Bing_Map_BingMapCenterPointLatitudeLongitude"] =
                geometryJaniJarvinens;
        }
        catch (Exception ex)
        {
        }
    }

    internal int StorePointIntoDatabase
    (
        object geoPoint,
        string sql,
        string udtTypeName,
        string description
    )
    {
        string connectionString = DataCommand.ReadConnectionString("UserDb");

        SqlConnection sqlConnection = DataCommand.GainConnection(connectionString);
        try
        {
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("@points", geoPoint);
            sqlParameter.UdtTypeName = udtTypeName;
            sqlCommand.Parameters.AddWithValue("@description", description);
            if (sqlConnection != null) { sqlConnection.Close(); }   
            sqlConnection.Open();
            int rows = sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose();
            return rows;
        }
        finally
        {
            sqlConnection.Dispose();
        }
    }

    protected void Query_Click(object sender, EventArgs e)
    {
        IFrameRefresh(latitude.Text, longitude.Text);
    }

    protected void IFrameRefresh(object latitudeValue, object longitudeValue)
    {
        String iframeBingSource = String.Format
        (
            IFrameBingSourceStringFormat,
            latitudeValue,
            longitudeValue
        );

        iframeBing.Attributes.Add("src", iframeBingSource);
    }
}
