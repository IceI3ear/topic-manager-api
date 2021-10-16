using System;
using System.Collections.Generic;

#nullable disable

namespace APIVanTai.Models
{
    public partial class Language
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public bool? Published { get; set; }
        public int? Order { get; set; }
    }
}
