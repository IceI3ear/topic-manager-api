using System;
using System.Collections.Generic;

#nullable disable

namespace APIBlog.Models
{
    public partial class WebpagesOauthMembership
    {
        public string Provider { get; set; }
        public string ProviderUserId { get; set; }
        public int UserId { get; set; }
    }
}
