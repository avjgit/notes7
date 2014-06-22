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
            // inline parameters: http://localhost:62559/helloworld/welcome?name=aj&numtimes=3
            return HttpUtility.HtmlEncode("Hello " + name + ", numtimes is " + numtimes);
        }
	}
}