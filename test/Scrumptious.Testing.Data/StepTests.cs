using Scrumptious.Data;
using Scrumptious.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Scrumptious.Testing.Data
{
    public class StepTests
    {

        private Step sut;
        private readonly MockContext mock = new MockContext();
        private readonly EntityData entity = new EntityData();
        private readonly scrumptiousdbContext ctx = new scrumptiousdbContext();

        public StepTests()
        {
            sut = new Step() { Name = "BuildRocket", StepDescription = "add Rocket Fuel", Completed = false };
        }

        [Fact]
        public void Test_StepId()
        {
            Step s2 = new Step();
            mock.SaveAsync(sut);
            mock.SaveAsync(s2);
            Assert.True(sut.StepId != s2.StepId);
            Assert.True(typeof(int) == sut.StepId.GetType());
        }

        [Fact]
        public void Test_Step_Save_Mock()
        {
            var expected = 1;
            mock.SaveAsync<Step>(sut);
            var actual = mock.Step.Count();

            Assert.True(expected <= actual);

        }

        [Fact]
        public void Test_Step_Read_Mock()
        {
            mock.SaveAsync<Step>(sut);
            var expected = sut.StepId;
            var actual = mock.ReadList<Step>(1);
            Assert.Equal(expected, actual.StepId);
        }
    }
}
