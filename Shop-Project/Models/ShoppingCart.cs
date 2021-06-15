using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Project.Models
{
    public class ShoppingCart
    {

        public int Id { get; set; }

        public int TotalAmount { get; set; }

        public List<Accessory> accessoriesInCart { get; set; }

        public List<Game> gamesInCart { get; set; }

        public List<Console> consolesInCart { get; set; }

        
    }
}
