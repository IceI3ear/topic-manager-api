using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIVanTai.Models
{
    [Table("Vehicles")]
    public class Vehicles
    {
        [Key]
        public int ID { get; set; }
        public int? PartnerID { get; set; }
        public int? WeightID { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public string CarOwerName { get; set; }
        public string NumberPlate { get; set; }
        public string Mobile { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }

    [Table("VehicleWeights")]
    public class VehicleWeights
    {
        [Key]
        public int ID { get; set; }
        public string WeightName { get; set; }
        
    }

    [Table("Partners")]
    public class Partners
    {
        [Key]
        public int ID { get; set; }
        public string PartnerName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string PartnerCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        
    }

    [Table("Locations")]
    public class Locations
    {
        [Key]
        public int ID { get; set; }
        public string LocationName { get; set; }
        public string DistrictID { get; set; }
        public string ProvinceID { get; set; }
        public string AddressName { get; set; }
        public int ParentID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }        
    }

    [Table("Route")]
    public class Route
    {
        [Key]
        public int ID { get; set; }        
        public int EndLocationID { get; set; }
        public int StartLocationID { get; set; }
        public string RouteCode { get; set; }
        public string Distance { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }        
    }
}
