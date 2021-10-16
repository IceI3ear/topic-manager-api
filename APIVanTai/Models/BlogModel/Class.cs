using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace APIBlog.Models
{
    public partial class Class
    {
        public Class()
        {
            AspNetUsers = new HashSet<AspNetUser>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "Tên")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn khoa")]
        [Display(Name = "Khoa")]
        public int? SpecialityID { get; set; }

        [ForeignKey("SpecialityID")]
        public virtual Speciality Speciality { get; set; }
        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
    }
}
