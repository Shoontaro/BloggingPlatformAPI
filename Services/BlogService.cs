using BloggingPlatformAPI.Models;

namespace BloggingPlatformAPI.Services
{
    public class BlogService
    {
        static int nextId = 4;
        static List<BlogPost> Posts { get; }

        static BlogService()
        {
            Posts = new List<BlogPost>() {
               new BlogPost(1, "title1", "content1", "category1", ["one", "two"]),
               new BlogPost(2, "title2", "content2", "category2", ["one", "two"]),
               new BlogPost(3, "title3", "content3", "category3", ["one", "two"])};
        }

        public static List<BlogPost> GetAll() => Posts;

        public static BlogPost? Get(int id) => Posts.FirstOrDefault(v=>v.id == id);

        public static void Add(BlogPost post)
        {
            post.id = nextId++;
            post.createdAt = DateTime.Now;
            post.updatedAt = DateTime.Now;

            Posts.Add(post);   
        }

        public static void Delete(int id)
        {
            var post = Get(id);
            if (post is null)
                return;

            Posts.Remove(post);
        }

        public static void Upload(BlogPost post)
        {
            var index = Posts.FindIndex(p => p.id == post.id);
            if (index == -1)
                return;

            post.createdAt = Posts[index].createdAt;
            post.updatedAt = DateTime.Now;

            Posts[index] = post;
        }
    }
}
