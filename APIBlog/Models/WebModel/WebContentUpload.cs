using System;
using System.Collections.Generic;

#nullable disable

namespace APIVanTai.Models
{
    public partial class WebContentUpload
    {
        public WebContentUpload()
        {
            InverseFolder = new HashSet<WebContentUpload>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public string FullPath { get; set; }
        public string Uid { get; set; }
        public int? FolderId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string MimeType { get; set; }

        public virtual WebContentUpload Folder { get; set; }
        public virtual ICollection<WebContentUpload> InverseFolder { get; set; }
    }
}
