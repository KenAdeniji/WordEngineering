#region Using directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
using System.Xml.Linq;

using Newtonsoft.Json;
#endregion

#region XmlToJson definition
public partial class XmlToJson : System.Web.UI.Page
{
    #region Methods
    protected string Feedback
    {
        get { return feedback.Text; }
        set { feedback.Text = value; }
    }
    
    protected void Xml2Json_Click(object sender, EventArgs e)
    {
		/*
		XmlDocument doc = new XmlDocument();
        doc.LoadXml(xmlContent.Text);
        XmlNode xmlNode = doc.DocumentElement;
		string jsonText = JsonConvert.SerializeXmlNode(xmlNode);
		jsonContent.Text = jsonText;
		*/
		
		try
		{
			XElement xElement  = XDocument.Parse(xmlContent.Text).Root;
			string json = JsonConvert.SerializeXNode(xElement);
			jsonContent.Text = json;
		}
		catch (Exception ex)
		{
			Feedback = ex.Message;
		}	
    }
    #endregion
}
#endregion
