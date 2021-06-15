using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop_Project.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Project.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {

        private readonly Shop_ProjectContext _context;
        public MenuViewComponent(Shop_ProjectContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _context.Console.ToListAsync();
            return View(items);
        }
    }
}
