using System;
using System.Collections.Generic;

namespace Scrumptious.Data.Models
{
    public class Sprint : Scrumptious.Library.Models.Sprint
    {
      

        public int SprintId { get; set; }
        public bool Completed { get; set; }
        public int FkProjectId { get; set; }

        public Project FkProject { get; set; }
       
    }
}
