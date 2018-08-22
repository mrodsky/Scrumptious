using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrumptious.Data.Models
{
    public class EntityData
    {
        private static MockContext Mock = new MockContext();

        private static scrumptiousdbContext context = new scrumptiousdbContext();

        public EntityData() { }


        public async void SaveAsync<T>(T a) where T : class
        {
            if (typeof(T) == typeof(Backlog))
            {
                Mock.Backlog.Add(a as Backlog);
                await Mock.SaveChangesAsync();
            }
            else if (typeof(T) == typeof(Project))
            {
                Mock.Project.Add(a as Project);
                await Mock.SaveChangesAsync();

            }
            else if (typeof(T) == typeof(Sprint))
            {

                Mock.Sprint.Add(a as Sprint);
                await Mock.SaveChangesAsync();
            }

            else if (typeof(T) == typeof(Step))
            {

                Mock.Step.Add(a as Step);
                await Mock.SaveChangesAsync();

            }
            else if (typeof(T) == typeof(Task))
            {

                Mock.Task.Add(a as Task);
                await Mock.SaveChangesAsync();
            }
            else if (typeof(T) == typeof(User))
            {

                Mock.User.Add(a as User);
                await Mock.SaveChangesAsync();

            }

        }

        public T ReadList<T>(int id) where T : class
        {
            if (typeof(T) == typeof(Project))
            {

                return Mock.Project.SingleOrDefault(u => u.ProjectId == id) as T;

            }
            else if (typeof(T) == typeof(Backlog))
            {
                return Mock.Backlog.SingleOrDefault(u => u.BacklogId == id) as T;
            }
            else if (typeof(T) == typeof(Sprint))
            {
                return Mock.Sprint.SingleOrDefault(u => u.SprintId == id) as T;
            }
            if (typeof(T) == typeof(Step))
            {
                return Mock.Step.SingleOrDefault(u => u.StepId == id) as T;
            }
            else if (typeof(T) == typeof(Task))
            {
                return Mock.Task.SingleOrDefault(u => u.TaskId == id) as T;
            }
            else if (typeof(T) == typeof(User))
            {
                return Mock.User.SingleOrDefault(u => u.UserId == id) as T;
            }
            else
                return default(T);
        }
    }
}
