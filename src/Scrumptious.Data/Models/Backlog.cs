using System;
using System.Collections.Generic;

namespace Scrumptious.Data.Models
{
    public partial class Backlog : Library.Models.Backlog
    {
        public Backlog()
        {
            Task = new HashSet<Task>();
        }

        public int BacklogId { get; set; }
        public int FkSprintId { get; set; }

        public Sprint FkSprint { get; set; }
        public new ICollection<Task> Task { get; set; }
    }
}
