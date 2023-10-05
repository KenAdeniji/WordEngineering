using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using InformationInTransit.ProcessLogic;
using InformationInTransit.com.amazon.soap;

public partial class AmazonSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (Page.IsPostBack == false) { UserInterfaceInitialization(); }
        ClientEventHandler();
    }

    public void ClientEventHandler()
    {
        productInfoDetails.Attributes.Add("onchange", "ProductInfoDetailsItemSelected(this);");
    }

    public void Go_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid) { return; }
        AmazonSearchClassLibraryArgument amazonSearchClassLibraryArgument = new AmazonSearchClassLibraryArgument
        (
            ConfigurationManager.AppSettings["accessKeyID"],
            keyword.Text,
            locale.SelectedIndex < 0 ? locale.Items[0].Text : locale.SelectedItem.Text,
            mode.SelectedValue,
            pageID.Text,
            sort.SelectedValue,
            type.SelectedValue
        );
        ProductInfo productInfo = AmazonSearchClassLibrary.KeywordSearchRequestStub(amazonSearchClassLibraryArgument);
        if (productInfo != null && productInfo.Details != null)
        {
            productInfoDetails.Items.Clear();
            for (int index = 0; index < productInfo.Details.Length; ++index)
            {
                productInfoDetails.Items.Add(productInfo.Details[index].ProductName);
            }
            productInfoDetailsImage.ImageUrl = productInfo.Details[0].ImageUrlLarge;
            PageRegisterClientScriptVariableProductInfo(productInfo);
        }
    }

    public void PageRegisterClientScriptVariableProductInfo(ProductInfo productInfo)
    {
        string varProductInfo;
        StringBuilder productInfoVariableArray = AmazonSearchClassLibrary.ProductInfoVariableArray(productInfo);

        if (productInfoVariableArray != null && productInfoVariableArray.Length != 0)
        {
            if (!Page.ClientScript.IsClientScriptBlockRegistered("varProductInfo"))
            {
                varProductInfo = "var productInfo=" + productInfoVariableArray.ToString() + ';';
                Page.ClientScript.RegisterClientScriptBlock(typeof(AmazonSearch), "varProductInfo", varProductInfo, true);
            }
        }
    }

    public void UserInterfaceInitialization()
    {
        locale.DataSource = Request.UserLanguages;
        locale.DataBind();
        sort.DataSource = InformationInTransit.ProcessLogic.ConfigurationSectionGroup.ToDictionary
        (
            InformationInTransit.ProcessLogic.ConfigurationSectionGroup.GetSectionGroup("amazonSectionGroup", "sort")
        );
        sort.DataTextField = "key";
        sort.DataValueField = "value";
        sort.DataBind();
    }
}
