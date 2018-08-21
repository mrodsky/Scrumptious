using System;
using System.Collections.Generic;

namespace Scrumptious.Data.Models
{
    public partial class Task : Library.Models.Task
    {
        public Task()
        {
            Step = new HashSet<Step>();
        }

        public int TaskId { get; set; }
     
        
        public int? FkUserId { get; set; }
        public int FkBacklogId { get; set; }

        public Backlog FkBacklog { get; set; }
        public User FkUser { get; set; }
        public new ICollection<Step> Step { get; set; }
    }
}
