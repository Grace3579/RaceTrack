using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RaceTrackApplication.Models;

namespace RaceTrackApplication.Data
{
    public interface IRepository
    {
        IEnumerable<Vehicle> GetVehicles();

        void AddVehicle(Vehicle vehicle);
        void AddVehicleToTrack(Track track);
    }
}
