using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public DbSet<SensorData> SensorData { get; set; }
        public DbSet<Image> image { get; set; }
       
    }
}
