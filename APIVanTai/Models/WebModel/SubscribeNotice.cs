using System;
using System.Collections.Generic;

#nullable disable

namespace APIBlog.Models
{
    public partial class SubscribeNotice
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? Status { get; set; }
    }
}
