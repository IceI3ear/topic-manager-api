using System;
using System.Collections.Generic;

#nullable disable

namespace APIBlog.Models
{
    public partial class UserProfile
    {
        public UserProfile()
        {
            RegisterTopics = new HashSet<RegisterTopic>();
            Topics = new HashSet<Topic>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Avatar { get; set; }
        public int? BranchId { get; set; }
        public string Position { get; set; }
        public DateTime? DateBorn { get; set; }
        public int? SpecialityId { get; set; }

        public virtual Speciality Speciality { get; set; }
        public virtual ICollection<RegisterTopic> RegisterTopics { get; set; }
        public virtual ICollection<Topic> Topics { get; set; }
    }
}
