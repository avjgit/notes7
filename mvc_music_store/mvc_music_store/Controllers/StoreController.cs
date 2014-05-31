using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc_music_store.Models;

namespace mvc_music_store.Controllers
{
    public class StoreController : Controller
    {
        StoreRecords storeDB = new StoreRecords();
        //
        // GET: /Store/

        public ActionResult Index()
        {
            var genres = storeDB.Genre.ToList();
            return View(genres);
        }

        //post parameters named “genre” will be automatically past
        public ActionResult Browse(string genre)
        {
            //string message = HttpUtility.HtmlEncode("browsing genre " + genre);
            var genreModel = new Genre { Name = genre };
            return View(genreModel);
        }
        //HttpUtility.HtmlEncode utility to sanitize the user input. 
        //This prevents users from injecting Javascript into our View 
        //with a link like /Store/Browse?Genre=<script>window.location=’http://hackersite.com’</script>

        // ASP.NET MVC’s default routing convention is 
        //to treat the segment of a URL after the action method name 
        //as a parameter named “ID”
        public ActionResult Details(int id)
        {
            //string message = HttpUtility.HtmlEncode("details for " + id);
            var album = new Album { Title = "Album " + id };
            return View(album);
        }

    }
}
