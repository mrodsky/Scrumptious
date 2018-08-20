using System;
using System.Collections.Generic;

namespace Scrumptious.Data.Models
{
    public class Backlog  : Scrumptious.Library.Models.Backlog
    {
 
        public int BacklogId { get; set; }
        public int FkSprintId { get; set; }

        public Sprint FkSprint { get; set; }
        
    }
}
