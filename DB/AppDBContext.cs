using BloggingPlatformAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BloggingPlatformAPI.DB
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<BlogPost> Posts { get; set; }

    }
}
