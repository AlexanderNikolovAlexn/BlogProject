using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;
using Blog.DAL;
using System.ComponentModel;

namespace MvcApplicationTest.Models
{
    public class UsersModel
    {
        public long UserId { get; set; }

        [DisplayName("User name")]
        public string UserName { get; set; }

        [DisplayName("First name")]
        public string FirstName { get; set; }

        [DisplayName("Last name")]
        public string LastName { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Status")]
        public string Status { get; set; }

        public UsersModel(User user)
        {
            UserId = user.UserId;
            UserName = user.UserName;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            switch (user.UserStatus)
            {
                case 0: Status = "deactivated"; break;
                case 1: Status = "active"; break;
                default: Status = "unknown"; break;
            }
        }

        public static IEnumerable<UsersModel> GetAllUsers(IEnumerable<User> allUsers)
        {
            List<UsersModel> listUsers = new List<UsersModel>();
            foreach (var user in allUsers)
            {
                listUsers.Add(new UsersModel(user));
            }
            return listUsers;
        }
    }
}