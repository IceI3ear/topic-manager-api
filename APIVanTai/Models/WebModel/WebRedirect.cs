using System;
using System.Collections.Generic;

#nullable disable

namespace APIBlog.Models
{
    public partial class WebRedirect
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int? WebModuleId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? TimeRedirect { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual WebModule WebModule { get; set; }
    }
}
