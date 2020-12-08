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

public partial class GoogleMapVersion3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<String> oGeocodeList = new List<String>
	    {
	     " '40.756012, -73.972614' ",
	     " '40.456012, -73.796087' ",
	     " '40.456012, -73.456807' "
	     };

        var geocodevalues = string.Join(",", oGeocodeList.ToArray());

        List<String> oMessageList = new List<String>
	     {
	     " '<span class=formatText >Google Map 3 Awesome !!!</span>' ",
	     " '<span class=formatText>Made it very simple</span>' ",
	     " '<span class=formatText>Google Rocks</span>' "
	     };

        String message = string.Join(",", oMessageList.ToArray());

        ClientScript.RegisterArrayDeclaration("locationList", geocodevalues);

        ClientScript.RegisterArrayDeclaration("message", message);
    }
}
