using BloggingPlatformAPI.DB;
using BloggingPlatformAPI.Models;
using BloggingPlatformAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BloggingPlatformAPI.Controllers
{
    [Route("posts")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        
        BlogService blog;
        //public BlogController() { }

        public BlogController(AppDBContext context)
        { 
            blog = new BlogService(context);
        }

        // GET: posts?term
        [HttpGet]
        public ActionResult<List<BlogPost>> Get(string? term) 
        {
            List<BlogPost> data = blog.GetAll();

            if (!string.IsNullOrEmpty(term)) data = data.Where(v=>
            v.title.Trim().ToLower().Contains(term.Trim().ToLower()) ||
            v.category.Trim().ToLower().Contains(term.Trim().ToLower()) ||
            v.content.Trim().ToLower().Contains(term.Trim().ToLower())).ToList();

            return data;
        }

        // GET posts/5
        [HttpGet("{id}")]
        public ActionResult<BlogPost> Get(int id)
        {
            BlogPost? post = blog.Get(id);

            if ( post == null) { return NotFound(); }

            return post;
        }

        // POST posts
        [HttpPost]
        public IActionResult Create([FromBody] BlogPost post)
        {
            blog.Add(post);
           
            return CreatedAtAction(nameof(Get), new { post.id }, post);
        }

        // PUT posts/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, BlogPost post)
        {
            if (id != post.id)
                return BadRequest();

            var existingPost = blog.Get(id);
            if (existingPost is null)
                return NotFound();

            blog.Upload(id, post);

            return NoContent();
        }

        // DELETE posts/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var post = blog.Get(id);

            if (post is null)
                return NotFound();

            blog.Delete(id);

            return NoContent();
        }
    }
}
