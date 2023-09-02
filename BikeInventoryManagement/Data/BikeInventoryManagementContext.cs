using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BikeInventoryManagement.Models;

namespace BikeInventoryManagement.Data
{
    public class BikeInventoryManagementContext : DbContext
    {
        public BikeInventoryManagementContext (DbContextOptions<BikeInventoryManagementContext> options)
            : base(options)
        {
        }

        public DbSet<BikeInventoryManagement.Models.BikeType> BikeType { get; set; } = default!;

        public DbSet<BikeInventoryManagement.Models.Location>? Location { get; set; }

        public DbSet<BikeInventoryManagement.Models.Bike>? Bike { get; set; }

        public DbSet<BikeInventoryManagement.Models.BikePart>? BikePart { get; set; }

        public DbSet<BikeInventoryManagement.Models.BikePartPhoto>? BikePartPhoto { get; set; }

        public DbSet<BikeInventoryManagement.Models.BikePhoto>? BikePhoto { get; set; }

        public DbSet<BikeInventoryManagement.Models.Employee>? Employee { get; set; }
    }
}
