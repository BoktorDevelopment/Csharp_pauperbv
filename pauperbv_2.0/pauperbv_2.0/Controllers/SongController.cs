using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pauperbv_2._0.Models;

namespace pauperbv_2._0.Controllers
{
    public class SongController : Controller
    {
        // GET: Song
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult show() {
            song song = new song();

            ViewBag.data = song.ds.Tables[0].Rows;

            return View();
        }

        public ActionResult add()
        {
            return View();
        }

        public ActionResult edit()
        {
           
            return View();
        }
        public ActionResult delete()
        {
            return View();
        }



    }
}