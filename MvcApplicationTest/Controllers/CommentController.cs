using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.DAL;
using MvcApplicationTest.Models;

namespace MvcApplicationTest.Controllers
{
    public class CommentController : Controller
    {
        private BlogDBEntities db = new BlogDBEntities();

        //
        // GET: /Comment/

        public ActionResult Index()
        {
            var comments = new List<Comment>(); ;// = db.Comments.Include(c => c.aspnet_Users).Include(c => c.Post);
            return View(comments.ToList());
        }

        //
        // GET: /Comment/Details/5

        public ActionResult Details(int id = 0)
        {
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        //
        // GET: /Comment/Create

        public ActionResult Create()
        {
            ViewBag.CommentAuthor = new SelectList(db.Users, "UserId", "UserName");
            ViewBag.PostId = new SelectList(db.Posts, "PostId", "PostTitle");
            return View();
        }

        //
        // POST: /Comment/Create

        [HttpPost]
        public ActionResult Create(Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CommentAuthor = new SelectList(db.Users, "UserId", "UserName", comment.AuthorName);
            ViewBag.PostId = new SelectList(db.Posts, "PostId", "PostTitle", comment.PostId);
            return View(comment);
        }

        //
        // GET: /Comment/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.CommentAuthor = new SelectList(db.Users, "UserId", "UserName", comment.AuthorName);
            ViewBag.PostId = new SelectList(db.Posts, "PostId", "PostTitle", comment.PostId);
            return View(comment);
        }

        //
        // POST: /Comment/Edit/5

        [HttpPost]
        public ActionResult Edit(Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CommentAuthor = new SelectList(db.Users, "UserId", "UserName", comment.AuthorName);
            ViewBag.PostId = new SelectList(db.Posts, "PostId", "PostTitle", comment.PostId);
            return View(comment);
        }

        //
        // GET: /Comment/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        //
        // POST: /Comment/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public PartialViewResult PostComments(int postId)
        {
            IEnumerable<ViewCommentsModel> viewComments = new List<ViewCommentsModel>();
               viewComments = ViewCommentsModel.GetListComments(CommentDAO.GetComments(postId));
            return PartialView("_Comments", viewComments);
        }

        [HttpPost]
        public PartialViewResult AddComment(int PostId, string UserName, string Email, string CommentText)
        {
            int? userId = null;
            if (string.IsNullOrEmpty(User.Identity.Name))
            {
                UserDAO.GetUserId(User.Identity.Name);
            }
            CommentDAO.AddComments(PostId, userId, UserName, Email, CommentText);
            IEnumerable<ViewCommentsModel> viewComments = new List<ViewCommentsModel>();
            viewComments = ViewCommentsModel.GetListComments(CommentDAO.GetComments(PostId));
            return PartialView("_Comments", viewComments);
        }
    }
}