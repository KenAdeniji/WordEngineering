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
using System.Xml.Linq;

using InformationInTransit.ProcessLogic;
#endregion

#region StudentClass definition
public partial class StudentClass : System.Web.UI.Page
{
    #region Methods
    protected string Feedback
    {
        get { return feedback.Text; }
        set { feedback.Text = value; }
    }
    
    protected override void OnLoad(EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GridViewStudentClass.DataSource = InformationInTransit.ProcessLogic.StudentClass.students;
            //Persist the table in the Session object.
            Session["StudentClass"] = InformationInTransit.ProcessLogic.StudentClass.students;

            //Bind data to the GridView control.
            BindData();
        }
    }

    private void BindData()
    {
        GridViewStudentClass.DataSource = Session["StudentClass"];
        GridViewStudentClass.DataBind();
    }

    protected void StudentClassGridView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //Set the edit index.
        GridViewStudentClass.EditIndex = e.NewEditIndex;
        //Bind data to the GridView control.
        BindData();
    }

    protected void StudentClassGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        //Reset the edit index.
        GridViewStudentClass.EditIndex = -1;
        //Bind data to the GridView control.
        BindData();
    }

    protected void StudentClassGridView_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        // Use the Exception property to determine whether an exception
        // occurred during the insert operation.
        if ( e.Exception != null )
        {
            // Insert the code to handle the exception.
            Feedback = e.Exception.Message;

            // Use the ExceptionHandled property to indicate that the 
            // exception is already handled.
            e.ExceptionHandled = true;

            // When an exception occurs, keep the GridView
            // control in edit mode.
            e.KeepInEditMode = true;
        }
    }

    protected void StudentClassGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //Retrieve the table from the session object.
        List<InformationInTransit.ProcessLogic.StudentClass.Student> students =
            (List<InformationInTransit.ProcessLogic.StudentClass.Student>)Session["StudentClass"];

        //Update the values.
        GridViewRow row = GridViewStudentClass.Rows[e.RowIndex];

        int id;
        string firstName;
        string lastName;

        Int32.TryParse(((System.Web.UI.WebControls.Label)row.FindControl("LabelID")).Text, out id);
        firstName = Server.HtmlEncode(((System.Web.UI.WebControls.TextBox)row.FindControl("textBoxFirstName")).Text);
        lastName = Server.HtmlEncode(((System.Web.UI.WebControls.TextBox)row.FindControl("textBoxLastName")).Text);

        students[e.RowIndex].FirstName = Server.HtmlDecode(firstName);
        students[e.RowIndex].LastName = Server.HtmlDecode(lastName);

        Session["StudentClasss"] = students;

        //Reset the edit index.
        GridViewStudentClass.EditIndex = -1;

        //Bind data to the GridView control.
        BindData();
    }

    #endregion
}
#endregion
