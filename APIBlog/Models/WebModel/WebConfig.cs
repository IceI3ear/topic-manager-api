using System;
using System.Collections.Generic;

#nullable disable

namespace APIVanTai.Models
{
    public partial class WebConfig
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
