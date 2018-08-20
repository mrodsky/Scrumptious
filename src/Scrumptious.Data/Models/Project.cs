using System;
using System.Collections.Generic;

namespace Scrumptious.Data.Models
{
    public class Project : Scrumptious.Library.Models.Project
    {
        public int ProjectId { get; set; } 
        public bool Active { get; set; } 
    }
}
