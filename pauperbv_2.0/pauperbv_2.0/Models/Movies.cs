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


        public Movies()
        {

        }

        public string show()
        {
            string json = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("../data/movies.json"));

            Movie bsObj = JsonConvert.DeserializeObject<Movie>(json);

            return bsObj.title;
        }
    }
}


   
    