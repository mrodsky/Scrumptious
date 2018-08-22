using System;
using System.Collections.Generic;

namespace Scrumptious.Data.Models
{
    public partial class User : Library.Models.User
    {
        private readonly MockContext mock = new MockContext();

        public User()
        {
            Task = new HashSet<Task>();
        }

        public int UserId { get; set; }

        public Project CreateProject(string n, string r, string d)
        {
            Project P = new Project()
            {
                ProjectName = n,
                ProjectRequirements = r,
                ProjectDescription = d
            };
            return P;
        }

        public void AddProject(Project p)
        {
            mock.SaveAsync(p);
        }
        public new ICollection<Task> Task { get; set; }
    }
}
