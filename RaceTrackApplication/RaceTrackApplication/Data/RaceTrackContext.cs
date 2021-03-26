using RaceTrackApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace RaceTrackApplication.Data
{
    public class RaceTrackContext : DbContext
    {
        //public RaceTrackContext(DbContextOptions<RaceTrackContext> options) : base(options)
        //{

        //}

        public DbSet<Car> Cars { get; set; }
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<Track> Tracks { get; set; }
    }
}
