using APIBlog.Models;
using APIVanTai.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace APIVanTai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        KMA_DBSContext db = new KMA_DBSContext();

        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;
        public AuthenticationController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExits = await userManager.FindByNameAsync(model.UserName);
            if (userExits != null) return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Massage = "Tài khoản đã tồn tại!" });
            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName,
            };
            IdentityResult result = await this.userManager.CreateAsync(user, model.Password);

            //UserProfile userProfile = new UserProfile();
            //userProfile.UserName = model.UserName;
            //db.UserProfiles.Add(userProfile);
            //db.SaveChanges();

            
            //WebpagesMembership userInWeb = new WebpagesMembership();
            //userInWeb.Password = db.AspNetUsers.Where(x=>x.UserName == model.UserName).Select(x=>x.PasswordHash).FirstOrDefault();
            //userInWeb.UserId = userProfile.UserId;
            //userInWeb.PasswordFailuresSinceLastSuccess = 0;
            //userInWeb.CreateDate = DateTime.Now;
            //userInWeb.PasswordSalt = "";

            //db.WebpagesMemberships.Add(userInWeb);
            //db.SaveChanges();

            //WebpagesUsersInRole usersInRole = new WebpagesUsersInRole();
            //usersInRole.UserId = userProfile.UserId;
            //usersInRole.RoleId = 9;
            //db.WebpagesUsersInRoles.Add(usersInRole);

            //db.SaveChanges();


            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Massage = "Đăng ký không thành công!" });
            }

            

            return Ok(new Response { Status = "Success", Massage = "Đăng ký thành công!" });
        }



        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] Login model)
        {
            var user = await userManager.FindByNameAsync(model.UserName);

            if(user!=null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                //var userRoles = await userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                };

                //foreach(var userrole in userRoles)
                //{
                //    authClaims.Add(new Claim(ClaimTypes.Role, userrole));
                //}

                var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:Audience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials:new SigningCredentials(authSigninKey,SecurityAlgorithms.HmacSha256)
                    );

                var userInfo = db.AspNetUsers.Where(x => x.Id == user.Id).Include("Class").FirstOrDefault();
                var classes = db.Classes;
                return Ok(new
                {
                    ID = userInfo.Id,
                    User = userInfo.UserName,
                    ClassName = userInfo.Class != null ? userInfo.Class.Name : "",
                    ClassID = userInfo.ClassID,
                    FullName = userInfo.FullName,
                    DateBorn = userInfo.DateBorn,
                    StartDate = userInfo.StartDate,
                    EndDate = userInfo.EndDate,
                    MajorName = userInfo.ClassID !=  null ? (classes.Where(x=>x.ID == userInfo.ClassID).Select(x=>x.Speciality).FirstOrDefault() != null  ? classes.Where(x => x.ID == userInfo.ClassID).Select(x => x.Speciality.Name).FirstOrDefault():"") :"",
                    MajorID = userInfo.ClassID != null ?  classes.Where(x=>x.ID == userInfo.ClassID).Select(x=>x.SpecialityID).FirstOrDefault() : null,
                    Type = userInfo.Type,
                    TeacherID = userInfo.TeacherID,

                    token = new JwtSecurityTokenHandler().WriteToken(token),
                });
            }
            return Unauthorized();
        }

        [HttpGet]
        [Route("GetUserById")]
        public async Task<IActionResult> GetUserByID(string id)
        {
            var userInfo = db.AspNetUsers.Where(x => x.Id == id).Include("Class").FirstOrDefault();
            if(userInfo == null) return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Massage = "Không tìm thấy người dùng" });
            else
            {
                return Ok(new
                {
                    ID = userInfo.Id,
                    User = userInfo.UserName,
                    ClassName = userInfo.Class != null ? userInfo.Class.Name : "",
                    ClassID = userInfo.ClassID,
                    FullName = userInfo.FullName,
                    DateBorn = userInfo.DateBorn,
                    StartDate = userInfo.StartDate,
                    EndDate = userInfo.EndDate
                });
            }
        }

        [HttpPost]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModel model)
        {
            var user = await userManager.FindByIdAsync(model.ID);
            var result = await userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            if(result.Succeeded) return Ok(new Response { Status = "Success", Massage = "Thay đổi mật khẩu thành công!" });
            else return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Massage = "Thay đổi mật khẩu thất bại" });

        }

        [HttpPost]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] ApplicationUser model)
        {
            var user = await userManager.FindByIdAsync(model.Id);
            if(user == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Massage = "Không tìm thấy người dùng" });
            }
            else
            {
                user.LastName = model.LastName;
                user.FirstName = model.FirstName;
                user.Address = model.Address;
                user.DateBorn = model.DateBorn;
                user.FullName = model.FullName;

                var result = await userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return Ok(new Response { Status = "Success", Massage = "Cập nhật thành công!" });
                }
                else return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Massage = "Cập nhật không thành công!" });
            }
        }
    }
}
