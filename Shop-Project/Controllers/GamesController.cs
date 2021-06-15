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
    public class GamesController : Controller
    {
        private readonly Shop_ProjectContext _context;

        public GamesController(Shop_ProjectContext context)
        {
            _context = context;
        }

        // GET: Games
        public async Task<IActionResult> Index()
        {
            return View(await _context.Game.ToListAsync());
        }

        //public async Task<IActionResult> Search(string query)
        //{

        //    var q = from a in _context.Game.Include(a => a.Name)
        //            where a.Name.Contains(query)
        //            orderby a.Name descending
        //            select a;

        //    var shopProject = _context.Game.Include(q => q.Name);

        //    return View("index",await _context.Game.ToListAsync());
        //    //return View("index",await shopProject.ToListAsync());
        //}

        public async Task<IActionResult> Search(string search)
        {
            return View("index", await _context.Game.Where(a => a.Name.Contains(search)).ToListAsync());
        }

        // GET: Games/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // GET: Games/Create
        public IActionResult Create()
        {
     // ViewData["articles"] = new SelectList(_context.Article.Where(x => x.CategoryId == null), nameof(Article.Id), nameof(Article.Title));
            ViewData["genres"] = new SelectList( _context.Genre,nameof(Genre.Id), nameof(Genre.Name));
            ViewData["consoles"] = new SelectList(_context.Console, nameof(Console.Id), nameof(Console.Name));

            //    ViewData["genres"] = new SelectList(_context.Genre.Where())
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Image,Name,DateOfRelease,Price,trailer,Quantity,Description")] Game game,int[] Genres,int[] Consoles)
        {
            if (ModelState.IsValid)
            {
                game.Genres = new List<Genre>();
                game.Consoles = new List<Console>();
                game.Genres.AddRange(_context.Genre.Where(x => Genres.Contains(x.Id)));
                game.Consoles.AddRange(_context.Console.Where(x => Consoles.Contains(x.Id)));
                _context.Add(game);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(game);
        }

        // GET: Games/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Image,Name,DateOfRelease,Price,trailer,Quantity,Description")] Game game)
        {
            if (id != game.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(game);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(game.Id))
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
            return View(game);
        }

        // GET: Games/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var game = await _context.Game.FindAsync(id);
            _context.Game.Remove(game);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameExists(int id)
        {
            return _context.Game.Any(e => e.Id == id);
        }
    }
}
