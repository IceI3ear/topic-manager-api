using APIVanTai.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIVanTai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;

        public UserProfileController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
        }
        ApplicationDbContext db;


        public UserProfileController(ApplicationDbContext applicationDbContext)
        {
            db = applicationDbContext;
        }
        // GET: api/<UserProfile>

        //[HttpGet]
        //public async Task<ApplicationUser> GetUserProfile()
        //{
        //    var model = userManager.GetUserAsync();
        //    return model;
        //}

        // GET api/<UserProfile>/5
        //[HttpGet("id")]
        //public async Task<ActionResult<ApplicationUser>> GetUserProfileByUserName(string id)
        //{
        //    var user = await userManager.FindByNameAsync(id);
        //    return user;
        //}


        //// PUT api/<UserProfile>/5
        //[HttpPut()]
        //public async Task<ActionResult<ApplicationUser>> UpdateUser([FromBody] ApplicationUser model)
        //{
        //    try
        //    {
        //        var user = await userManager.FindByNameAsync(model.Id);
        //        if (user == null) return BadRequest("Không tìm thấy người dùng");
        //        else
        //        {
        //            user.FirstName = model.FirstName;
        //            user.LastName = model.LastName;
        //            user.Address = model.Address;
        //            user.DateBorn = model.DateBorn;
        //            var result = await userManager.UpdateAsync(user);
        //            if (!result.Succeeded)
        //            {
        //                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Massage = "Cập nhật không thành công!" });
        //            }
        //            return Ok(new Response { Status = "Success", Massage = "Cập nhật thành công!" });
        //        }

                

        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //            "Cập nhật người dùng lỗi!");
        //    }
        //}

        //// DELETE api/<UserProfile>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
