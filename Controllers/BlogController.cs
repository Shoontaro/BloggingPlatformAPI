using Microsoft.AspNetCore.Mvc;
using BloggingPlatformAPI.Models;
using BloggingPlatformAPI.Services;

namespace BloggingPlatformAPI.Controllers
{
    [Route("posts")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        public BlogController() { }
     
        // GET: posts?term
        [HttpGet]
        public ActionResult<List<BlogPost>> Get(string? term) 
        {
            List<BlogPost> data = BlogService.GetAll();

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
            BlogPost? post = BlogService.Get(id);

            if ( post == null) { return NotFound(); }

            return post;
        }

        // POST posts
        [HttpPost]
        public IActionResult Create([FromBody] BlogPost post)
        {
            BlogService.Add(post);
            return CreatedAtAction(nameof(Get), new { post.id }, post);
        }

        // PUT posts/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, BlogPost post)
        {
            if (id != post.id)
                return BadRequest();

            var existingPost = BlogService.Get(id);
            if (existingPost is null)
                return NotFound();

            BlogService.Upload(post);

            return NoContent();
        }

        // DELETE posts/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var post = BlogService.Get(id);

            if (post is null)
                return NotFound();

            BlogService.Delete(id);

            return NoContent();
        }
    }
}
