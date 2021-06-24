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

        [Required(ErrorMessage = "You must input console name")]
        public String Name { get; set; }

        public List<Game> Games { get; set; }

        public List<ConsoleVersion> ConsoleVersions { get; set; }

        public List<Accessory> accessories { get; set; }

    }
}
