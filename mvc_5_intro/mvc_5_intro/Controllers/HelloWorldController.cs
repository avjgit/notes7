using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_5_intro.Controllers
{
    public class HelloWorldController : Controller
    {
        //
        // GET: /HelloWorld/
        public string Index()
        {
            return "this is default action";
        }

        public string Welcome(string name, int numtimes = 1)
        {
            return "this is welcome";
        }
	}
}