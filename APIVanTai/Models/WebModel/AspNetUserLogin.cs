using System;
using System.Collections.Generic;

#nullable disable

namespace APIBlog.Models
{
    public partial class AspNetUserLogin
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderDisplayName { get; set; }
        public int UserId { get; set; }
    }
}
