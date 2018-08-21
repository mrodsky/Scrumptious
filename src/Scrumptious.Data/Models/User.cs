using System;
using System.Collections.Generic;

namespace Scrumptious.Data.Models
{
    public partial class User : Library.Models.User
    {
        public User()
        {
            Task = new HashSet<Task>();
        }



        public int UserId { get; set; }
      

        public new ICollection<Task> Task { get; set; }
    }
}
