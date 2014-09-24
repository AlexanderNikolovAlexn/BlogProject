using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL
{
    public static class CommentDAO
    {
        static BlogDBEntities db = new BlogDBEntities();

        public static IEnumerable<Comment> GetComments(int postId)
        {
            return db.Comments.Where(c => c.PostId == postId).OrderByDescending(c => c.CommentDate).ToList();
        }

        public static void AddComments(int postId, int? userId, string userName, string email, string commentText)
        {
            Comment newComment = new Comment()
            {
                PostId = postId,
                AuthorId = userId,
                CommentText = commentText,
                CommentDate = DateTime.Now,
                CommentStatus = 1,
                AuthorName = userName
            };
            db.Comments.Add(newComment);
            db.SaveChanges();
        }

        public static int GetCommentsCount(int postId)
        {
            return db.Comments.Where(c => c.PostId == postId).Count();
        }
    }
}
