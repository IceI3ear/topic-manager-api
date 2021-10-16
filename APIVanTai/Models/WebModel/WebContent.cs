using System;
using System.Collections.Generic;

#nullable disable

namespace APIBlog.Models
{
    public partial class WebContent
    {
        public WebContent()
        {
            ContentImages = new HashSet<ContentImage>();
            ContentRelatedMains = new HashSet<ContentRelated>();
            ContentRelatedRelateds = new HashSet<ContentRelated>();
            WebContentCategories = new HashSet<WebContentCategory>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Body { get; set; }
        public string Link { get; set; }
        public int? WebModuleId { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public int? Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? Order { get; set; }
        public string Uid { get; set; }
        public string LinkVideo { get; set; }
        public DateTime? Event { get; set; }
        public string SeoTitle { get; set; }
        public string Icon { get; set; }
        public decimal? CountView { get; set; }
        public DateTime? PublishDate { get; set; }

        public virtual WebModule WebModule { get; set; }
        public virtual ICollection<ContentImage> ContentImages { get; set; }
        public virtual ICollection<ContentRelated> ContentRelatedMains { get; set; }
        public virtual ICollection<ContentRelated> ContentRelatedRelateds { get; set; }
        public virtual ICollection<WebContentCategory> WebContentCategories { get; set; }
    }
}
