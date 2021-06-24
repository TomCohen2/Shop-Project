using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shop_Project.Data;
using Shop_Project.Models;
using Console = Shop_Project.Models.Console;

namespace Shop_Project.Controllers
{
    public class ConsoleVersionsController : Controller
    {
        private readonly Shop_ProjectContext _context;

        public ConsoleVersionsController(Shop_ProjectContext context)
        {
            _context = context;
        }

        // GET: ConsoleVersions
        public async Task<IActionResult> Index()
        {
            var shop_ProjectContext = _context.ConsoleVersion.Include(c => c.Console);
            return View(await shop_ProjectContext.ToListAsync());
        }

        // GET: ConsoleVersions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consoleVersion = await _context.ConsoleVersion
                .Include(c => c.Console)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consoleVersion == null)
            {
                return NotFound();
            }

            return View(consoleVersion);
        }

        // GET: ConsoleVersions/Create
        public IActionResult Create()
        {
            ViewData["ConsoleId"] = new SelectList(_context.Console, nameof(Console.Id), nameof(Console.Name));
            return View();
        }

        // POST: ConsoleVersions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Image,Name,DateOfRelease,Price,trailer,Quantity,Description,ConsoleId")] ConsoleVersion consoleVersion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consoleVersion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConsoleId"] = new SelectList(_context.Console, nameof(Console.Id),nameof(Console.Name), consoleVersion.ConsoleId);
            return View(consoleVersion);
        }

        // GET: ConsoleVersions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consoleVersion = await _context.ConsoleVersion.FindAsync(id);
            if (consoleVersion == null)
            {
                return NotFound();
            }
            ViewData["ConsoleId"] = new SelectList(_context.Console, nameof(Console.Id), nameof(Console.Name), consoleVersion.ConsoleId);
            return View(consoleVersion);
        }

        // POST: ConsoleVersions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Image,Name,DateOfRelease,Price,trailer,Quantity,Description,ConsoleId")] ConsoleVersion consoleVersion)
        {
            if (id != consoleVersion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consoleVersion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsoleVersionExists(consoleVersion.Id))
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
            ViewData["ConsoleId"] = new SelectList(_context.Console, nameof(Console.Id), nameof(Console.Name), consoleVersion.ConsoleId);
            return View(consoleVersion);
        }

        // GET: ConsoleVersions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consoleVersion = await _context.ConsoleVersion
                .Include(c => c.Console)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consoleVersion == null)
            {
                return NotFound();
            }

            return View(consoleVersion);
        }

        // POST: ConsoleVersions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consoleVersion = await _context.ConsoleVersion.FindAsync(id);
            _context.ConsoleVersion.Remove(consoleVersion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsoleVersionExists(int id)
        {
            return _context.ConsoleVersion.Any(e => e.Id == id);
        }
    }
}
