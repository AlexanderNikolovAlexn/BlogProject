using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL
{
    public static class UserDAO
    {
        static BlogDBEntities db = new BlogDBEntities();

        public static int GetUserId(string userName)
        {
            return db.Users.Where(u => u.UserName == userName).Select(s => s.UserId).FirstOrDefault();
        }

        public static string GetUsername(int userId)
        {
            return db.Users.Where(u => u.UserId == userId).Select(s => s.UserName).FirstOrDefault();
        }

        public static void RegisterUser(string password, string firstName, string lastName, string email)
        {
            User user = new User()
            {
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                IsAdmin = 0,
                UserStatus = 1,
                Email = email,
                CreateDate = DateTime.Now
            };
            db.Users.Add(user);
            db.SaveChanges();
        }

        public static IEnumerable<User> GetAllUsers()
        {
            return db.Users.ToList();
        }
    }
}