using System;
using System.Collections.Generic;

#nullable disable

namespace APIBlog.Models
{
    public partial class AccessAdminSite
    {
        public int UserId { get; set; }
        public int AdminSiteId { get; set; }

        public virtual AdminSite AdminSite { get; set; }
        public virtual UserProfile User { get; set; }
    }
}
