using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Project.Models
{
    public class GroupGameGenre
    {
        public List<Game> Games { get; set; }
        public List<Genre> Genres { get; set; }
        public int ConsoleId { get; set; }
    }
}
