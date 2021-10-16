using System;
using System.Collections.Generic;

#nullable disable

namespace APIBlog.Models
{
    public partial class Navigation
    {
        public Navigation()
        {
            ModuleNavigations = new HashSet<ModuleNavigation>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Order { get; set; }
        public string Key { get; set; }

        public virtual ICollection<ModuleNavigation> ModuleNavigations { get; set; }
    }
}
