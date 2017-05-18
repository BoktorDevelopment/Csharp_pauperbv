﻿using System;
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

        DataTable dtSongs = new DataTable("song");
        DataColumn dtID = new DataColumn("id");
        DataColumn dtArtist = new DataColumn("artist");
        DataColumn dtTitle = new DataColumn("title");
        DataColumn dtYear = new DataColumn("year");
        DataColumn dtGenre = new DataColumn("genre");
        DataColumn dtTime = new DataColumn("time");
        DataColumn dtFile = new DataColumn("file");

        public void getSongs() {
            
            

          

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
            if (HttpContext.Current.Request.HttpMethod == "POST") 
            {
                string artist = HttpContext.Current.Request.Form["artist"];
                string title = HttpContext.Current.Request.Form["title"];
                string year = HttpContext.Current.Request.Form["year"];
                string genre = HttpContext.Current.Request.Form["genre"];
                string time = HttpContext.Current.Request.Form["time"];
                string file = HttpContext.Current.Request.Form["file"];

                DataRow dr = ds.Tables[0].NewRow();

                dr["artist"] = artist;
                dr["title"] = title;
                dr["year"] = year;
                dr["genre"] = genre;
                dr["time"] = time;
                dr["file"] = file;

                ds.Tables[0].Rows.Add(dr);

                ds.WriteXml(System.Web.HttpContext.Current.Server.MapPath("data/playlist.xml"));
            }


        }
          
    }
}