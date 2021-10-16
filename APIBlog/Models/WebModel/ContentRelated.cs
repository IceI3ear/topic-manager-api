using System;
using System.Collections.Generic;

#nullable disable

namespace APIVanTai.Models
{
    public partial class ContentRelated
    {
        public int MainId { get; set; }
        public int RelatedId { get; set; }
        public int? Order { get; set; }
        public string Type { get; set; }

        public virtual WebContent Main { get; set; }
        public virtual WebContent Related { get; set; }
    }
}
