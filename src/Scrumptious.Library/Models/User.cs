using System;
using System.Collections.Generic;

namespace Scrumptious.Library.Models
{
    public partial class User
    {
        public User()
        {
            Task = new HashSet<Task>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public ICollection<Task> Task { get; set; }

        public void AddProject(Project P)
        {

        }

        public void CompleteTask(Task T)
        {
            T.Completed = true;
        }

        public List<Task> RequestTask()
        {
            return new List<Task>();
        }

        public void RequestTask(Task T)
        {
            Task.Add(T);
        }
    }
}
