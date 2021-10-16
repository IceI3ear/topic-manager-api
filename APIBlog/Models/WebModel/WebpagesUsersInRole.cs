using System;
using System.Collections.Generic;

#nullable disable

namespace APIVanTai.Models
{
    public partial class WebpagesUsersInRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public virtual WebpagesRole Role { get; set; }
        public virtual UserProfile User { get; set; }
    }
}
