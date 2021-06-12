using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Project.Models
{
    public class Genre
    {

        public int Id { get; set; }

        public String Name { get; set; }

        public List<Game> games { set; get; }

        public GenreImage GenreImage { get; set; }

    }
}
