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
    public class TopicDataController : ControllerBase
    {
        KMA_DBSContext db = new KMA_DBSContext();

        // GET: api/<GetData>
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var blog = (from a in db.Topics
                        join b in db.UserProfiles on a.UserID equals b.UserId into group1
                        from b in group1.DefaultIfEmpty()
                        join c in db.AspNetUsers on a.StudentID equals c.Id into group2
                        from c in group2.DefaultIfEmpty()
                        select new
                        {
                            a.ID,
                            a.TopicName,
                            a.StartDate,
                            a.StartRegister,
                            a.EndDate,
                            a.EndRegister,
                            a.Description,
                            a.LinkFile,
                            Student = c.FullName,
                            Teacher = b.FullName,
                            SpecialityName = a.Speciality != null ? a.Speciality.Name : "",
                            a.SpecialityID,
                            a.StudentID,
                            b.UserId
                        }
                             );

            if (blog == null)
            {
                return NotFound("Not found any item in Topic");
            }

            return Ok(blog);
        }

        // GET api/<GetData>/5
        [HttpGet]
        [Route("GetByID")]
        public IActionResult GetByID(int id)
        {
            var test = db.Topics.Include(x=>x.Student).Include(x => x.Teacher).Include(x => x.Speciality).FirstOrDefault(x => x.ID == id);
            if (test == null)
            {
                return NotFound("Not found Topic with id: " + id);
            }
            return Ok(test);
        }

        [HttpGet]
        [Route("GetByName")]
        public IActionResult GetByName(string name)
        {
            var test = db.Topics.Include(x => x.Student).Include(x => x.Teacher).Include(x => x.Speciality).FirstOrDefault(x => x.TopicName == name);
            if (test == null)
            {
                return NotFound("Not found Topic with name: " + name);
            }
            return Ok(test);
        }

        [HttpGet]
        [Route("GetByStudentID")]
        public IActionResult GetByStudentID(string id)
        {
            var comment = (from a in db.Topics.Include(x => x.Student).Include(x => x.Teacher).Include(x => x.Speciality).Where(y => y.StudentID == id)
                           join b in db.UserProfiles on a.UserID equals b.UserId into group1
                           from b in group1.DefaultIfEmpty()
                           join c in db.AspNetUsers on a.StudentID equals c.Id into group2
                           from c in group2.DefaultIfEmpty()
                           select new
                           {
                               a.ID,
                               a.TopicName,
                               a.StartDate,
                               a.StartRegister,
                               a.EndDate,
                               a.EndRegister,
                               a.Description,
                               a.LinkFile,
                               Student = c.FullName,
                               Teacher = b.FullName,
                               SpecialityName = a.Speciality != null ? a.Speciality.Name : "",
                               a.SpecialityID,
                               a.StudentID,
                               b.UserId
                           }
                             );
            if (comment == null)
            {
                return NotFound("Not found any comment with student id: " + id);
            }
            return Ok(comment);
        }

        [HttpPost]
        [Route("RegisterTopic")]
        public IActionResult RegisterTopic(int  topicID, string userID)
        {
            try
            {
                var topic = db.Topics.Where(x => x.ID == topicID).FirstOrDefault();
                topic.StudentID = userID;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new ArgumentException($"We can't register topic for userID: {userID} in Topic ID: {topicID}. Error: {e}.");
            }

            return Ok();
        }

    }
}
