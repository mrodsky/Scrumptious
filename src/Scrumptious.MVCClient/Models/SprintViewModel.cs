using Scrumptious.MVCClient.Models;
using System;
using System.Collections.Generic;

namespace Scrumptious.MvcClient.Models
{
    public class SprintViewModel
    {
        public SprintViewModel()
        {
            Backlog = new HashSet<BacklogViewModel>();
        }

        public int SprintId { get; set; }

        public bool Completed { get; set; }
        public int FkProjectId { get; set; }

        public new ICollection<BacklogViewModel> Backlog { get; set; }

        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string SprintDescription { get; set; }

    }
}