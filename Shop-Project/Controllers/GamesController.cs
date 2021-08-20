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
            var shop_ProjectContext = _context.Game.Include(g => g.Console).Include(g => g.Genres);
            return View(await shop_ProjectContext.ToListAsync());
        }


        // GET: Games/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game
                .Include(g => g.Console).Include(g=>g.Genres)
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
            ViewData["Genres"] = new SelectList(_context.Genre, nameof(Genre.Id), nameof(Genre.Name));
            ViewData["ConsoleId"] = new SelectList(_context.Console, nameof(Console.Id), nameof(Console.Name));
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Image,Name,DateOfRelease,Price,trailer,Quantity,Description,ConsoleId,Genre")] Game game, int[] Genres)

        {
            if (ModelState.IsValid)
            {

                game.Genres = new List<Genre>();
                game.Genres.AddRange(_context.Genre.Where(x => Genres.Contains(x.Id)));
                _context.Add(game);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Genres"] = new SelectList(_context.Genre, nameof(Genre.Id), nameof(Genre.Name), game.Genres);
            ViewData["ConsoleId"] = new SelectList(_context.Console, nameof(Console.Id), nameof(Console.Name), game.ConsoleId);
            return View(game);
        }

        // GET: Games/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           // var game = await _context.Game.FindAsync(id);
            var game = await _context.Game
                .Include(g => g.Console).Include(g => g.Genres)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (game == null)
            {
                return NotFound();
            }
            ViewData["Genres"] = new SelectList(_context.Genre, nameof(Genre.Id), nameof(Genre.Name));
            ViewData["ConsoleId"] = new SelectList(_context.Console, nameof(Console.Id), nameof(Console.Name));
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Image,Name,DateOfRelease,Price,trailer,Quantity,Description,ConsoleId,Genres")] Game game, int[] Genres)
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
                    
                    
                    var g = await _context.Game
                          .Include(g => g.Console).Include(g => g.Genres)
                          .FirstOrDefaultAsync(m => m.Id == id);
                      int size = g.Genres.Count();
                    g.Genres.RemoveRange(0, size);
                    g.Genres.AddRange(_context.Genre.Where(x => Genres.Contains(x.Id)));
                    
                /*    List<Genre> genreList = new List<Genre>();
                    foreach(int a in Genres)
                    {
                        foreach(Genre b in _context.Genre)
                        {
                            if(b.Id == a)
                                genreList.Add(b);
                        }
                    }
                    game.Genres = genreList;*/
                    _context.Update(g);
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
            ViewData["Genres"] = new SelectList(_context.Genre, nameof(Genre.Id), nameof(Genre.Name), game.Genres);
            ViewData["ConsoleId"] = new SelectList(_context.Console, nameof(Console.Id), nameof(Console.Name), game.ConsoleId);


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
                .Include(g => g.Console)
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



        public IActionResult HomePage()
        {

            List<Game> games = new List<Game>();
            foreach (Game g in _context.Game)
            {
                games.Add(g);
            }
            List<Models.ConsoleVersion> consoles = new List<Models.ConsoleVersion>();
            foreach (Models.ConsoleVersion c in _context.ConsoleVersion)
            {
                consoles.Add(c);
            }

            List<Genre> genres = new List<Genre>();
            foreach (Genre g in _context.Genre)
            {
                genres.Add(g);
            }

            List<Models.Console> consolesName = new List<Models.Console>();
            foreach (Models.Console c in _context.Console)
            {
                consolesName.Add(c);
            }

            ProductConsole productConsole = new ProductConsole
            {
                Games = games,
                Consoles = consoles,
                Genres = genres,
                ConsolesName = consolesName
            };


            IEnumerable<ProductConsole> r = from a in _context.Game
                                            select new ProductConsole
                                            {
                                                Games = productConsole.Games,
                                                Consoles = productConsole.Consoles,
                                                ConsolesName = productConsole.ConsolesName,
                                                Genres = productConsole.Genres
                                            };

            return View(r);
        }


        [HttpPost]
        public IActionResult HomePage(int id, String[] All, String[] Games, String[] Console, String[] Genre)
        {

            List<Game> games = new List<Game>();
            foreach (var g in _context.Game.Include(g => g.Console).Include(g=> g.Genres))
            {
                games.Add(g);
            }

            List<Models.ConsoleVersion> consoles = new List<Models.ConsoleVersion>();
            foreach (Models.ConsoleVersion c in _context.ConsoleVersion)
            {
                consoles.Add(c);
            }

            List<Genre> genres = new List<Genre>();
            foreach (Genre g in _context.Genre)
            {
                genres.Add(g);
            }

            List<Models.Console> consolesName = new List<Models.Console>();
            foreach (Models.Console c in _context.Console)
            {
                consolesName.Add(c);
            }
            ProductConsole productConsole = new ProductConsole();
            productConsole.ConsolesName = consolesName;
            productConsole.Genres = genres;
            productConsole.Consoles = new List<ConsoleVersion>();
            productConsole.Games = new List<Game>();

            if (All.Count() > 0)
            {
                productConsole.Consoles = consoles;
                productConsole.Games = games;

            }

            if (Games.Count() > 0)
            {
                var genre1 = _context.Genre.Where(a => a.Name.Contains("Accessories")).FirstOrDefault();
                productConsole.Games.AddRange(_context.Game.Where(a => !a.Genres.Contains(genre1)));
            }

            if (Genre.Count() > 0)
            {
                List<Genre> genre1 = new List<Genre>();
                foreach (String str in Genre)
                {
                    genre1.Add(_context.Genre.Where(a => a.Name.Contains(str)).FirstOrDefault());
                }
                foreach (Game a in games)
                {
                    foreach (Genre b in genre1)
                    {
                        if (a.Genres.Contains(b))
                        {
                            if (!productConsole.Games.Contains(a))
                            {
                                productConsole.Games.Add(a);
                            }
                        }
                    }
                }
            }
            if (Console.Count() > 0)
            {
                List<Models.Console> console1 = new List<Models.Console>();
                foreach (String str in Console)
                {
                    console1.Add(_context.Console.Where(a => a.Name.Contains(str)).FirstOrDefault());
                }
                foreach (Game a in games)
                {
                    foreach (Models.Console b in console1)
                    {
                        if (a.Console.Name.Contains(b.Name))
                        {
                            productConsole.Games.Add(a);
                        }
                    }
                }
                foreach (ConsoleVersion a in consoles)
                {
                    foreach (Models.Console b in console1)
                    {
                        if (a.Console.Name.Contains(b.Name))
                        {
                            if (!productConsole.Consoles.Contains(a))
                            {
                                productConsole.Consoles.Add(a);
                            }
                        }
                    }
                }
            }

            IEnumerable<ProductConsole> r = from a in _context.Game
                                            select new ProductConsole
                                            {
                                                Games = productConsole.Games,
                                                Consoles = productConsole.Consoles,
                                                ConsolesName = productConsole.ConsolesName,
                                                Genres = productConsole.Genres
                                            };

            return View(r);
        }


    }
}
