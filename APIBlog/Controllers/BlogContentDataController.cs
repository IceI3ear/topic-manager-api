using APIVanTai.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIVanTai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogContentDataController : ControllerBase
    {
        BlogContext db = new BlogContext();

        // GET: api/<GetData>
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var blog = db.BlogContents.Where(x=>x.IsRemove != true).ToList();
            if (blog == null)
            {
                return NotFound("Not found any item in Blog Content");
            }

            return Ok(blog);
        }

        // GET api/<GetData>/5
        [HttpGet]
        [Route("GetByName")]
        public IActionResult GetByName(string name)
        {
            var test = db.BlogContents.FirstOrDefault(x => x.Title == name && x.IsRemove != true);
            if(test == null)
            {
                return NotFound("Not found Blog Content with name: " + name);
            }
            return Ok(test);
        }

        [HttpGet]
        [Route("GetCommentByBlogName")]
        public IActionResult GetCommentByBlogName(string name)
        {
            var comment = db.Comments.Where(y=>y.BlogId == db.BlogContents.Where(x => x.Title == name && x.IsRemove != true).Select(x=>x.Id).FirstOrDefault()
            && y.IsRemove != true).ToList();
            if (comment == null)
            {
                return NotFound("Not found any comment with blog name: " + name);
            }
            return Ok(comment);
        }

        [HttpPost]
        [Route("PostCommentByBlog")]
        public IActionResult PostCommentByBlog(string comment, string userID, int blogID)
        {
            try
            {
                var objComment = new Comment();
                objComment.Body = comment;
                objComment.UserId = userID;
                objComment.CreatedDate = DateTime.Now;
                objComment.BlogId = blogID;
                db.Comments.Add(objComment);
                db.SaveChanges();
            }
            catch(Exception e)
            {
                throw new ArgumentException($"We can't save comment for {comment} in BlogID: {blogID} with user {userID}. Error: {e}.");
            }
           
            return Ok();
        }

        [HttpPost]
        [Route("PostVoteByBlog")]
        public IActionResult PostVoteByBlog(int vote, string userID, int blogID)
        {
            try
            {
                var objVote = new Vote();
                objVote.Type = vote;
                objVote.UserId = userID;
                objVote.CreatedDate = DateTime.Now;
                objVote.BlogId = blogID;
                db.Votes.Add(objVote);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new ArgumentException($"We can't save vote for {vote} in BlogID: {blogID} with user {userID}. Error: {e}");
            }

            return Ok();
        }
    }
}
