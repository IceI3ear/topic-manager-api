using System;
using System.Collections.Generic;

#nullable disable

namespace APIBlog.Models
{
    public partial class Speciality
    {
        public Speciality()
        {
            Classes = new HashSet<Class>();
            RegisterTopics = new HashSet<RegisterTopic>();
            Topics = new HashSet<Topic>();
            UserProfiles = new HashSet<UserProfile>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<RegisterTopic> RegisterTopics { get; set; }
        public virtual ICollection<Topic> Topics { get; set; }
        public virtual ICollection<UserProfile> UserProfiles { get; set; }
    }
}
