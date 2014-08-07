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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Welcome(string name, int id = 1)
        {
            // inline parameters: http://localhost:62559/helloworld/welcome?name=aj&numtimes=3
            // with default ID parameter: http://localhost:62559/helloworld/welcome?name=aj
            //return HttpUtility.HtmlEncode("Hello " + name + ", id is " + id);
            ViewBag.Message = "Hello " + name;
            ViewBag.NumTimes = id;
            return View();
        }
	}
}