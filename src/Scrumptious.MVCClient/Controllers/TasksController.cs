using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Scrumptious.Data.Models;

namespace Scrumptious.MVCClient.Controllers
{
    public class TasksController : Controller
    {
        private readonly scrumptiousdbContext _context;

        public TasksController(scrumptiousdbContext context)
        {
            _context = context;
        }

        // GET: Tasks
        public async Task<IActionResult> Index()
        {
            var scrumptiousdbContext = _context.Task.Include(t => t.FkBacklog).Include(t => t.FkUser);
            return View(await scrumptiousdbContext.ToListAsync());
        }

        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.Task
                .Include(t => t.FkBacklog)
                .Include(t => t.FkUser)
                .SingleOrDefaultAsync(m => m.TaskId == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // GET: Tasks/Create
        public IActionResult Create()
        {
            ViewData["FkBacklogId"] = new SelectList(_context.Backlog, "BacklogId", "BacklogId");
            ViewData["FkUserId"] = new SelectList(_context.User, "UserId", "Email");
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaskId,FkUserId,FkBacklogId,Name,TaskDescription,Requirements,Completed")] Data.Models.Task task)
        {
            if (ModelState.IsValid)
            {
                _context.Add(task);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkBacklogId"] = new SelectList(_context.Backlog, "BacklogId", "BacklogId", task.FkBacklogId);
            ViewData["FkUserId"] = new SelectList(_context.User, "UserId", "Email", task.FkUserId);
            return View(task);
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.Task.SingleOrDefaultAsync(m => m.TaskId == id);
            if (task == null)
            {
                return NotFound();
            }
            ViewData["FkBacklogId"] = new SelectList(_context.Backlog, "BacklogId", "BacklogId", task.FkBacklogId);
            ViewData["FkUserId"] = new SelectList(_context.User, "UserId", "Email", task.FkUserId);
            return View(task);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaskId,FkUserId,FkBacklogId,Name,TaskDescription,Requirements,Completed")] Data.Models.Task task)
        {
            if (id != task.TaskId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(task);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskExists(task.TaskId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkBacklogId"] = new SelectList(_context.Backlog, "BacklogId", "BacklogId", task.FkBacklogId);
            ViewData["FkUserId"] = new SelectList(_context.User, "UserId", "Email", task.FkUserId);
            return View(task);
        }

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.Task
                .Include(t => t.FkBacklog)
                .Include(t => t.FkUser)
                .SingleOrDefaultAsync(m => m.TaskId == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var task = await _context.Task.SingleOrDefaultAsync(m => m.TaskId == id);
            _context.Task.Remove(task);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskExists(int id)
        {
            return _context.Task.Any(e => e.TaskId == id);
        }
    }
}
