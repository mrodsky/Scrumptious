using System;
using System.Collections.Generic;

namespace Scrumptious.Library.Models
{
    public partial class User
    {
        public User()
        {
            Task = new HashSet<Task>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public ICollection<Task> Task { get; set; }
    }
}
