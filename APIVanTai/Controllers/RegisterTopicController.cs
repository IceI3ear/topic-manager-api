using APIBlog.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIVanTai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterTopicController : ControllerBase
    {
        KMA_DBSContext db = new KMA_DBSContext();

        // GET: api/<GetData>
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var blog = (from a in db.RegisterTopics
                        join b in db.UserProfiles on a.UserID equals b.UserId into group1
                        from b in group1.DefaultIfEmpty()
                        join c in db.AspNetUsers on a.StudentID equals c.Id into group2
                        from c in group2.DefaultIfEmpty()
                        select new
                        {
                            a.ID,
                            a.TopicName,
                            student = c.FullName,
                            teacher = b.FullName,
                            a.Description,
                            a.Status,
                            SpecialityName = a.Speciality.Name,
                            a.LinkFile
                        }
                            );
            if (blog == null)
            {
                return NotFound("Not found any item in register topic");
            }

            return Ok(blog);
        }

        // GET api/<GetData>/5
        [HttpPost]
        [Route("AddRegisterTopic")]
        public IActionResult AddRegisterTopic(RegisterTopicViewModel registerTopic)
        {
            var check = true;
            try
            {
                var model = new RegisterTopic()
                {
                    FileLink = registerTopic.FileLink,
                    StudentID = registerTopic.StudentID,
                    TopicName = registerTopic.TopicName,
                    Description = registerTopic.Description,
                    SpecialityID = registerTopic.SpecialityID
                };

                db.Set<RegisterTopic>().Add(model);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                check = false;
            }

            if (!check)
            {
                return NotFound("Save not success");
            }

            return Ok();
        }

    }
}
