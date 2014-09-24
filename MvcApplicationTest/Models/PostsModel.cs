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
    public class PostsModel
    {
        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public long AuthorId { get; set; }
        public string Author { get; set; }
        public DateTime PostDate { get; set; }
        public string PostBody { get; set; }
        public int CommentsCount { get; set; }

        public PostsModel(int postId, string postTitle, string author, DateTime postDate, string postBody, int commentsCount)
        {
            PostId = postId;
            PostTitle = postTitle;
            Author = author;
            PostDate = postDate;
            PostBody = postBody;
            CommentsCount = commentsCount;
        }

        public PostsModel(Post post)
        {
            PostId = post.PostId;
            PostTitle = post.PostTitle;
            AuthorId = post.AuthorId;
            Author = UserDAO.GetUsername(post.AuthorId);
            PostDate = post.PostDate;
            if (post.PostBody.Length > 296)
            {
                PostBody = post.PostBody.Substring(1, 296);
            }
            else
            {
                PostBody = post.PostBody;
            }
            CommentsCount = CommentDAO.GetCommentsCount(post.PostId);
        }

        public static IEnumerable<PostsModel> GetListPosts(IEnumerable<Post> allPosts)
        {
            List<PostsModel> listPosts = new List<PostsModel>();
            foreach (var post in allPosts)
            {
                listPosts.Add(new PostsModel(post));
            }
            return listPosts;
	{
		 
	}
        }

        public static List<PostsModel> getFakeData()
        {
            List<PostsModel> listPosts = new List<PostsModel>();
            PostsModel post1 = new PostsModel(1, "My first post about MVC 4", "Alexander Nikolov", DateTime.Now,
                "Mvc4 is a new technology introduced in Visual Studio 2012 and it is very similar to previous versions of the MVC concepts. Curently I am researching it and I will write to you short description of what I found out as a difference. Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post. Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.",
                10);
            PostsModel post2 = new PostsModel(2, "What is new in ASP.NET 4.5 framework", "Miriana Dimitrova", DateTime.Now.AddDays(-5),
                "ASP.NET 4.5 framework was released in the beggining of 2012. Currently is a new technology and no one can say what are the new features. I will shortly explain to all my readers what projects I have done and what I liked/disliked about new framework. Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post. Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post. Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post. Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post. Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.",
                11);
            PostsModel post3 = new PostsModel(3, "My first post about MVC 4", "Alexander Nikolov", DateTime.Now,
                "Mvc4 is a new technology introduced in Visual Studio 2012 and it is very similar to previous versions of the MVC concepts. Curently I am researching it and I will write to you short description of what I found out as a difference. Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post. Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.",
                10);
            PostsModel post4 = new PostsModel(4, "What is new in ASP.NET 4.5 framework", "Miriana Dimitrova", DateTime.Now.AddDays(-5),
                "ASP.NET 4.5 framework was released in the beggining of 2012. Currently is a new technology and no one can say what are the new features. I will shortly explain to all my readers what projects I have done and what I liked/disliked about new framework. Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post. Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.",
                5);
            PostsModel post5 = new PostsModel(5, "My first post about MVC 4", "Alexander Nikolov", DateTime.Now,
                "Mvc4 is a new technology introduced in Visual Studio 2012 and it is very similar to previous versions of the MVC concepts. Curently I am researching it and I will write to you short description of what I found out as a difference. Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.",
                8);
            PostsModel post6 = new PostsModel(6, "What is new in ASP.NET 4.5 framework", "Miriana Dimitrova", DateTime.Now.AddDays(-5),
                "ASP.NET 4.5 framework was released in the beggining of 2012. Currently is a new technology and no one can say what are the new features. I will shortly explain to all my readers what projects I have done and what I liked/disliked about new framework. Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.",
                6);
            PostsModel post7 = new PostsModel(7, "My first post about MVC 4", "Alexander Nikolov", DateTime.Now,
                "Mvc4 is a new technology introduced in Visual Studio 2012 and it is very similar to previous versions of the MVC concepts. Curently I am researching it and I will write to you short description of what I found out as a difference. Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.",
                18);
            PostsModel post8 = new PostsModel(8, "What is new in ASP.NET 4.5 framework", "Miriana Dimitrova", DateTime.Now.AddDays(-5),
                "ASP.NET 4.5 framework was released in the beggining of 2012. Currently is a new technology and no one can say what are the new features. I will shortly explain to all my readers what projects I have done and what I liked/disliked about new framework. Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.",
                9);
            PostsModel post9 = new PostsModel(9, "My first post about MVC 4", "Alexander Nikolov", DateTime.Now,
                "Mvc4 is a new technology introduced in Visual Studio 2012 and it is very similar to previous versions of the MVC concepts. Curently I am researching it and I will write to you short description of what I found out as a difference. Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post. Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.",
                55);
            PostsModel post10 = new PostsModel(10, "What is new in ASP.NET 4.5 framework", "Miriana Dimitrova", DateTime.Now.AddDays(-5),
                "ASP.NET 4.5 framework was released in the beggining of 2012. Currently is a new technology and no one can say what are the new features. I will shortly explain to all my readers what projects I have done and what I liked/disliked about new framework. Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post. Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.Also there is some bla bla text until the end of the post.",
                12);
            listPosts.Add(post1);
            listPosts.Add(post2);
            listPosts.Add(post3);
            listPosts.Add(post4);
            listPosts.Add(post5);
            listPosts.Add(post6);
            listPosts.Add(post7);
            listPosts.Add(post8);
            listPosts.Add(post9);
            listPosts.Add(post10);

            return listPosts;
        }
    }

    public class CreatePostModel
    {
        [Required]
        [Display(Name = "Post title")]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        public string PostTitle { get; set; }

        [Required]        
        [StringLength(999999, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]        
        [Display(Name = "Post body")]
        public string PostBody { get; set; }

        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [Display(Name = "Tags")]
        public string PostTags { get; set; }
    }

    public class ViewPostModel
    {
        public int PostId { get; set; }

        [Display(Name = "Post title")]        
        public string PostTitle { get; set; }
               
        [Display(Name = "Post body")]
        public string PostBody { get; set; }

        [Display(Name = "Post date")]
        public DateTime PostDate { get; set; }

        public long AuthorId { get; set; }

        [Display(Name = "Author")]
        public string Author { get; set; }

        [Display(Name = "Comments")]
        public IEnumerable<ViewCommentsModel> Comments { get; set; }

        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Text")]
        public string CommentText { get; set; }

        public ViewPostModel(Post post)
        {
            PostId = post.PostId;
            PostTitle = post.PostTitle;
            PostBody = post.PostBody;
            PostDate = post.PostDate;
            AuthorId = post.AuthorId;
            Author = UserDAO.GetUsername(post.AuthorId);
            Comments = ViewCommentsModel.GetListComments(CommentDAO.GetComments(post.PostId));
        }
    }
}