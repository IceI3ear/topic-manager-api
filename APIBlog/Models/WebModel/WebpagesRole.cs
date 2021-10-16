using System;
using System.Collections.Generic;

#nullable disable

namespace APIVanTai.Models
{
    public partial class WebpagesRole
    {
        public WebpagesRole()
        {
            WebpagesUsersInRoles = new HashSet<WebpagesUsersInRole>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual ICollection<WebpagesUsersInRole> WebpagesUsersInRoles { get; set; }
    }
}
