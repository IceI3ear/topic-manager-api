using System;
using System.Collections.Generic;

#nullable disable

namespace APIBlog.Models
{
    public partial class ContentImage
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public int? Order { get; set; }
        public bool? Slide { get; set; }
        public int? WebContentId { get; set; }

        public virtual WebContent WebContent { get; set; }
    }
}
