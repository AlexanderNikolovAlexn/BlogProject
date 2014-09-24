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

namespace MvcApplicationTest.Models
{
    public class CommentsModel
    {
        public int CommentId { get; set; }
        public string CommentAuthor { get; set; }
        public DateTime CommentDate { get; set; }
        public string CommentText { get; set; }

        public CommentsModel(int commentId, string commentAuthor, DateTime commentDate, string commentText)
        {
            CommentId = commentId;
            CommentAuthor = commentAuthor;
            CommentDate = commentDate;
            CommentText = commentText;
        }

        public static List<CommentsModel> getFakeData()
        {
            List<CommentsModel> listComments = new List<CommentsModel>();
            CommentsModel comment1 = new CommentsModel(1, "Pesho", DateTime.Now, "What an awesome blog.");
            CommentsModel comment2 = new CommentsModel(2, "Gosho", DateTime.Now.AddHours(5), "Very nice blog.");
            CommentsModel comment3 = new CommentsModel(3, "Pokata", DateTime.Now.AddHours(6), "I like your article and your blog at all!!!");
            CommentsModel comment4 = new CommentsModel(4, "Vankata", DateTime.Now.AddHours(12), "I hate your articles.");
            CommentsModel comment5 = new CommentsModel(5, "MVC Pro", DateTime.Now.AddHours(24), "Some bla bla bla comments");
            listComments.Add(comment1);
            listComments.Add(comment2);
            listComments.Add(comment3);
            listComments.Add(comment4);
            listComments.Add(comment5);

            return listComments;
        }
    }

    public class ViewCommentsModel
    {
        public int CommentId { get; set; }
        public int CommentAuthorId { get; set; }
        public string CommentAuthorName { get; set; }
        public DateTime CommentDate { get; set; }
        public string CommentText { get; set; }

        public ViewCommentsModel(int commentId, string commentAuthor, DateTime commentDate, string commentText)
        {
            CommentId = commentId;
            CommentAuthorName = commentAuthor;
            CommentDate = commentDate;
            CommentText = commentText;
        }

        public ViewCommentsModel(Comment comment)
        {
            CommentId = comment.CommentId;
            if (string.IsNullOrEmpty(comment.AuthorName))
            {
                CommentAuthorId = (int)comment.AuthorId;
                CommentAuthorName = UserDAO.GetUsername(CommentAuthorId);
            }
            else
            {                
                if (comment.AuthorName != "")
                {
                    CommentAuthorName = comment.AuthorName;
                }
                else
                {
                    CommentAuthorName = String.Empty;
                }
            }
            CommentDate = comment.CommentDate;
            CommentText = comment.CommentText;
        }

        public static IEnumerable<ViewCommentsModel> GetListComments(IEnumerable<Comment> comments)
        {
            List<ViewCommentsModel> listComments = new List<ViewCommentsModel>();
            foreach (var comment in comments)
            {
                listComments.Add(new ViewCommentsModel(comment));
            }
            return listComments;
        }

        public class AddCommentsModel
        {
            [Required]
            [Display(Name = "User name")]
            public string UserName { get; set; }

            [Display(Name = "Email")]
            public string Email { get; set; }
            
            [Required]
            [Display(Name = "Text")]
            public string CommentText { get; set; }
           
        }
    }
}