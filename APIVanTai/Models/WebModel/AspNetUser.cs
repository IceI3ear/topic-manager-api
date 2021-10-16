using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace APIBlog.Models
{
    public partial class AspNetUser
    {
        [Key]
        public string Id { get; set; }


        //[RegularExpression(@"^[a-zA-Z0-9_.-]*$", ErrorMessageResourceType = typeof(AccountResources), ErrorMessageResourceName = "UserNameNotValid")]
        [Display(Name = "Tên")]
        public string UserName
        {
            get; set;
        }
        //[RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessageResourceType = typeof(AccountResources), ErrorMessageResourceName = "EmailNotValid")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //[RegularExpression(@"^(84|0[3|5|7|8|9])+([0-9]{8})\b$", ErrorMessageResourceType = typeof(AccountResources), ErrorMessageResourceName = "MobileNotValid")]
        [Display( Name = "Mobile")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Avatar")]
        public string Image { get; set; }

        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
        [Display(Name = "Ngày sinh")]
        public DateTime? DateBorn { get; set; }

        [Display(Name = "Ngày bắt đầu")]

        public DateTime? StartDate { get; set; }

        [Display(Name = "Ngày kết thúc")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Lớp")]
        public int? ClassID { get; set; }

        public string FullName { get; set; }

        [ForeignKey("ClassID")]
        public virtual Class Class { get; set; }

        public int? Type { get; set; }
        public int? TeacherID { get; set; }
    }
}
