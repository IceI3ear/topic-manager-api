using System;
using System.Collections.Generic;

#nullable disable

namespace APIVanTai.Models
{
    public partial class UserProfile
    {
        public UserProfile()
        {
            AccessAdminSites = new HashSet<AccessAdminSite>();
            AccessWebModules = new HashSet<AccessWebModule>();
            WebpagesUsersInRoles = new HashSet<WebpagesUsersInRole>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Avatar { get; set; }
        public int? BranchId { get; set; }
        public string Position { get; set; }

        public virtual ICollection<AccessAdminSite> AccessAdminSites { get; set; }
        public virtual ICollection<AccessWebModule> AccessWebModules { get; set; }
        public virtual ICollection<WebpagesUsersInRole> WebpagesUsersInRoles { get; set; }
    }
}
