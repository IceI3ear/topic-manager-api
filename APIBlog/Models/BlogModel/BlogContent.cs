using System;
using System.Collections.Generic;

#nullable disable

namespace APIVanTai.Models
{
    public partial class BlogContent
    {
        public BlogContent()
        {
            Comments = new HashSet<Comment>();
            Votes = new HashSet<Vote>();
        }

        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Body { get; set; }
        public int? Status { get; set; }
        public decimal? CountView { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Uid { get; set; }
        public bool? IsRemove { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Vote> Votes { get; set; }
    }
}
