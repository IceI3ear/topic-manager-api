using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;

#nullable disable

namespace APIBlog.Models
{
    public partial class Topic
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "Tên đề tài")]
        public string TopicName { get; set; }

        [Display(Name = "File link")]
        public string FileLink { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Display(Name = "Người dùng")]
        public int? UserID { get; set; }

        [Display(Name = "Sinh viên")]
        public string StudentID { get; set; }

        [Display(Name = "Ngày bắt đầu")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Ngày kết thúc")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Ngày đăng ký")]
        public DateTime? StartRegister { get; set; }

        [Display(Name = "Hạn đăng ký")]
        public DateTime? EndRegister { get; set; }

        [Display(Name = "LinkFile")]
        public string LinkFile { get; set; }

        [Display(Name = "Khoa")]
        public int? SpecialityID { get; set; }

        [ForeignKey("SpecialityID")]
        public virtual Speciality Speciality { get; set; }

        [ForeignKey("UserID")]
        public virtual UserProfile Teacher { get; set; }

        [ForeignKey("StudentID")]
        public virtual AspNetUser Student { get; set; }
    }
}
