using APIBlog.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIVanTai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialityController : ControllerBase
    {
        KMA_DBSContext db = new KMA_DBSContext();

        // GET: api/<GetData>
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var speciality = db.Specialitys.ToList();
            if (speciality == null)
            {
                return NotFound("Not found any item in speciality");
            }

            return Ok(speciality);
        }

    }
}
