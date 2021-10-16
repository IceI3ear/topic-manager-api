using System;
using System.Collections.Generic;

#nullable disable

namespace APIBlog.Models
{
    public partial class UploadFile
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
    }
}
