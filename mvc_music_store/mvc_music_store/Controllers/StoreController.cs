using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_music_store.Controllers
{
    public class StoreController : Controller
    {
        //
        // GET: /Store/

        public string Index()
        {
            return "show'em all";
        }

        //post parameters named “genre” will be automatically past
        public string Browse(string genre)
        {
            string message = HttpUtility.HtmlEncode("browsing genre " + genre);
            return message;
        }
        //HttpUtility.HtmlEncode utility to sanitize the user input. 
        //This prevents users from injecting Javascript into our View 
        //with a link like /Store/Browse?Genre=<script>window.location=’http://hackersite.com’</script>

        // ASP.NET MVC’s default routing convention is 
        //to treat the segment of a URL after the action method name 
        //as a parameter named “ID”
        public string Details(int id)
        {
            string message = HttpUtility.HtmlEncode("details for " + id);
            return message;
        }

    }
}
