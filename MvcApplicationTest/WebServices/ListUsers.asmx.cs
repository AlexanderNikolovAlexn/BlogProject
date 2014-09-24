using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MvcApplicationTest.Models;
using Blog.DAL;

namespace MvcApplicationTest.WebServices
{
    /// <summary>
    /// Summary description for ListUsers
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ListUsers : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public IEnumerable<UsersModel> GetAllUsers()
        {
            return UsersModel.GetAllUsers(UserDAO.GetAllUsers());
        }
    }
}
