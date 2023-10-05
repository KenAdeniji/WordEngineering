#region Using directives
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

using DiggApiNet;
#endregion

#region Digg definition
public partial class Digg : System.Web.UI.Page
{
    #region Methods
    protected void Comments()
    {
        DiggApi.ListComments listComments = new DiggApi.ListComments();
        switch (get.SelectedValue)
        {
            case "GetAll":
                gridViewDigg.DataSource = listComments.GetAll();
                break;

            case "GetPopular":
                gridViewDigg.DataSource = listComments.GetPopular();
                break;

            case "GetUpcoming":
                gridViewDigg.DataSource = listComments.GetUpcoming();
                break;

            case "GetByStoryId":
                gridViewDigg.DataSource = listComments.GetByStoryId(ParseNumbers(id.Text)[0]);
                break;

            case "GetByStoryIds":
                gridViewDigg.DataSource = listComments.GetByStoryIds(ParseNumbers(id.Text));
                break;

            case "GetByUser":
                gridViewDigg.DataSource = listComments.GetByUser(SplitString(username.Text)[0]);
                break;

            case "GetByUsers":
                gridViewDigg.DataSource = listComments.GetByUsers(SplitString(username.Text));
                break;
        }
    }

    protected void ListEvents()
    {
        DiggApi.ListEvents listEvents = new DiggApi.ListEvents();
        switch (get.SelectedValue)
        {
            case "GetAll":
                gridViewDigg.DataSource = listEvents.GetAll();
                break;

            case "GetPopular":
                gridViewDigg.DataSource = listEvents.GetPopular();
                break;

            case "GetUpcoming":
                gridViewDigg.DataSource = listEvents.GetUpcoming();
                break;

            case "GetByStoryId":
                gridViewDigg.DataSource = listEvents.GetByStoryId(ParseNumbers(id.Text)[0]);
                break;

            case "GetByStoryIds":
                gridViewDigg.DataSource = listEvents.GetByStoryIds(ParseNumbers(id.Text));
                break;

            case "GetByUser":
                gridViewDigg.DataSource = listEvents.GetByUser(SplitString(username.Text)[0]);
                break;

            case "GetByUsers":
                gridViewDigg.DataSource = listEvents.GetByUsers(SplitString(username.Text));
                break;

            case "GetByStoryIdByUser":
                gridViewDigg.DataSource = listEvents.GetByStoryIdByUser(ParseNumbers(id.Text)[0], SplitString(username.Text)[0]);
                break;
        }
    }

    protected Int64[] ParseNumbers(string id)
    {
        Int64 number = -1;
        bool numeric = false;

        string[] ids = id.Trim().Split(' ');
        List<Int64> numbers = new List<Int64>();
        foreach (string idCurrent in ids)
        {
            numeric = Int64.TryParse(idCurrent, out number);
            if (numeric)
            {
                numbers.Add(number);
            }
        }
        return numbers.ToArray();
    }

    protected void QuerySubmit_Click(Object sender, EventArgs e)
    {
        try
        {
            DiggApi.AppKey = "http://www.EphraimTech.com";
            switch (list.SelectedValue)
            {
                case "Comments":
                    Comments();
                    break;

                case "Events":
                    ListEvents();
                    break;

                case "Stories":
                    Stories();
                    break;

                case "Topics":
                    Topics();
                    break;

                case "Users":
                    Users();
                    break;
            }
            gridViewDigg.DataBind();
        }
        catch (Exception exception)
        {
            string exceptionMessage = exception.Message;
        }
    }

    protected String[] SplitString(string str)
    {
        string[] strs = str.Trim().Split(' ');
        return strs;
    }

    protected void Stories()
    {
        DiggApi.ListStories listStories = new DiggApi.ListStories();

        switch (get.SelectedValue)
        {
            case "GetAll":
                gridViewDigg.DataSource = listStories.GetAll();
                break;

            case "GetPopular":
                gridViewDigg.DataSource = listStories.GetPopular();
                break;

            case "GetUpcoming":
                gridViewDigg.DataSource = listStories.GetUpcoming();
                break;

            case "GetByContainer":
                gridViewDigg.DataSource = listStories.GetByContainer(name.Text.Trim());
                break;

            case "GetByContainerPopular":
                gridViewDigg.DataSource = listStories.GetByContainerPopular(name.Text.Trim());
                break;

            case "GetByContainerUpcoming":
                gridViewDigg.DataSource = listStories.GetByContainerUpcoming(name.Text.Trim());
                break;

            case "GetByTopic":
                gridViewDigg.DataSource = listStories.GetByTopic(name.Text.Trim());
                break;

            case "GetByTopicPopular":
                gridViewDigg.DataSource = listStories.GetByTopicPopular(name.Text.Trim());
                break;

            case "GetByTopicUpcoming":
                gridViewDigg.DataSource = listStories.GetByTopicUpcoming(name.Text.Trim());
                break;

            case "GetById":
                gridViewDigg.DataSource = listStories.GetById(ParseNumbers(id.Text)[0]);
                break;

            case "GetByIds":
                gridViewDigg.DataSource = listStories.GetByIds(ParseNumbers(id.Text));
                break;

            case "GetByUser":
                gridViewDigg.DataSource = listStories.GetByUser(username.Text.Trim());
                break;

            case "GetByTitle":
                gridViewDigg.DataSource = listStories.GetByTitle(name.Text.Trim());
                break;
        }
    }

    protected void Topics()
    {
        DiggApi.ListTopics listTopics = new DiggApi.ListTopics();
        switch (get.SelectedValue)
        {
            case "GetAll":
                gridViewDigg.DataSource = listTopics.GetAll();
                break;

            case "GetByShortName":
                gridViewDigg.DataSource = listTopics.GetByShortName(name.Text.Trim());
                break;
        }
    }

    protected void Users()
    {
        DiggApi.ListUsers listUsers = new DiggApi.ListUsers();
        switch (get.SelectedValue)
        {
            case "GetAll":
                gridViewDigg.DataSource = listUsers.GetAll();
                break;

            case "GetByUsername":
                gridViewDigg.DataSource = listUsers.GetByUsername(username.Text.Trim());
                break;

            case "GetFriends":
                gridViewDigg.DataSource = listUsers.GetFriends(username.Text.Trim());
                break;

            case "GetFans":
                gridViewDigg.DataSource = listUsers.GetFans(username.Text.Trim());
                break;
        }
    }
    #endregion
}
#endregion
