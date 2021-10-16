using System;
using System.Collections.Generic;

#nullable disable

namespace APIVanTai.Models
{
    public partial class AccessLog
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string Action { get; set; }
    }
}
