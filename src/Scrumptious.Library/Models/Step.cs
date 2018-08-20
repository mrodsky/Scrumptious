using System;
using System.Collections.Generic;

namespace Scrumptious.Library.Models
{
    public partial class Step
    {
        public int StepId { get; set; }
        public string Name { get; set; }
        public string StepDescription { get; set; }
        public bool Completed { get; set; }
        public int FkTaskId { get; set; }

        public Task FkTask { get; set; }
    }
}
