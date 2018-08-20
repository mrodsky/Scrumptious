using Scrumptious.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Scrumptious.Testing.Library
{
    public class ProjectTests
    {
        private Project sut = new Project();
        [Fact]
        public void Test_ProjectHasName()
        {
            sut.ProjectName = "billy bob";
            Assert.IsType<string>(sut.ProjectName);
        }

        [Fact]
        public void Test_ProjectAddSprint()
        {
            sut.AddSprint();
            Assert.True(1 <= sut.Sprint.Count());
        }

        [Fact]
        public void Test_ProjectModifyRequirement()
        {
            sut.ProjectName = "billy bob";
            Assert.IsType<string>(sut.ProjectName);
        }

        [Fact]
        public void Test_ProjectModifyDesc()
        {
            sut.ProjectName = "billy bob";
            Assert.IsType<string>(sut.ProjectName);
        }
    }
}
