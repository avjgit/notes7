using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using conference.Models;
using Microsoft.Ajax.Utilities;

namespace conference.Controllers
{
    public class SessionController : Controller
    {
        ConferenceContext db = new ConferenceContext();

        //
        // GET: /Session/

        public ActionResult Index()
        {
            var context = new ConferenceContext();
            List<Session> sessions = context.Sessions.ToList();
            //return View("Index", sessions);
            // empty view name defaults to controller method name
            return View(sessions); 
        }

        // FILTERS: authorization, before/ after action, before/ action result
        // can be put on class or on method
        // GET
        // [Authorize(Roles = "Administrators")]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        // POST
        public ActionResult Create(Session session)
        {
            if (!ModelState.IsValid)
                return View(session);

            try
            {
                var context = new ConferenceContext();
                context.Sessions.Add(session);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return View(session);
            }

            TempData["Message"] = "Created " + session.Title;

            // redirecting to list of sesions
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id = 0)
        {
            Session session = db.Sessions.Find(id);
            if (session == null)
            {
                return HttpNotFound();
            }
            return View(session);
        }


    }
}
