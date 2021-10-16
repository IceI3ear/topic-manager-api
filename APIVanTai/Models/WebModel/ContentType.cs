using System;
using System.Collections.Generic;

#nullable disable

namespace APIBlog.Models
{
    public partial class ContentType
    {
        public ContentType()
        {
            WebModules = new HashSet<WebModule>();
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Controller { get; set; }
        public int? Order { get; set; }
        public string Entity { get; set; }

        public virtual ICollection<WebModule> WebModules { get; set; }
    }
}
