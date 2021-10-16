using System;
using System.Collections.Generic;

#nullable disable

namespace APIBlog.Models
{
    public partial class WebContentCategory
    {
        public int WebCategoryId { get; set; }
        public int WebContentId { get; set; }
        public int? Order { get; set; }

        public virtual WebCategory WebCategory { get; set; }
        public virtual WebContent WebContent { get; set; }
    }
}
