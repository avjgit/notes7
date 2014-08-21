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
    public class CommentController : Controller
    {
        private ConferenceContext db = new ConferenceContext();

        public PartialViewResult _GetForSession(int sessionId)
        {
            ViewBag.SessionId = sessionId;
            List<Comment> comments = db.Comments.Where(c => c.SessionId == sessionId).ToList();
            return PartialView("_GetForSession", comments);
        }

        [ChildActionOnly]
        public PartialViewResult _CommentForm(int sessionId)
        {
            Comment comment = new Comment() { SessionId = sessionId };
            return PartialView("_CommentFrom", comment);
        }

        [ValidateAntiForgeryToken]
        public PartialViewResult _Submit(Comment comment)
        {
            db.Comments.Add(comment);
            db.SaveChanges();
            List<Comment> comments = db.Comments.Where(c => c.SessionId == comment.SessionId).ToList();
            ViewBag.SessionId = comment.SessionId;
            return PartialView("_GetForSesion", comments);
        }

    }
}