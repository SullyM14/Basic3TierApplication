using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using EFGetStarted;

namespace EFStartedBusinessLayer
{
    public class CRUD
    {
        public Blog selectedBlog { get; set; }
        public Post selectedPost { get; set; }

        public List<Blog> RetrieveAll()
        {
            using (var db = new BloggingContext() )
            {
                return db.Blogs.ToList();
            }
        }

        public List<Post> RetrieveAllPosts(object selectedItem)
        {
            using (var db = new BloggingContext())
            {
                selectedBlog = (Blog)selectedItem;
                var posts =
                    from post in db.Posts
                    where post.BlogId == selectedBlog.BlogId
                    select post;

                return posts.ToList();
            }
        }

        public void SetPost(object selectedItem)
        {
            selectedPost = (Post)selectedItem;
        }

        public void CreateBlog(string blogName)
        {
            using (var db = new BloggingContext())
            {
                db.Add(new Blog { Url = blogName });
                db.SaveChanges();
            }
        }

        public void CreatePost(string title, string content,object selectedItem)
        {
            selectedBlog = (Blog)selectedItem;
            using (var db = new BloggingContext())
            {
                db.Add(new Post {BlogId = selectedBlog.BlogId, Title = title, Content = content});
                db.SaveChanges();
            }
        }

        public void UpdatePost(string postId, string title, string content)
        {
            using (var db = new BloggingContext())
            {
                var posts =
                    from post in db.Posts
                    where post.PostId == Int32.Parse(postId) // Shouldnt do parse, figure another way out
                    select post;

                selectedPost = posts.FirstOrDefault();
                selectedPost.Title = title;
                selectedPost.Content = content;
                db.SaveChanges();
            }
        }
    }
}
