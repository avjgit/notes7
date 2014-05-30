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

        public string Browse(string genre)
        {
            string message = HttpUtility.HtmlEncode("browsing genre " + genre);
            return message;
        }

        public string Details(int id)
        {
            string message = HttpUtility.HtmlEncode("details for " + id);
            return message;
        }

    }
}
