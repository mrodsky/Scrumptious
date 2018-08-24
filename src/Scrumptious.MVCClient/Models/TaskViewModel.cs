using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scrumptious.MVCClient.Models
{
    public class TaskViewModel
    {
        public string Name { get; set; }
        public string TaskDescription { get; set; }
        public string Requirements { get; set; }
        public bool Completed { get; set; }
        public List<StepViewModel> Step { get; set; }
    }
}
