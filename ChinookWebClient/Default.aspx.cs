using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ChinookServiceRef;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ChinookServiceClient client = new ChinookServiceClient("BasicHttpBinding_IChinookService");
        List<ArtistDTO> artists = client.GetArtists();
        List<string> artistNames = new List<string>();
        foreach (var artist in artists)
        {
            artistNames.Add(artist.Name);
        }
        GridView1.DataSource = artistNames;
        GridView1.DataBind();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        GridView1.Visible = false;
        ChinookServiceClient client = new ChinookServiceClient("NetTcpBinding_IChinookService");
        List<ArtistAlbums> artistAlbums = new List<ArtistAlbums>();
        artistAlbums = client.GetArtistsAlbums();
        foreach (var artistAlbum in artistAlbums)
        {
            if (artistAlbum.Albums.Count > 0)
            {
                Response.Write("Artist : " + "<strong>"+ artistAlbum.Name + "</strong><br/> Albums: <br/>");
                foreach (var album in artistAlbum.Albums)
                {
                    Response.Write("-------   " + "<span style='color:crimson'>"
                       + album + "</span>   ------- <br/>");
                }
                Response.Write("------------------------------------------------------------- <br/><br/>");
            }
        }           
    }
}