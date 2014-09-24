using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL
{
    public static class PostDAO
    {
        static BlogDBEntities db = new BlogDBEntities();

        public static IEnumerable<Post> GetAllPosts()
        {
            return db.Posts.ToList();
        }

        public static Post GetPost(int postId)
        {
            return db.Posts.Where(p => p.PostId == postId).FirstOrDefault();
        }

        public static void CreatePost(int userId, string title, string body)
        {
            Post newPost = new Post()
            {
                PostTitle = title,
                PostBody = body,
                AuthorId = userId,
                PostDate = DateTime.Now,
                PostStatus = 0,
            };

            db.Posts.Add(newPost);
            db.SaveChanges();
        }
    }
}
