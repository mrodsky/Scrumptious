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
                await context.SaveChangesAsync();
            }
        }
        public async Task<List<T>> ReadListAsync<T>() where T : class
        {
            if (typeof(T) == typeof(Project))
            {
                return await Mock.Project.ToListAsync() as List<T>;
            }
            else if (typeof(T) == typeof(Backlog))
            {
                return await Mock.Backlog.ToListAsync() as List<T>;
            }
            else if (typeof(T) == typeof(Sprint))
            {
                return await Mock.Sprint.ToListAsync() as List<T>;
            }
            if (typeof(T) == typeof(Step))
            {
                return await Mock.Step.ToListAsync() as List<T>;
            }
            else if (typeof(T) == typeof(Task))
            {
                return await Mock.Task.ToListAsync() as List<T>;
            }
            else if (typeof(T) == typeof(User))
            {
                return await Mock.User.ToListAsync() as List<T>;
            }
            else
                return default(List<T>);
        }
    }
}
