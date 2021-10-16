using System;
using System.Collections.Generic;

#nullable disable

namespace APIVanTai.Models
{
    public partial class WebCategory
    {
        public WebCategory()
        {
            InverseParent = new HashSet<WebCategory>();
            WebContentCategories = new HashSet<WebContentCategory>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Body { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public int? Status { get; set; }
        public int? Order { get; set; }
        public int? Ctype { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ParentId { get; set; }

        public virtual WebCategory Parent { get; set; }
        public virtual ICollection<WebCategory> InverseParent { get; set; }
        public virtual ICollection<WebContentCategory> WebContentCategories { get; set; }
    }
}
