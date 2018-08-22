using Scrumptious.Data;
using Scrumptious.Data.Models;
using Xunit;

namespace Scrumptious.Testing.Data
{
   public class UserTests
    {
        private readonly MockContext mock = new MockContext();
        private readonly EntityData entity = new EntityData();
        private readonly scrumptiousdbContext ctx = new scrumptiousdbContext();
        private User sut = new User();

        [Fact]
        public void Test_UserAddProject()
        {
            var s = sut.CreateProject("some name", "some requirements", "some desc");

            sut.AddProject(s);

            Assert.NotNull(mock.ReadList<Project>(1));

        }
    }
}
