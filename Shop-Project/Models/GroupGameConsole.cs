using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Project.Models
{
    public class GroupGameConsole
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.ImageUrl)]
        public String Image { get; set; }

      
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        public float Price { get; set; }
        public List<Genre> Genres { get; set; }

        public int ConsoleId { get; set; }


    }
}
