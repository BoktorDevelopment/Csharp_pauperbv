using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace pauperbv_2._0.Models
{
    public class song
    {
        private string stringID;
        private int id;
        public DataSet ds = new DataSet("playlist");

        DataTable dtSongs = new DataTable("song");
        DataColumn dtID = new DataColumn("id");
        DataColumn dtArtist = new DataColumn("artist");
        DataColumn dtTitle = new DataColumn("title");
        DataColumn dtYear = new DataColumn("year");
        DataColumn dtGenre = new DataColumn("genre");
        DataColumn dtTime = new DataColumn("time");
        DataColumn dtFile = new DataColumn("file");

        public song()
        {
            ds.Tables.Add(dtSongs);
            dtSongs.Columns.Add(dtID);
            dtSongs.Columns.Add(dtArtist);
            dtSongs.Columns.Add(dtTitle);
            dtSongs.Columns.Add(dtYear);
            dtSongs.Columns.Add(dtGenre);
            dtSongs.Columns.Add(dtTime);
            dtSongs.Columns.Add(dtFile);

            getSongs();
        }

            public void getSongs()
            {

                ds.ReadXml(System.Web.HttpContext.Current.Server.MapPath("../data/songs.xml"));
            }
            public void getLastID()
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    stringID = dr["id"].ToString();

                }
                try
                {
                    id = int.Parse(stringID);
                }
                catch
                {
                    id = 0;
                }

            }


            public void addsong()
            {
                getLastID();
                id++;

                string artist = HttpContext.Current.Request.Form["artist"];
                string title = HttpContext.Current.Request.Form["title"];
                string year = HttpContext.Current.Request.Form["year"];
                string genre = HttpContext.Current.Request.Form["genre"];
                string time = HttpContext.Current.Request.Form["time"];
                string file = HttpContext.Current.Request.Form["file"];

            string code = file.Replace("watch?v=", "embed/");

                DataRow dr = ds.Tables[0].NewRow();

                dr["id"] = id;
                dr["artist"] = artist;
                dr["title"] = title;
                dr["year"] = year;
                dr["genre"] = genre;
                dr["time"] = time;
                dr["file"] = code;

                ds.Tables[0].Rows.Add(dr);

                ds.WriteXml(System.Web.HttpContext.Current.Server.MapPath("../data/songs.xml"));


            }

            public void deleteSong()
            {
                string id = HttpContext.Current.Request.QueryString["id"];
                

                DataRow[] dRows = ds.Tables[0].Select("id='" + id + "'");
                dRows[0].Delete();

                ds.WriteXml(System.Web.HttpContext.Current.Server.MapPath("../data/songs.xml"));
            }



            public DataRow editSong()
            {
            string id = HttpContext.Current.Request.QueryString["id"];


            DataRow[] dRows = ds.Tables[0].Select("id='" + id + "'");

             return dRows[0];
        }

        public void editSongSend()
        {
            string artist = HttpContext.Current.Request.Form["artist"];
            string title = HttpContext.Current.Request.Form["title"];
            string year = HttpContext.Current.Request.Form["year"];
            string genre = HttpContext.Current.Request.Form["genre"];
            string time = HttpContext.Current.Request.Form["time"];
            string file = HttpContext.Current.Request.Form["file"];

            string id = HttpContext.Current.Request.QueryString["id"];

            DataRow[] dRows = ds.Tables[0].Select("id='" + id + "'");
            DataRow dr = dRows[0];
            

            dr["id"] = id;
            dr["artist"] = artist;
            dr["title"] = title;
            dr["year"] = year;
            dr["genre"] = genre;
            dr["time"] = time;
            dr["file"] = file;


            ds.WriteXml(System.Web.HttpContext.Current.Server.MapPath("../data/songs.xml"));
        }

        public string playSong()
        {
            string code = HttpContext.Current.Request.QueryString["code"];

            return code;
        }

            

        }
    }