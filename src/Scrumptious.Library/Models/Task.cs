﻿using System;
using System.Collections.Generic;

namespace Scrumptious.Library.Models
{
    public partial class Task
    {
        public Task()
        {
            Step = new HashSet<Step>();
        }

        public int TaskId { get; set; }
        public string Name { get; set; }
        public string TaskDescription { get; set; }
        public string Requirements { get; set; }
        public bool Completed { get; set; }
        public int? FkUserId { get; set; }
        public int FkBacklogId { get; set; }

        public Backlog FkBacklog { get; set; }
        public User FkUser { get; set; }
        public ICollection<Step> Step { get; set; }
    }
}
