using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Blog.DAL;
using MvcApplicationTest.Models;

namespace MvcApplicationTest.Controllers
{
    public class UserAPIController : ApiController
    {
        // GET api/UserAPI
        public IEnumerable<UsersModel> GetAllUsers()
        {
            return UsersModel.GetAllUsers(UserDAO.GetAllUsers());
        }
    }
}
