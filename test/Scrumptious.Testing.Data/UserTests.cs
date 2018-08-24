using Scrumptious.Data;
using Scrumptious.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Scrumptious.Testing.Data
{
   public class UserTests
    {
        private User sut;
        private readonly MockContext mock = new MockContext();
        private readonly EntityData entity = new EntityData();
        private readonly scrumptiousdbContext ctx = new scrumptiousdbContext();
        


        public UserTests()
        {
            sut = new User()
            {
                FirstName = "Barney",
                LastName = "TheDinosaur",
                Email = "ILoveYou@Gmail.com",
                Role = "TheBest",
                Task = null
            };
        }

        [Fact]
        public void Test_UserId()
        {
            User u1 = new User();
            mock.SaveAsync(sut);
            mock.SaveAsync(u1);
            Assert.True(sut.UserId != u1.UserId);
            Assert.True(typeof(int) == sut.UserId.GetType());
        }

        [Fact]
        public void Test_User_Save_Mock()
        {
            var expected = 1;
            mock.SaveAsync<User>(sut);
            var actual = mock.User.Count();

            Assert.True(expected <= actual);

        }

        [Fact]
        public void Test_User_Read_Mock()
        {
            mock.SaveAsync<User>(sut);
            var expected = sut.UserId;
            var actual = mock.ReadList<User>(1);
            Assert.Equal(expected, actual.UserId);
        }

        [Fact]
        public void Test_UserAddProject()
        {
            var s = sut.CreateProject("some name", "some requirements", "some desc");

            sut.AddProject(s);

            Assert.NotNull(mock.ReadList<Project>(1));

        }
    }
}
