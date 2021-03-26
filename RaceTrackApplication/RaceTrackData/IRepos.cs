using System;
using System.Collections.Generic;
using System.Text;

namespace RaceTrackData
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
    }
   

    public class CarRepository : IDataRepository<Car>
    {
        public void Add(Car entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Car> GetAll()
        {
            throw new NotImplementedException();
        }
    }

    public class TruckRepository : IDataRepository<Truck>
    {
        public void Add(Truck entity)
        {
            IVehicle truck = new Truck();
            truck.Save();
        }

        public IEnumerable<Truck> GetAll()
        {
            throw new NotImplementedException();
        }
    }

}
