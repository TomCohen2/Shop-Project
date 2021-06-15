using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Project.Models
{
    public class GenreImage
    {
        public int Id { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }


        [Display(Name ="Genre")]
        public int GenreId { get; set; }

        public Genre Genre { get; set; }

    }
}
