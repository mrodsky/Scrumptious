using Scrumptious.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Scrumptious.Testing.Library
{
    public class BacklogTests
    {
        private Backlog sut = new Backlog();

        [Fact]
        public void Test_BacklogAddTask()
        {
            sut.AddTask();
            Assert.True(1 <= sut.Task.Count());
        }
    }
}
