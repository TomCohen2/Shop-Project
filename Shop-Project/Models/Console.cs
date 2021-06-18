using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Shop_Project.Models
{
    public class Console 
    {

        public int Id { get; set; }

        [DataType(DataType.ImageUrl)]
        public String Image { get; set; }

       // [NotMapped]
      //  public IFormFile imageFile { get; set; }


        [Required(ErrorMessage = "You must input console name")]
        public String Name { get; set; }

        [Display(Name = "Date Of Release")]
        public DateTime DateOfRelease { get; set; }

        [Required(ErrorMessage = "You must input console price")]
        [DataType(DataType.Currency)]
        public float Price { get; set; }

        public String trailer { get; set; }

        [Required(ErrorMessage = "You must input quantity")]
        [Range(0, 100)]
        public int Quantity { get; set; }

        public String Description { get; set; }


        public List<Game> Games { get; set; }

        public List<Accessory> accessories { get; set; }

    }
}
