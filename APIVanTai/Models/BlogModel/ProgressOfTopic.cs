using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace APIBlog.Models
{
    public partial class ProgressOfTopic
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "Đề tài")]
        public int? TopicID { get; set; }

        [Display(Name = "Ngày bắt đầu")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Ngày kết thúc")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Thái độ")]
        public int? Atitule { get; set; }

        [Display(Name = "Nỗ lực")]
        public int? Effort { get; set; }

        [Display(Name = "Độ hoàn thành")]
        public int? Complete { get; set; }

        [Display(Name = "Điểm")]
        public int? Point { get; set; }

        [Display(Name = "Phê duyệt")]
        public bool? Status { get; set; }

        [Display(Name = "Nhận xét")]
        public string Description { get; set; }

        [Display(Name = "LinkFile")]
        public string LinkFile { get; set; }

        [ForeignKey("TopicID")]
        public virtual Topic Topic { get; set; }

    }
}
