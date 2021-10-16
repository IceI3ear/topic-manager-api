using System;
using System.Collections.Generic;

#nullable disable

namespace APIBlog.Models
{
    public partial class Province
    {
        public string Id { get; set; }
        public string ProvinceName { get; set; }
        public int? CountryId { get; set; }
    }
}
