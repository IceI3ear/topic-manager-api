using System;
using System.Collections.Generic;

#nullable disable

namespace APIBlog.Models
{
    public partial class WebModule
    {
        public WebModule()
        {
            ModuleNavigations = new HashSet<ModuleNavigation>();
            WebContents = new HashSet<WebContent>();
            WebRedirects = new HashSet<WebRedirect>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public string Image { get; set; }
        public int? ParentId { get; set; }
        public string ContentTypeId { get; set; }
        public string Url { get; set; }
        public string SeoTitle { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public int? Order { get; set; }
        public string Uid { get; set; }
        public string IndexView { get; set; }
        public string IndexLayout { get; set; }
        public string PublishIndexView { get; set; }
        public string PublishIndexLayout { get; set; }
        public string PublishDetailView { get; set; }
        public string PublishDetailLayout { get; set; }
        public int? Status { get; set; }
        public string SubQuerys { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? ShowOnMenu { get; set; }
        public bool? ShowOnAdmin { get; set; }
        public string Culture { get; set; }
        public string Icon { get; set; }
        public string CodeColor { get; set; }
        public string ActiveArticle { get; set; }
        public string Target { get; set; }
        public string Img { get; set; }
        public string ImgActive { get; set; }

        public virtual ContentType ContentType { get; set; }
        public virtual ICollection<ModuleNavigation> ModuleNavigations { get; set; }
        public virtual ICollection<WebContent> WebContents { get; set; }
        public virtual ICollection<WebRedirect> WebRedirects { get; set; }
    }
}
