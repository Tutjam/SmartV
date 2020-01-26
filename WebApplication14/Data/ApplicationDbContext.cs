using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartHome.Models;

namespace WebApplication14.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Room> Room { get; set; }
        public DbSet<SmartHome.Models.Sensor> Sensor { get; set; }
        public DbSet<SmartHome.Models.Image> Image { get; set; }

      
    }
}
