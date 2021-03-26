//using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace RaceTrackData
{
    public class RaceTrackContext1 : DbContext
    {
        //public RaceTrackContext(DbContextOptions<RaceTrackContext> options) : base(options)
        //{

        //}

        public DbSet<Car> Cars { get; set; }
        public DbSet<Truck> Trucks { get; set; }
    }
}
