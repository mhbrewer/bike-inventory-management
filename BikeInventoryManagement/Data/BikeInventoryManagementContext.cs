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

        //public async List<Bike> GetAllBikes()
        //{
        //    List<Bike> ret = await Bike.ToListAsync();
        //    List<BikeType> types = await BikeType.ToListAsync();
        //    List<Location> loc = await Location.ToListAsync();
        //    foreach(Bike bike in ret)
        //    {
        //        if(bike.BikeType)
        //    }
        //    return ret;
        //}
    }
}
