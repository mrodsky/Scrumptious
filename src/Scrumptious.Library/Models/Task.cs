using System;
using System.Collections.Generic;

namespace Scrumptious.Library.Models
{
    public  class Task
    {
        public Task()
        {
            Step = new HashSet<Step>();
        }

        public string Name { get; set; }
        public string TaskDescription { get; set; }
        public string Requirements { get; set; }
        public ICollection<Step> Step { get; set; }

    }
}
