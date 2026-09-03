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
        public DateTime updatedAt { get; set; }
    }
}
