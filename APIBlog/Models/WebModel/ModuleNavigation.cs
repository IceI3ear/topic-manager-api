using System;
using System.Collections.Generic;

#nullable disable

namespace APIVanTai.Models
{
    public partial class ModuleNavigation
    {
        public int WebModuleId { get; set; }
        public int NavigationId { get; set; }

        public virtual Navigation Navigation { get; set; }
        public virtual WebModule WebModule { get; set; }
    }
}
