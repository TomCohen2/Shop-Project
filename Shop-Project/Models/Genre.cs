using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Project.Models
{
    public class Genre
    {
        [Display(Name ="Name")]
        public int Id { get; set; }

        public String Name { get; set; }


        public List<Game> games { set; get; }

        public GenreImage GenreImage { get; set; }

    }
}
