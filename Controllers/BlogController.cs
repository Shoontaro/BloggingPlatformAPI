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
     
        // GET: posts/
        [HttpGet]
        public ActionResult<List<BlogPost>> Get() 
        {
            return BlogService.GetAll();
        }

        // GET posts/5
        [HttpGet("{id}")]
        public ActionResult<BlogPost> Get(int id)
        {
            BlogPost? post = BlogService.Get(id);

            if ( post == null) { return NotFound(); }

            return post;
        }

        // POST api/<BlogController>
        [HttpPost]
        public IActionResult Create([FromBody] BlogPost post)
        {
            //PizzaService.Add(pizza);
            return CreatedAtAction(nameof(Get), new { post.id }, post);
        }

        // PUT api/<BlogController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BlogController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
