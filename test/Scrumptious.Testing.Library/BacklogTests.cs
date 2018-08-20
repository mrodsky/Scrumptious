using Scrumptious.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;

namespace Scrumptious.Testing.Library
{
    public class BacklogTests
    {
        private Backlog bl = new Backlog();

        [Fact]
        public void AddTask_Test()
        {
            bl.Task.Add(new Task());
            Assert.True(bl.Task.Count == 1);
        }

        [Fact]
        public void RemoveTask_Test()
        {
            var a = new Task();
            bl.Task.Add(a);
            bl.Task.Remove(a);
            Assert.True(bl.Task.Count == 0);
        }

        [Theory]
        [InlineData ("Test2")]
        public void ModTaskName_Test(string NewName)
        {
            var a = new Task()
            {
                Name = "Test"
            };

            bl.Task.Add(a);
            bl.Task.ElementAt(0).Name = NewName;

            Assert.Equal("Test2", bl.Task.ElementAt(0).Name);
        }

        [Theory]
        [InlineData ("Tests have passed")]
        public void ModTaskDescription_Test(string NewDescription)
        {
            var a = new Task()
            {
                TaskDescription = "Get all these tests working"
            };

            bl.Task.Add(a);
            bl.Task.ElementAt(0).TaskDescription = NewDescription;

            Assert.Equal("Tests have passed", bl.Task.ElementAt(0).TaskDescription);
        }

        [Theory]
        [InlineData("1. write good code 2. running tests 3. Pass tests")]
        public void ModTaskRequirements_Test(string NewRequirements)
        {
            var a = new Task()
            {
                Requirements = "1. write good code"
            };

            bl.Task.Add(a);
            bl.Task.ElementAt(0).Requirements = NewRequirements;

            Assert.Equal("1. write good code 2. running tests 3. Pass tests", bl.Task.ElementAt(0).Requirements);
        }
    }
}
