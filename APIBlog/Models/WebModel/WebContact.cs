using System;
using System.Collections.Generic;

#nullable disable

namespace APIVanTai.Models
{
    public partial class WebContact
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public int? LoaiDonHang { get; set; }
        public int? LoaiLienHe { get; set; }
        public int? WebModuleId { get; set; }
    }
}
