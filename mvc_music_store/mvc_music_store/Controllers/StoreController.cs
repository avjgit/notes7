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

        public string Browse()
        {
            return "browsing";
        }

        public string Details()
        {
            return "details";
        }

    }
}
