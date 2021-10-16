using APIVanTai.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIVanTai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryDataController : ControllerBase
    {
        BlogContext db = new BlogContext();

        // GET: api/<GetData>
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var categories = db.Categories.Where(x => x.IsRemove != true).ToList();
            if (categories == null)
            {
                return NotFound("Not found any item in Category");
            }

            return Ok(categories);
        }

        // GET api/<GetData>/5
        [HttpGet]
        [Route("GetByName")]
        public IActionResult GetByName(string name)
        {
            var category = db.Categories.FirstOrDefault(x => x.Title == name && x.IsRemove != true);
            if (category == null)
            {
                return NotFound("Not found Category with name: " + name);
            }
            return Ok(category);
        }

    }
}
