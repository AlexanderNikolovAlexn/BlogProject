using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplicationTest.Models;
using Blog.DAL;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace MvcApplicationTest.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GridView()
        {
            var listUsers = UsersModel.GetAllUsers(UserDAO.GetAllUsers());
            return View(listUsers);
        }

        public JsonResult GetAllUsers()
        {
            var listUsers = UsersModel.GetAllUsers(UserDAO.GetAllUsers());
            return Json(listUsers, JsonRequestBehavior.AllowGet);
        }

    }
}
