using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ZenithSociety2.Models
{
    public class ZenithContext : DbContext
    {
        

        public DbSet<Activity> Activity { get; set; }
        public DbSet<Event> Event { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-ZenithSociety2-a3814d17-5b3a-40b1-aa90-c589865b1a36;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
