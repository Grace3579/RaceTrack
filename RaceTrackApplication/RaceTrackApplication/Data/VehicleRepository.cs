using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using RaceTrackApplication.Models;

namespace RaceTrackApplication.Data
{
    public class VehicleRepository : DbContext, IRepository
    {

        private readonly RaceTrackContext dbContext;
        public VehicleRepository(RaceTrackContext context)
        {
            this.dbContext = context;
        }

        public void AddVehicle(Vehicle vehicle)
        {
            this.dbContext.Set<Vehicle>().Add(vehicle);
            /*var veh = new Car();
            //veh.VehicleId = ; // auto increment
            veh.TypeOfVehicle = vehicle.TypeOfVehicle;
            veh.Make = vehicle.Make;
            veh.Model = vehicle.Model;
            veh.Color = vehicle.Color;
            veh.Price = vehicle.Price;
            veh.Speed = vehicle.Speed;*/
            this.dbContext.SaveChanges();
        }

        private readonly Dictionary<string, Vehicle> _vehicles;
        public Vehicle this[string name] => throw new NotImplementedException();

        public IEnumerable<Vehicle> GetVehicles()
        {
            return (IList<Vehicle>)dbContext.Cars.OrderByDescending(x=>x.Speed).Take(5).ToList();
        }

        public void AddVehicleToTrack(Track track)
        {
            this.dbContext.Set<Track>().Add(track);
            this.dbContext.SaveChanges();
        }
    }
}
