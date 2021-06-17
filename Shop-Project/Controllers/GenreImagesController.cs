using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shop_Project.Data;
using Shop_Project.Models;

namespace Shop_Project.Controllers
{
    public class GenreimageController : Controller
    {
        private readonly Shop_ProjectContext _context;

        public GenreimageController(Shop_ProjectContext context)
        {
            _context = context;
        }

        // GET: Genreimage
        public async Task<IActionResult> Index()
        {
            var shop_ProjectContext = _context.GenreImage.Include(g => g.Genre);
            return View(await shop_ProjectContext.ToListAsync());
        }

        // GET: Genreimage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genreImage = await _context.GenreImage
                .Include(g => g.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (genreImage == null)
            {
                return NotFound();
            }

            return View(genreImage);
        }

        // GET: Genreimage/Create
        public IActionResult Create()
        {
            ViewData["GenreId"] = new SelectList(_context.Genre, nameof(Genre.Id), nameof(Genre.Name));
            return View();
        }

        // POST: Genreimage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Image,GenreId")] GenreImage genreImage)
        {
            if (ModelState.IsValid)
            {


                _context.Add(genreImage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "Id", genreImage.GenreId);
            return View(genreImage);
        }

        // GET: Genreimage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genreImage = await _context.GenreImage.FindAsync(id);
            if (genreImage == null)
            {
                return NotFound();
            }
            ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "Id", genreImage.GenreId);
            return View(genreImage);
        }

        // POST: Genreimage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Image,GenreId")] GenreImage genreImage)
        {
            if (id != genreImage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(genreImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenreImageExists(genreImage.Id))
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
            ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "Id", genreImage.GenreId);
            return View(genreImage);
        }

        // GET: Genreimage/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genreImage = await _context.GenreImage
                .Include(g => g.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (genreImage == null)
            {
                return NotFound();
            }

            return View(genreImage);
        }

        // POST: Genreimage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var genreImage = await _context.GenreImage.FindAsync(id);
            _context.GenreImage.Remove(genreImage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GenreImageExists(int id)
        {
            return _context.GenreImage.Any(e => e.Id == id);
        }
    }
}
