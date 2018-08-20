using Scrumptious.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Xunit;

namespace Scrumptious.Testing.Library
{
    public partial class TaskTests
    {
        private readonly Task sut = new Task()
        {
            Name = "Test",
            TaskDescription = "Get all these tests working",
            Requirements = "1. write good code",
            Step = new List<Step>(),
            Completed = false
        };

        [Theory]
        [InlineData("Test2")]
        public void Test_ModTaskName(string NewName)
        {
            sut.Name = NewName;
            
            Assert.Equal("Test2", sut.Name);
        }

        [Theory]
        [InlineData("Tests have passed")]
        public void Test_ModTaskDescription(string NewDescription)
        {
            sut.TaskDescription = NewDescription;
            Assert.Equal("Tests have passed", sut.TaskDescription);
        }

        [Theory]
        [InlineData("1. write good code 2. running tests 3. Pass tests")]
        public void Test_ModTaskRequirements(string NewRequirements)
        {
            sut.Requirements = NewRequirements;

            Assert.Equal("1. write good code 2. running tests 3. Pass tests", sut.Requirements);
        }

        [Fact]
        public void Test_AddStep()
        {
            var a = new Step();

            sut.Step.Add(a);
            Assert.True(sut.Step.Count == 1);
        }

    }
}
