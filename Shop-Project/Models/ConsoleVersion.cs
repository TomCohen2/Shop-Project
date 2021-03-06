using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Project.Models
{
    public class ConsoleVersion
    {
        public int Id { get; set; }

        [DataType(DataType.ImageUrl)]
        public String Image { get; set; }

        //   [Required(ErrorMessage = "You must input game name")]
        public String Name { get; set; }

        //     [Display(Name = "Date Of Release")]
        public DateTime DateOfRelease { get; set; }

        //     [Required(ErrorMessage = "You must input game price")]
        [DataType(DataType.Currency)] 
        public float Price { get; set; }




        public String trailer { get; set; }

        //     [Required(ErrorMessage = "You must input quantity")]
        [Range(0, 100)]
        [Display(Name = "Left in stock")]
        public int Quantity { get; set; }


        public String Description { get; set; }


        public int ConsoleId { get; set; }

        public virtual Console Console { get; set; }

    }
}
