using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Xml;

namespace project_Csharp.csfiles
{
    public class Xml
    {
       public DataSet ds = new DataSet("playlist");

        public void getSongs() {
            
            DataTable dtSongs = new DataTable("song");

            DataColumn dtID = new DataColumn("id");
            DataColumn dtArtist = new DataColumn("artist");
            DataColumn dtTitle = new DataColumn("title");
            DataColumn dtYear = new DataColumn("year");
            DataColumn dtGenre = new DataColumn("genre");
            DataColumn dtTime = new DataColumn("time");
            DataColumn dtFile = new DataColumn("file");

            ds.Tables.Add(dtSongs);
            dtSongs.Columns.Add(dtID);
            dtSongs.Columns.Add(dtArtist);
            dtSongs.Columns.Add(dtTitle);
            dtSongs.Columns.Add(dtYear);
            dtSongs.Columns.Add(dtGenre);
            dtSongs.Columns.Add(dtTime);
            dtSongs.Columns.Add(dtFile);

            ds.ReadXml(System.Web.HttpContext.Current.Server.MapPath("data/playlist.xml"));
        }


        public void addsong()
        {
        }
          
    }
}