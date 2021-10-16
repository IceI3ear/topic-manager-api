using System.ComponentModel.DataAnnotations;

namespace APIVanTai.Authentication
{
    public class ChangePasswordModel
    {
        public string ID { get; set; }
        [Required(ErrorMessage = "CurrentPassword is required")]
        public string CurrentPassword { get; set; }
        [Required(ErrorMessage = "NewPassword is required")]
        public string NewPassword { get; set; }
    }
}
