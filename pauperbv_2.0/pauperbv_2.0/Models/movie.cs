using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pauperbv_2._0.Models
{
   
    public class Movielist
    {
        public List<Movie> movies { get; set; }

    }
    
    [JsonObject(Title = "movies")]
    public class Movie
    {
       
        public string id { get; set; }
        public string title { get; set; }
        public string year { get; set; }
        public string duration { get; set; }
        public string IMDB { get; set; }
    }

    
}