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
    public class PostController : Controller
    {
        private BlogDBEntities db = new BlogDBEntities();

        //
        // GET: /Post/

        public ActionResult Index()
        {
            IEnumerable<Post> listPosts = PostDAO.GetAllPosts();
            IEnumerable<PostsModel> listModelPosts = PostsModel.GetListPosts(listPosts);
            return View(listModelPosts);
        }

        //
        // GET: /Post/Details/5

        public ActionResult Details(int id = 0)
        {
            ViewPostModel post = new ViewPostModel(PostDAO.GetPost(id));
            return View(post);
        }

        //
        // GET: /Post/Create

        public ActionResult Create()
        {            
            return View();
        }

        //
        // POST: /Post/Create

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(CreatePostModel post)
        {
            if (ModelState.IsValid)
            {
                PostDAO.CreatePost(UserDAO.GetUserId(User.Identity.Name), post.PostTitle, post.PostBody);
                return RedirectToAction("Index");
            }
            
            return View(post);
        }

        //
        // GET: /Post/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.PostAuthor = new SelectList(db.Users, "UserId", "UserName", post.User.UserName);
            return View(post);
        }

        //
        // POST: /Post/Edit/5

        [HttpPost]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PostAuthor = new SelectList(db.Users, "UserId", "UserName", post.User.UserName);
            return View(post);
        }

        //
        // GET: /Post/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        //
        // POST: /Post/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult TagsAutocomplete(string term)
        {
            var lastValue = term.Split(';').Last().Trim();
            var listTags = TagDAO.TagsAutocomplete(lastValue);
            return Json(listTags, JsonRequestBehavior.AllowGet);
        }
    }
}