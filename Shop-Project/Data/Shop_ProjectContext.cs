using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop_Project.Models;

namespace Shop_Project.Data
{
    public class Shop_ProjectContext : DbContext
    {
        public Shop_ProjectContext (DbContextOptions<Shop_ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Shop_Project.Models.Accessory> Accessory { get; set; }

        public DbSet<Shop_Project.Models.Console> Console { get; set; }

        public DbSet<Shop_Project.Models.Game> Game { get; set; }

        public DbSet<Shop_Project.Models.Genre> Genre { get; set; }

        public DbSet<Shop_Project.Models.GenreImage> GenreImage { get; set; }

        public DbSet<Shop_Project.Models.User> User { get; set; }

        public DbSet<Shop_Project.Models.ConsoleVersion> ConsoleVersion { get; set; }


    }
}
