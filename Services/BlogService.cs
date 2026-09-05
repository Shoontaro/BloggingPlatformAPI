using BloggingPlatformAPI.DB;
using BloggingPlatformAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BloggingPlatformAPI.Services
{
    public class BlogService
    {
        //int nextId = 4;
       // List<BlogPost> Posts { get; }
        AppDBContext db;

        public BlogService(AppDBContext db)
        {
            this.db = db;
        }

        public List<BlogPost> GetAll() => db.Posts.ToList();

        public BlogPost? Get(int id) => db.Posts.FirstOrDefault(v=>v.id == id);

        public void Add(BlogPost post)
        {
            post.createdAt = DateTime.Now;
            post.updatedAt = DateTime.Now;

            db.Posts.Add(post);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var post = Get(id);
            if (post is null)
                return;

            db.Posts.Remove(post);
            db.SaveChanges();
        }

        public void Upload(int id, BlogPost post)
        {
            BlogPost? exPost = db.Posts.ToList().Find(v=>v.id == id);
            if (exPost == null) return;

            exPost.title = post.title;
            exPost.tags = post.tags;
            exPost.content = post.content;
            exPost.category = post.category;
            exPost.updatedAt = DateTime.Now;

            db.SaveChanges();
        }
    }
}
