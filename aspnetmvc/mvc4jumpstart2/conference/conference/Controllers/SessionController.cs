using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using conference.Models;

namespace conference.Controllers
{
    public class SessionController : Controller
    {
        private ConferenceContext db = new ConferenceContext();

        //
        // GET: /Session/

        public ActionResult Index()
        {
            var sessions = db.Sessions.Include(s => s.Speaker);
            return View(sessions.ToList());
        }

        //
        // GET: /Session/Details/5

        public ActionResult Details(int id = 0)
        {
            Session session = db.Sessions.Find(id);
            if (session == null)
            {
                return HttpNotFound();
            }
            return View(session);
        }

        //
        // GET: /Session/Create

        public ActionResult Create()
        {
            ViewBag.SpeakerId = new SelectList(db.Speakers, "SpeakerId", "Name");
            return View();
        }

        //
        // POST: /Session/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Session session)
        {
            if (ModelState.IsValid)
            {
                db.Sessions.Add(session);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SpeakerId = new SelectList(db.Speakers, "SpeakerId", "Name", session.SpeakerId);
            return View(session);
        }

        //
        // GET: /Session/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Session session = db.Sessions.Find(id);
            if (session == null)
            {
                return HttpNotFound();
            }
            ViewBag.SpeakerId = new SelectList(db.Speakers, "SpeakerId", "Name", session.SpeakerId);
            return View(session);
        }

        //
        // POST: /Session/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Session session)
        {
            if (ModelState.IsValid)
            {
                db.Entry(session).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SpeakerId = new SelectList(db.Speakers, "SpeakerId", "Name", session.SpeakerId);
            return View(session);
        }

        //
        // GET: /Session/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Session session = db.Sessions.Find(id);
            if (session == null)
            {
                return HttpNotFound();
            }
            return View(session);
        }

        //
        // POST: /Session/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Session session = db.Sessions.Find(id);
            db.Sessions.Remove(session);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}