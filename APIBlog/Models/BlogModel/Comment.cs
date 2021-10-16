using System;
using System.Collections.Generic;

#nullable disable

namespace APIVanTai.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int? BlogId { get; set; }
        public string Body { get; set; }
        public int? Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsRemove { get; set; }

        public virtual BlogContent Blog { get; set; }
        public virtual AspNetUser User { get; set; }
    }
}
