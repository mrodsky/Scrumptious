using Scrumptious.Data;
using Scrumptious.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Scrumptious.Testing.Data
{
    public class BacklogTests
    {

        private readonly MockContext mock = new MockContext();
        private readonly EntityData entity = new EntityData();
        private readonly scrumptiousdbContext ctx = new scrumptiousdbContext();

        private Backlog sut;

        public BacklogTests()
        {
            sut = new Backlog();
            sut.AddTask();
        }


        [Fact]
        public void Test_BacklogId()
        {
            Backlog bl2 = new Backlog();
            mock.SaveAsync(sut);
            mock.SaveAsync(bl2);
            Assert.True(sut.BacklogId != bl2.BacklogId);
            Assert.True(typeof(int) == sut.BacklogId.GetType());
        }

        [Fact]
        public void Test_Backlog_Save_Mock()
        {
            var expected = 1;
            mock.SaveAsync<Backlog>(sut);
            var actual = mock.Backlog.Count();

            Assert.True(expected <= actual);

        }

        [Fact]
        public void Test_Backlog_Read_Mock()
        {
            mock.SaveAsync<Backlog>(sut);

            var expected = sut.BacklogId;

            var actual = mock.ReadList<Backlog>(1);

            Assert.Equal(expected, actual.BacklogId);
        }


    }
}
