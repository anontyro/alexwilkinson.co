using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using websites;
using Microsoft.AspNetCore.Authorization;

namespace websites.Controllers
{
    [Produces("application/json")]
    [Route("api/BlogPosts")]
    public class BlogPostsController : Controller
    {
        private readonly AlexwilkinsonContext _context;

        public BlogPostsController(AlexwilkinsonContext context)
        {
            _context = context;
        }

        // GET: api/BlogPosts
        [HttpGet]
        public IEnumerable<BlogPost> GetBlogPost()
        {
            return _context.BlogPost;
        }

        // GET: api/BlogPosts/range/
        [HttpGet("range/{page?}/{amount?}")]
        public IEnumerable<BlogPost> GetBlogPostInRange([FromRoute]int page = 0, int amount = 25)
        {

            var postList = _context.BlogPost
                .Where(m => m.GetDraft() == 0)
                .OrderByDescending(m => m.GetPublish())
                .Skip(page * amount)
                .Take(amount);

            return postList;
        }

        // GET: api/BlogPosts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogPost([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var blogPost = await _context.BlogPost.SingleOrDefaultAsync(m => m.Id == id);

            if (blogPost == null)
            {
                return NotFound();
            }

            return Ok(blogPost);
        }

        // GET: api/BlogPosts/count/
        [Authorize]
        [HttpGet("count")]
        public  IActionResult GetBlogPostTotal()
        {

            var blogPost =  _context.BlogPost.Count();

            return Ok(blogPost);
        }

        // GET: api/BlogPosts/latest/
        [HttpGet("latest")]
        public IActionResult GetBlogPostLatest()
        {

            var blogPost = _context.BlogPost
                .Where(m => m.GetDraft() == 0)
                .OrderByDescending(m => m.GetPublish())
                .Take(1)
                ;

            return Ok(blogPost);
        }

        // PUT: api/BlogPosts/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlogPost([FromRoute] int id, [FromBody] BlogPost blogPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != blogPost.Id)
            {
                return BadRequest();
            }

            _context.Entry(blogPost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogPostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BlogPosts
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PostBlogPost([FromBody] BlogPost blogPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.BlogPost.Add(blogPost);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBlogPost", new { id = blogPost.Id }, blogPost);
        }

        // DELETE: api/BlogPosts/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogPost([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var blogPost = await _context.BlogPost.SingleOrDefaultAsync(m => m.Id == id);
            if (blogPost == null)
            {
                return NotFound();
            }

            _context.BlogPost.Remove(blogPost);
            await _context.SaveChangesAsync();

            return Ok(blogPost);
        }

        private bool BlogPostExists(int id)
        {
            return _context.BlogPost.Any(e => e.Id == id);
        }
    }
}