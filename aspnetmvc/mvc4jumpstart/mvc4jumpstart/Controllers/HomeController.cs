﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc4jumpstart.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Spaghetti()
        {
            ViewBag.Message = "here are your spaghetti:)";
            ViewBag.Spaghetti = 200;
            return View();
        }

    }
}
