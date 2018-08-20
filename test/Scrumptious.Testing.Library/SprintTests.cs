using Scrumptious.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Scrumptious.Testing.Library
{
    public class SprintTests
    {
        public SprintTests()
        {
            sut = new Sprint()
            {
                Name = "Sprinty",
                SprintDescription = "Hi, I'm here for a test"
            };
        }

        public Sprint sut;

        [Fact]
        public void Test_SprintAddBacklog()
        {
            var bl = new Backlog();
            sut.AddBacklog(bl);
            Assert.True(sut.Backlog != null);
        }

        [Fact]
        public void Test_SprintName()
        {
            Assert.False(string.IsNullOrEmpty(sut.Name));
        }

        [Fact]
        public void Test_SprintSprintDiscription()
        {
            Assert.False(string.IsNullOrEmpty(sut.SprintDescription));
        }
    }
}
