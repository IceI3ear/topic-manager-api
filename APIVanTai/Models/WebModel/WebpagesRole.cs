using System;
using System.Collections.Generic;

#nullable disable

namespace APIBlog.Models
{
    public partial class WebpagesRole
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
