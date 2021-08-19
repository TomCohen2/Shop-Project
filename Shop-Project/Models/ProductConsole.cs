using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Project.Models
{
    public class ProductConsole
    {
        public int Id { get; set; }
        public List<Game> Games { get; set; }
        public List<ConsoleVersion> Consoles { get; set; }
    }
}
