using System;
using System.Collections.Generic;

namespace Scrumptious.Library.Models
{
    public partial class Backlog
    {
        public Backlog()
        {
            Task = new HashSet<Task>();
        }

        public int BacklogId { get; set; }
        public int FkSprintId { get; set; }

        public Sprint FkSprint { get; set; }
        public ICollection<Task> Task { get; set; }
    }
}
