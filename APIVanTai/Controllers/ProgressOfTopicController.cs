using APIBlog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIVanTai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgressOfTopicController : ControllerBase
    {
        KMA_DBSContext db = new KMA_DBSContext();

        // GET: api/<GetData>

        // GET api/<GetData>/5
        [HttpGet]
        [Route("GetByID")]
        public IActionResult GetByID(int id)
        {
            var test = (from a in db.ProgressOfTopics.Where(x => x.ID == id)
                        join b in db.Topics on a.TopicID equals b.ID into group1
                        from b in group1.DefaultIfEmpty()
                        select new
                        {
                            a.ID,
                            b.TopicName,
                            b.Teacher.FullName,
                            b.Student.UserName,
                            a.StartDate,
                            a.EndDate,
                            //a.Atitule,
                            //a.Effort,
                            a.Complete,
                            a.Point,
                            a.Description,
                            a.Status
                        });

            if (test == null)
            {
                return NotFound("Not found progress with id: " + id);
            }
            return Ok(test);
        }

        [HttpGet]
        [Route("GetForStudentID")]
        public IActionResult GetForStudentID(string id)
        {
            var test = (from a in db.ProgressOfTopics.Where(x => x.Topic.StudentID == id)
                        join b in db.Topics on a.TopicID equals b.ID into group1
                        from b in group1.DefaultIfEmpty()
                        select new
                        {
                            a.ID,
                            b.TopicName,
                            b.Teacher.FullName,
                            b.Student.UserName,
                            a.StartDate,
                            a.EndDate,
                            //a.Atitule,
                            //a.Effort,
                            a.Complete,
                            a.Point,
                            a.Description,
                            a.Status
                        });

            if (test == null)
            {
                return NotFound("Not found progress lisr: " + test);
            }
            return Ok(test);
        }

    }
}
