using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RaceTrackApplication.Models
{
    public enum Color
    {
        White = 0,
        Black,
        Red,
        Grey,
        Brown
    }

    [Table("Vehicle")]
    public abstract class Vehicle
    {
        private int _VehicleId;
        [Key]
        public int VehicleId
        {
            get
            {
                return _VehicleId;
            }
        }

        [Required]
        [MaxLength(25)]
        public string TypeOfVehicle;

        [Required]
        [MaxLength(25)]
        public string Make;

        [Required]
        [MaxLength(25)]
        public string Model;

        [Required]
        [MaxLength(25)]
        public Color Color;

        [Required]
        public decimal Price;

        public int Speed { get; set; }

        public bool TowStrap { get; set; }

        public int speed;
        public abstract int MaxAccelerate { get; set; }
        
        public static int MinDeaccelerate = 10;
        
        public static bool Straps = false;
        
        public Vehicle()
        {
            
        }
        public Vehicle(string typeOfVehicle, string make, string model, Color color, decimal price)
            : this()
        {
            this.Make = make;
            this.Model = model;
            this.Color = color;
            this.Price = price;
            this.TypeOfVehicle = typeOfVehicle;
        }
        public abstract void Start();
        public abstract void Stop();
        public abstract void Accelerate(int offsetSpeed);
        public void DeAccelerate(int offsetSpeed)
        {
            if (offsetSpeed < MinDeaccelerate)
            {
                throw new ApplicationException("Your car is going to stop");
            }
            if (Speed <= 10)
            {
                throw new ApplicationException("Max speed of Car cannot be accelerate");
            }
            Speed -= offsetSpeed;
        }
    }

    [Table("Car")]
    public class Car : Vehicle
    {
        public static int MaxLiftInInches = 5;
        private int _MaxAccelerate = 10;
        public override int MaxAccelerate
        {
            get
            {
                return _MaxAccelerate;
            }
            set
            {
                _MaxAccelerate = value;
            }
        }

        public bool MaxLift { get; set; }
        public int MyProperty { get; set; }
        public Car()
        {
            //default constructor
        }
        public Car(string typeOfVehicle, string make, string model, Color color, decimal price)
            : base(typeOfVehicle, make, model, color, price)
        {
            
        }
        public override void Start()
        {
            Speed = 20;
        }
        public override void Stop()
        {
            Speed = 0;
        }
        public override void Accelerate(int offsetSpeed)
        {
            if (offsetSpeed < MaxAccelerate)
            {
                throw new ApplicationException("Your Car cannot start");
            }
            if (Speed >= 140)
            {
                throw new ApplicationException("Car cannot cross beyond Max Speed");
            }
            Speed += offsetSpeed;
        }
        public override string ToString()
        {
            return "Your Car is running at the Speed" + Speed + "\r\n Color:" + Color + "\r\n Make:" + Make + "\r\n Model:" + Model;
        }
    }

    [Table("Truck")]
    public class Truck : Vehicle
    {
        public static int MaxTireWearInPercentage = 85;
        private int _MaxAccelerate = 120;
        public Truck()
        {
            //default constructor
        }
        public bool MaxTireWear { get; set; }
        public override int MaxAccelerate
        {
            get
            {
                return _MaxAccelerate;
            }
            set
            {
                _MaxAccelerate = value;
            }
        }
        public Truck(string typeOfVehicle, string make, string model, Color color, decimal price)
            : base(typeOfVehicle, make, model, color, price)
        {
            
        }

        public override string ToString()
        {
            return "Your Truck is running at the Speed" + Speed + "\r\n Color:" + Color + "\r\n Make:" + Make + "\r\n Model:" + Model;
        }
        public override void Accelerate(int offsetSpeed)
        {
            if (Speed + offsetSpeed >= _MaxAccelerate)
            {
                throw new ApplicationException("Your crossing Max speed");
            }
            else
            {
                Speed += offsetSpeed;
            }
        }
        public override void Start()
        {
            Speed = 20;
        }
        public override void Stop()
        {
            Speed = 0;
        }
    }

    public class Track
    {
        public int TrackId { get; set; }
        public int VehicleId { get; set; }
        public bool IsTowStrapOn { get; set; }
        public bool IfMaxLifted { get; set; }
        public bool IfMaxTireWear { get; set; }
    }

}