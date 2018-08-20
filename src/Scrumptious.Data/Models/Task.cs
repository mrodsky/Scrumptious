using System;
using System.Collections.Generic;

namespace Scrumptious.Data.Models
{
    public class Task : Scrumptious.Library.Models.Task
    {
   
        public int TaskId { get; set; }

        public bool Completed { get; set; }
        public int? FkUserId { get; set; }
        public int FkBacklogId { get; set; }

        public Backlog FkBacklog { get; set; }
        public User FkUser { get; set; }
      
    }
}
