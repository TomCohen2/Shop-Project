using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Project.Models
{
    public class GroupGameConsole
    {



        [DataType(DataType.ImageUrl)]
        public String Image { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

       public List<Genre> Genres { get; set; }


    }
}
