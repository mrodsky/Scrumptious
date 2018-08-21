using Scrumptious.Data;
using Scrumptious.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Scrumptious.Testing.Data
{
   public  class EntityTests
    {

        private readonly MockContext mock = new MockContext();
        private readonly EntityData entity = new EntityData();
        private readonly scrumptiousdbContext ctx = new scrumptiousdbContext();

        private Project sut;

        public EntityTests()
        {
            sut = new Project()
            {
                Active = true,
                ProjectDescription = "hello project 2 ",
                ProjectName = "Scrumptious",
                ProjectRequirements = "make it work MVP",
                Sprint = null,
            };
        }

        [Fact]
        public void Read_Project_Async_Test()
        {
           sut.AddSprint();
           entity.SaveAsync(sut);

            var expect = sut;

            var actual = entity.ReadList<Project>(1);
            Assert.True(1 <= mock.Project.Count());
            Assert.Equal(expect.ProjectId, actual.ProjectId);
        }

        //[Fact]
        public void Save_Project_Async_Test()
        {

        }
    }
}
