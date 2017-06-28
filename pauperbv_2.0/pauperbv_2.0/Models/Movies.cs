using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;
using Newtonsoft.Json;

namespace pauperbv_2._0.Models
{
    public class Movies
    {
        List<Movie> bsObj;

        private int id;
        private string stringID;

        public Movies()
        {
            string json = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("../data/movies.json"));


          

            bsObj = JsonConvert.DeserializeObject<Movielist>(json).movies.ToList();
        }

        public List<Movie> show()
        {
            return bsObj;
        }

        public void delete(string id)
        {
            bsObj.RemoveAll(m => m.id == id);
            save();
        }

        public void getLastID()
        {
            foreach (var i in show())
            {
                stringID = i.id;
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

        public void add()
        {
            getLastID();
            id++;
            string title = HttpContext.Current.Request.Form["title"];
            string year = HttpContext.Current.Request.Form["year"];
            string duration = HttpContext.Current.Request.Form["duration"];
            string IMDB = HttpContext.Current.Request.Form["IMDB"];

            Movie create = new Movie();
            create.id = id.ToString();
            create.title = title;
            create.year = year;
            create.duration = duration;
            create.IMDB = IMDB;
           
            bsObj.Add(create);
            save();
        }

        public void save()
        {
            dynamic collectionWrapper = new
            {
                movies = bsObj
            };
            string x = JsonConvert.SerializeObject(collectionWrapper, Formatting.Indented);
            File.WriteAllText(System.Web.HttpContext.Current.Server.MapPath("../data/movies.json"), x);
        }
    }
}


   
    