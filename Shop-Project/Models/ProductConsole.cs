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
        public List<Genre> Genres { get; set; }
        public List<Console> ConsolesName { get; set; }
    }
}
