using Scrumptious.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Scrumptious.Testing.Library
{
    public class UserTests
    {
        public UserTests()
        {
            sut = new User()
            {
                FirstName = "kurt",
                LastName = "pedersen",
                Email = "kurt@.com",
                Role = "assistant to coffe boi"
            };
        }

        public User sut;

        #region Properties
        [Fact]
        public void Test_UserName() //checks for first and last name to contain content 
        {
            Assert.False(string.IsNullOrEmpty(sut.FirstName));
            Assert.False(string.IsNullOrEmpty(sut.LastName));
        }

        [Fact]
        public void Test_UserEmail() //checks to see if a user has an email
        {
            Assert.False(string.IsNullOrEmpty(sut.Email));
        }

        [Fact]
        public void Test_UserTask() //checks to see if a user has a task that is not null
        {
            Assert.True(sut.Task != null);
        }

        [Fact]
        public void Test_UserRole() //checks to see if a user has a role
        {
            Assert.False(string.IsNullOrEmpty(sut.Role));
        }
        #endregion


        #region Methods
        [Fact]
        public void Test_UserAddProject() //checks if when a user adds a project, that it is saved to the database
        {
            Project proj = new Project();

            sut.AddProject(proj);

            // Assert.True(data.ReadProject(proj).Count > 0);
        }

        [Fact]
        public void Test_UserCompleteTask()
        {
            var T = new Task();

            sut.CompleteTask(T);

            Assert.True(T.Completed);
        }

        [Fact]
        public void Test_UserViewTask()  //checks if upon request a list of task is returned
        {
            var RTList = sut.RequestTask();
            Assert.True(RTList.GetType() == typeof(List<Task>));
        }

        [Fact]
        public void Test_UserRequestTask() //adds an external task to a user
        {
            var task = new Task();
            sut.RequestTask(task);
            Assert.True(sut.Task != null);
        }
        #endregion
    }
}
