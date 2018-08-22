using Scrumptious.Data;
using Scrumptious.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Scrumptious.Testing.Data
{
    public class TaskTests
    {
        private Task sut;
        private readonly MockContext mock = new MockContext();
        private readonly EntityData entity = new EntityData();
        private readonly scrumptiousdbContext ctx = new scrumptiousdbContext();

        public TaskTests()
        {
            sut = new Task()
            {
                Name = "RocketShip_Construction",
                TaskDescription = "going to the sun boys",
                Requirements = "need to get tan",
                Completed = false,

            };
        }

        [Fact]
        public void Test_StepId()
        {
            Task t2 = new Task();
            mock.SaveAsync(sut);
            mock.SaveAsync(t2);
            Assert.True(sut.TaskId != t2.TaskId);
            Assert.True(typeof(int) == sut.TaskId.GetType());
        }

        [Fact]
        public void Test_Step_Save_Mock()
        {
            var expected = 1;
            mock.SaveAsync<Task>(sut);
            var actual = mock.Task.Count();

            Assert.True(expected <= actual);

        }

        [Fact]
        public void Test_Task_Read_Mock()
        {
            mock.SaveAsync<Task>(sut);
            var expected = sut.TaskId;
            var actual = mock.ReadList<Task>(1);
            Assert.Equal(expected, actual.TaskId);
        }

    }
}
