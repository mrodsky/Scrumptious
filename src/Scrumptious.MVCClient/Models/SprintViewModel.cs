using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scrumptious.MVCClient.Models
{
    public class SprintViewModel
    {
        public string SprintName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string SprintDescription { get; set; }
        public List<BacklogViewModel> Backlog {get; set;}
    }
}
