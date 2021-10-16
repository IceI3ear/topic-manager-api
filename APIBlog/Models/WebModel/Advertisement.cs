﻿using System;
using System.Collections.Generic;

#nullable disable

namespace APIVanTai.Models
{
    public partial class Advertisement
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Media { get; set; }
        public string Link { get; set; }
        public string Target { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? AdvertisementPositionId { get; set; }
        public string Culture { get; set; }
        public string Video { get; set; }
        public int? Status { get; set; }

        public virtual AdvertisementPosition AdvertisementPosition { get; set; }
    }
}
