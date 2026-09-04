using Microsoft.AspNetCore.Mvc;
using BloggingPlatformAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
            return BlogPost.Seeds();
        }

        // GET posts/5
        [HttpGet("{id}")]
        public ActionResult<BlogPost> Get(int id)
        {
            BlogPost post = BlogPost.Seeds().Find(v => v.id == id);

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
