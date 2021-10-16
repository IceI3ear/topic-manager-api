using System;
using System.Collections.Generic;

#nullable disable

namespace APIVanTai.Models
{
    public partial class AdminSite
    {
        public AdminSite()
        {
            AccessAdminSites = new HashSet<AccessAdminSite>();
            InverseParent = new HashSet<AdminSite>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public int? ParentId { get; set; }
        public string AccessKey { get; set; }
        public int? Order { get; set; }
        public string Img { get; set; }
        public string ImgActive { get; set; }

        public virtual AdminSite Parent { get; set; }
        public virtual ICollection<AccessAdminSite> AccessAdminSites { get; set; }
        public virtual ICollection<AdminSite> InverseParent { get; set; }
    }
}
