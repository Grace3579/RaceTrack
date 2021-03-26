using System;
using System.Collections.Generic;

namespace RaceTrackData
{
    public interface IVehicle
    {
        void Save();
       // GetAll();
    }

    public class Car : IVehicle
    {
        public void Save()
        {
            throw new NotImplementedException();
        }
    }

    public class Truck : IVehicle
    {
        public void Save()
        {
            throw new NotImplementedException();
        }
    }

    public static class VehicleFactory
    {
        public static IVehicle Build(int numberOfWheels)
        {
            switch (numberOfWheels)
            {
                case 4:
                    return new Car();
                default:
                    return new Truck();

            }
        }
    }
}
