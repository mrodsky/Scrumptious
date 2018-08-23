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
    public class SprintsController : Controller
    {
        private readonly scrumptiousdbContext _context;

        public SprintsController(scrumptiousdbContext context)
        {
            _context = context;
        }

        // GET: Sprints
        public async Task<IActionResult> Index()
        {
            var scrumptiousdbContext = _context.Sprint.Include(s => s.FkProject);
            return View(await scrumptiousdbContext.ToListAsync());
        }

        // GET: Sprints/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sprint = await _context.Sprint
                .Include(s => s.FkProject)
                .SingleOrDefaultAsync(m => m.SprintId == id);
            if (sprint == null)
            {
                return NotFound();
            }

            return View(sprint);
        }

        // GET: Sprints/Create
        public IActionResult Create()
        {
            ViewData["FkProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectDescription");
            return View();
        }

        // POST: Sprints/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SprintId,Completed,FkProjectId,Name,StartDate,EndDate,SprintDescription")] Sprint sprint)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sprint);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectDescription", sprint.FkProjectId);
            return View(sprint);
        }

        // GET: Sprints/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sprint = await _context.Sprint.SingleOrDefaultAsync(m => m.SprintId == id);
            if (sprint == null)
            {
                return NotFound();
            }
            ViewData["FkProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectDescription", sprint.FkProjectId);
            return View(sprint);
        }

        // POST: Sprints/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SprintId,Completed,FkProjectId,Name,StartDate,EndDate,SprintDescription")] Sprint sprint)
        {
            if (id != sprint.SprintId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sprint);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SprintExists(sprint.SprintId))
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
            ViewData["FkProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectDescription", sprint.FkProjectId);
            return View(sprint);
        }

        // GET: Sprints/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sprint = await _context.Sprint
                .Include(s => s.FkProject)
                .SingleOrDefaultAsync(m => m.SprintId == id);
            if (sprint == null)
            {
                return NotFound();
            }

            return View(sprint);
        }

        // POST: Sprints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sprint = await _context.Sprint.SingleOrDefaultAsync(m => m.SprintId == id);
            _context.Sprint.Remove(sprint);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SprintExists(int id)
        {
            return _context.Sprint.Any(e => e.SprintId == id);
        }
    }
}
