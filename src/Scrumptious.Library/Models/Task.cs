using System;
using System.Collections.Generic;
using System.Linq;

namespace Scrumptious.Library.Models
{
    public partial class Task
    {
        public Task()
        {
            Step = new HashSet<Step>();
        }

       
        public string Name { get; set; }
        public string TaskDescription { get; set; }
        public string Requirements { get; set; }
        public bool Completed { get; set; }
        public ICollection<Step> Step { get; set; }

        public void AddStep()
        {
            Step.Add(new Step());
        }

        public void RemoveStep(Step S)
        {
            Step.Remove(S);
        }

        public List<Step> ViewSteps()
        {
            return Step.AsEnumerable().ToList();
        }


    }
}
