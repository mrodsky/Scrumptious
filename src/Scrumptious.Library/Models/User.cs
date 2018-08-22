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


        //public Project CreateProject(string n, string r, string d)
        //{
        //    Project P = new Project()
        //    {
        //        ProjectName = n,
        //        ProjectRequirements = r,
        //        ProjectDescription = d
        //    };
        //    return P;
        //}

        public void AddProject(Project p)
        {
            
        }
        public void CompleteTask(Task T)
        {
            T.Completed = true;
        }

        public List<Task> ViewTask()
        {
            return new List<Task>();
        }

        public void RequestTask(Task T)
        {
            Task.Add(T);
        }
    }
}
