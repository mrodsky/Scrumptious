using System;
using System.Collections.Generic;

namespace Scrumptious.Data.Models
{
    public class Step : Scrumptious.Library.Models.Step
    {
        public int StepId { get; set; }
        public bool Completed { get; set; }
        public int FkTaskId { get; set; }

        public Task FkTask { get; set; }
    }
}
