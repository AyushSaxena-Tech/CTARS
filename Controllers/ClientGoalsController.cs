using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCApplication.Data;
using MVCApplication.Models;

namespace MVCApplication.Controllers
{
    public class ClientGoalsController : Controller
    {
        private readonly ClientGoalsContext _context;

        public ClientGoalsController(ClientGoalsContext context)
        {
            _context = context;
        }

        // GET: ClientGoals
        public async Task<IActionResult> Index()
        {
            var clientGoalsContext = _context.ClientGoals.Include(c => c.Client);
            return View(await clientGoalsContext.ToListAsync());
        }

        // GET: ClientGoals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientGoal = await _context.ClientGoals
                .Include(c => c.Client)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (clientGoal == null)
            {
                return NotFound();
            }

            return View(clientGoal);
        }

        // GET: ClientGoals/Create
        public IActionResult Create()
        {
            ViewData["ClientID"] = new SelectList(_context.Clients, "ID", "FullName");
            return View();
        }

        // POST: ClientGoals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ClientID,Title,Details,DateCreated")] ClientGoal clientGoal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientGoal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientID"] = new SelectList(_context.Clients, "ID", "FullName", clientGoal.ClientID);
            return View(clientGoal);
        }

        // GET: ClientGoals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientGoal = await _context.ClientGoals.FindAsync(id);
            if (clientGoal == null)
            {
                return NotFound();
            }
            ViewData["ClientID"] = new SelectList(_context.Clients, "ID", "FullName", clientGoal.ClientID);
            return View(clientGoal);
        }

        // POST: ClientGoals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ClientID,Title,Details,DateCreated")] ClientGoal clientGoal)
        {
            if (id != clientGoal.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientGoal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientGoalExists(clientGoal.ID))
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
            ViewData["ClientID"] = new SelectList(_context.Clients, "ID", "FullName", clientGoal.ClientID);
            return View(clientGoal);
        }

        // GET: ClientGoals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientGoal = await _context.ClientGoals
                .Include(c => c.Client)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (clientGoal == null)
            {
                return NotFound();
            }

            return View(clientGoal);
        }

        // POST: ClientGoals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientGoal = await _context.ClientGoals.FindAsync(id);
            _context.ClientGoals.Remove(clientGoal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientGoalExists(int id)
        {
            return _context.ClientGoals.Any(e => e.ID == id);
        }
    }
}
