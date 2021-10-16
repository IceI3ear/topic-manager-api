using System;
using System.Collections.Generic;

#nullable disable

namespace APIBlog.Models
{
    public partial class Country
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string IsoCode { get; set; }
    }
}
