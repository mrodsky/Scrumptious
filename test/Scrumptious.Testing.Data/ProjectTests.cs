using Scrumptious.Data;
using Scrumptious.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Scrumptious.Testing.Data
{
   public class ProjectTests
    {
        private Project sut;

        private readonly MockContext mock = new MockContext();
        private readonly EntityData entity = new EntityData();
        private readonly scrumptiousdbContext ctx = new scrumptiousdbContext();

        public ProjectTests()
        {
            sut = new Project()
            {
                ProjectName = "sutName",
                ProjectDescription = "cool project",
                ProjectRequirements = "must work"
            };
        }

        [Fact]
        public void Test_ProjectId()
        {
            Project pj2 = new Project();
            mock.SaveAsync(sut);
            mock.SaveAsync(pj2);
            Assert.True(sut.ProjectId != pj2.ProjectId);
            Assert.True(typeof(int) == sut.ProjectId.GetType());
        }

        [Fact]
        public void Test_Proejct_Save_Mock()
        {
            var expected = 1;
            mock.SaveAsync<Project>(sut);
            var actual = mock.Project.Count();

            Assert.True(expected <= actual);

        }

        [Fact]
        public void Test_Project_Read_Mock()
        {
            mock.SaveAsync<Project>(sut);

            var expected = sut.ProjectId;

            var actual = mock.ReadList<Project>(1);

            Assert.Equal(expected, actual.ProjectId);
        }

    }
}
