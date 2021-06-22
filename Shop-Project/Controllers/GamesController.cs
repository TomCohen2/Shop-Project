﻿using System;
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
        public async Task<IActionResult> Create([Bind("Id,Image,Name,DateOfRelease,Price,trailer,Quantity,Description,ConsoleId,Genre")] Game game, Genre genre)

        {
            if (ModelState.IsValid)
            {

                

                //var existingSkillIds = teacher.skills.Select(m => m.Id);
                //db.Skills.Where(m => model.skillIds.Exclude(existingSkillIds).Contains(m.Id))
                //    .ToList().ForEach(skill => teacher.skills.Add(skill));

                //  var q = game.Genres.Select(m => m.Name);
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

            var game = await _context.Game.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Image,Name,DateOfRelease,Price,trailer,Quantity,Description,ConsoleId")] Game game)
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
    }
}
