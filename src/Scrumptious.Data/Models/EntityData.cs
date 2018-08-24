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
                context.Backlog.Add(a as Backlog);
                await context.SaveChangesAsync();
            }
            else if (typeof(T) == typeof(Project))
            {
                context.Project.Add(a as Project);
                await context.SaveChangesAsync();

            }
            else if (typeof(T) == typeof(Sprint))
            {

                context.Sprint.Add(a as Sprint);
                await context.SaveChangesAsync();
            }

            else if (typeof(T) == typeof(Step))
            {

                context.Step.Add(a as Step);
                await context.SaveChangesAsync();

            }
            else if (typeof(T) == typeof(Task))
            {

                context.Task.Add(a as Task);
                await context.SaveChangesAsync();
            }
            else if (typeof(T) == typeof(User))
            {

                context.User.Add(a as User);
                await context.SaveChangesAsync();

            }

        }

        public T ReadList<T>(int id) where T : class
        {
            if (typeof(T) == typeof(Project))
            {

                return context.Project.SingleOrDefault(u => u.ProjectId == id) as T;

            }
            else if (typeof(T) == typeof(Backlog))
            {
                return context.Backlog.SingleOrDefault(u => u.BacklogId == id) as T;
            }
            else if (typeof(T) == typeof(Sprint))
            {
                return context.Sprint.SingleOrDefault(u => u.SprintId == id) as T;
            }
            if (typeof(T) == typeof(Step))
            {
                return context.Step.SingleOrDefault(u => u.StepId == id) as T;
            }
            else if (typeof(T) == typeof(Task))
            {
                return context.Task.SingleOrDefault(u => u.TaskId == id) as T;
            }
            else if (typeof(T) == typeof(User))
            {
                return context.User.SingleOrDefault(u => u.UserId == id) as T;
            }
            else
                return default(T);
        }

        public T ReadAll<T>() where T : class
        {
            if (typeof(T) == typeof(Project))
            {
                return context.Project.ToList() as T;
            }
            else if (typeof(T) == typeof(Backlog))
            {
                return context.Backlog.ToList() as T;
            }
            else if (typeof(T) == typeof(Sprint))
            {
                return context.Sprint.ToList() as T;
            }
            if (typeof(T) == typeof(Step))
            {
                return context.Step.ToList() as T;
            }
            else if (typeof(T) == typeof(Task))
            {
                return context.Task.ToList() as T;
            }
            else if (typeof(T) == typeof(User))
            {
                return context.User.ToList() as T;
            }
            else
                return default(T);
        }

    }
}
