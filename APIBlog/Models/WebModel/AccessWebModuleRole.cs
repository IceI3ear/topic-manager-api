using System;
using System.Collections.Generic;

#nullable disable

namespace APIVanTai.Models
{
    public partial class AccessWebModuleRole
    {
        public int RoleId { get; set; }
        public int WebModuleId { get; set; }
        public bool? View { get; set; }
        public bool? Add { get; set; }
        public bool? Edit { get; set; }
        public bool? Delete { get; set; }
    }
}
