#region Using directives
using System;
using System.Collections;
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

using org.lyricwiki;
//using WordEngineering.com.wikia.lyrics;
#endregion

//string album = "Painted desert serenade";
//string artist = "Joshua Kadison";
//string song = "Beautiful In My Eyes";
//int year = 1993; 

#region LyricWiki definition
/// <summary>
/// Web reference: http://lyricwiki.org/server.php?wsdl
/// </summary>
public partial class LyricWiki : System.Web.UI.Page
{
    #region Methods
    protected override void OnLoad(EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //message.DataSource = Messages;
            //message.DataBind();
        }
    }

    protected void ResultSet(bool resultSet)
    {
        Feedback = resultSet == true ? "Found" : "Not found";
    }

    public void Search_Click(Object sender, EventArgs e)
    {
        org.lyricwiki.LyricWiki lyricWiki = new org.lyricwiki.LyricWiki();

        bool trueOrFalse = false;
        string[] s = null;
        string refArtist;
        string refAlbum;
        int refYear;

        try
        {
            switch (Message)
            {
                case "Check Song Exists":
                    trueOrFalse = lyricWiki.checkSongExists(Artist, Song);
                    ResultSet(trueOrFalse);
                    break;

                /*
                case "Get Album":
                    refArtist = Artist;
                    refAlbum = Album;
                    refYear = Year;
                    lyricWiki.getAlbum(ref refArtist, ref refAlbum, ref refYear, out s);
                    Feedback = String.Join("<br />", s);
                    break;

                case "Get Artist":
                    refArtist = Artist;
                    s = lyricWiki.getArtist(ref refArtist);
                    Feedback = String.Join("<br />", s);
                    break;

                case "Get Hometown":
                    string hometown;
                    string state;
                    lyricWiki.getHometown(Artist, out state, out hometown);
                    hometown = hometown.Trim();
                    Feedback = String.Format
                    (
                        "{0}{1} {2}",
                        hometown,
                        String.IsNullOrEmpty(hometown) ? "" : ",",
                        state
                    );
                    break;
                */
                case "Get Song":
                    LyricsResult lyricsResult = lyricWiki.getSong(Artist, Song);
                    Feedback = (lyricsResult.lyrics).Trim();

                    HyperLink hyperlink = new HyperLink();
                    hyperlink.NavigateUrl = lyricsResult.url;
                    hyperlink.Text = lyricsResult.url;
                    hyperlink.Target = "_blank";
                    placeHolder.Controls.Add(hyperlink);
                    break;

                /*
                case "Get Song of the Day":
                    SOTDResult sotdResult = lyricWiki.getSOTD();
                    string songOfTheDay = String.Format
                    (
                        "<b>Artist</b>: {0}<br/> <b>Song</b>: {1}<br/> <b>Nominated by</b>: {2}<br/> <b>Reason</b>: {3}<br/> <b>Lyrics</b>: {4}",
                        sotdResult.artist,
                        sotdResult.song,
                        sotdResult.nominatedBy,
                        sotdResult.reason,
                        sotdResult.lyrics
                    );
                    Feedback = songOfTheDay;
                    break;

                case "Search Albums":
                    s = lyricWiki.searchAlbums(Artist, Album, Year);
                    Feedback = String.Join("<br />", s);
                    break;

                case "Search Artists":
                    s = lyricWiki.searchArtists(Artist);
                    Feedback = String.Join("<br />", s);
                    break;

                case "Search Songs":
                    SongResult songResult = lyricWiki.searchSongs(Artist, Song);
                    Feedback = String.Format
                               (
                                    "Artist: {0} | Song: {1}",
                                    songResult.artist,
                                    songResult.song
                                );
                    break;
                */                    
            }
        }
        catch (Exception ex)
        {
            Feedback = ex.Message;
        }
    }
    #endregion

    #region Properties
    /*
    public string Album
    {
        get { return album.Text; }
    }
    */ 

    public string Artist
    {
        get { return artist.Text; }
    }

    public string Feedback
    {
        get { return feedback.Text; }
        set { feedback.Text = value; }
    }
    
    public string Message
    {
        get 
        { 
            //return message.SelectedValue;
            return "Get Song";
        }
    }
    
    public string Song
    {
        get { return song.Text; }
    }

    /*
    public int Year
    {
        get 
        {
            int yearAlbumReleased = 0;
            bool tryParse = Int32.TryParse(year.Text, out yearAlbumReleased);
            return yearAlbumReleased; 
        }
    }
    */ 
    #endregion

    #region Constants
    public static readonly string[] Messages = new string[] 
    {
        "Check Song Exists",
        "Get Album",
        "Get Artist",
        "Get Hometown",
        "Get Song",
        "Get Song of the Day",
        "Search Albums",
        "Search Artists",
        "Search Songs"
    };
    #endregion
}
#endregion