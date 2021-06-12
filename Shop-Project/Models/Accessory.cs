using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Project.Models
{
    public class Accessory
    {

        public int Id { get; set; }

        [DataType(DataType.ImageUrl)]
        public String Image { get; set; }

        [Required(ErrorMessage = "You must input accessory name")]
        public String Name { get; set; }

        [Display(Name = "Date Of Release")]
        public DateTime DateOfRelease { get; set; }

        [Required(ErrorMessage = "You must input accessory price")]
        [DataType(DataType.Currency)]
        public float Price { get; set; }

        public String trailer { get; set; }

        [Required(ErrorMessage = "You must input quantity")]
        [Range(0, 100)]
        public int Quantity { get; set; }

        public String Description { get; set; }

        public List<Console> consoles { get; set; }


    }
}
