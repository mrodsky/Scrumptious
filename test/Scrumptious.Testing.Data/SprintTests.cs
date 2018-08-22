using Scrumptious.Data;
using Scrumptious.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Scrumptious.Testing.Data
{
   public class SprintTests
    {
        private Sprint sut; 

        private readonly MockContext mock = new MockContext();
        private readonly EntityData entity = new EntityData();
        private readonly scrumptiousdbContext ctx = new scrumptiousdbContext();

        public SprintTests()
        {
            sut = new Sprint()
            {
                Name = "Sprint 1",
                SprintDescription = "3 weeks to finish the rocket to the sun",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(1),
                Completed = false,
                Backlog = null,
            };
            sut.AddBacklog(new Backlog());
            
        }

        [Fact]
        public void Test_SprintId()
        {
            Sprint sp2 = new Sprint();
            mock.SaveAsync(sut);
            mock.SaveAsync(sp2);
            Assert.True(sut.SprintId != sp2.SprintId);
            Assert.True(typeof(int) == sut.SprintId.GetType());
        }

        [Fact]
        public void Test_Sprint_Save_Mock()
        {
            var expected = 1;
            mock.SaveAsync<Sprint>(sut);
            var actual = mock.Sprint.Count();

            Assert.True(expected <= actual);

        }

        [Fact]
        public void Test_Sprint_Read_Mock()
        {
            mock.SaveAsync<Sprint>(sut);

            var expected = sut.SprintId;

            var actual = mock.ReadList<Sprint>(1);

            Assert.Equal(expected, actual.SprintId);


        }
    }
}
