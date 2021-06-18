using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shop_Project.Data;
using Shop_Project.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Console = Shop_Project.Models.Console;

namespace Shop_Project.Controllers
{
    public class ConsolesController : Controller
    {
        private readonly Shop_ProjectContext _context;

        public ConsolesController(Shop_ProjectContext context)
        {
            _context = context;

        }

        // GET: Consoles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Console.ToListAsync());
        }

        // GET: Consoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var console = await _context.Console
                .FirstOrDefaultAsync(m => m.Id == id);
            if (console == null)
            {
                return NotFound();
            }

            return View(console);
        }

        // GET: Consoles/Create
        public IActionResult Create()
        {
            ViewData["Games"] = new SelectList(_context.Game, "Id", "Name");
            return View();
        }

        // POST: Consoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Image,Name,DateOfRelease,Price,trailer,Quantity,Description")] Console console)
        {
            if (ModelState.IsValid)
            {

                _context.Add(console);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Games"] = new SelectList(_context.Game, "Id", "Name");
            return View(console);
        }


        public async Task<IActionResult> ConsolePage(int? id)
        {
            IEnumerable<GroupGameConsole> sorted =
                              from a in _context.Game
                              group a by new
                              {
                                  a.Name,
                                  a.Price,
                                  a.ConsoleId,

                              } into k select new GroupGameConsole
                              {
                                  Name = k.Key.Name,
                                  Price = k.Key.Price,
                                  ConsoleId = k.Key.ConsoleId,
                              };

            return View(sorted.ToList());

        }
        public async Task<IActionResult> Search(string search)
        {
            return View("index", await _context.Console.Where(a => a.Name.Contains(search)).ToListAsync());
        }



        // GET: Consoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var console = await _context.Console.FindAsync(id);
            if (console == null)
            {
                return NotFound();
            }
            return View(console);
        }

        // POST: Consoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Image,Name,DateOfRelease,Price,trailer,Quantity,Description")] Console console)
        {
            if (id != console.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(console);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsoleExists(console.Id))
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
            return View(console);
        }

        // GET: Consoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var console = await _context.Console
                .FirstOrDefaultAsync(m => m.Id == id);
            if (console == null)
            {
                return NotFound();
            }

            return View(console);
        }

        // POST: Consoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var console = await _context.Console.FindAsync(id);
            _context.Console.Remove(console);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsoleExists(int id)
        {
            return _context.Console.Any(e => e.Id == id);
        }
    }
}
