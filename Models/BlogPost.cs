namespace BloggingPlatformAPI.Models
{
    public class BlogPost
    {
        public int id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string category { get; set; }
        public string[] tags { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime? updatedAt { get; set; }

        public BlogPost() { }

        public BlogPost(string title, string content, string category, string[] tags)
        { 
            this.title = title;
            this.content = content;
            this.category = category;
            this.tags = tags;
            createdAt = DateTime.Now;
            updatedAt = DateTime.Now;
        }
        public BlogPost(int id, string title, string content, string category, string[] tags):this(title, content, category, tags)
        { 
            this.id = id;
        }

        public static List<BlogPost> Seeds() //балванка 
        { 
            return new List<BlogPost>() { 
               new BlogPost(1, "title1", "content1", "category1", ["one", "two"]),
               new BlogPost(2, "title2", "content2", "category2", ["one", "two"]),
               new BlogPost(3, "title3", "content3", "category3", ["one", "two"])
            };
        }
    }
}
