// using System;
using System.Collections.Generic;

namespace Lab
{
    public class System
    {
        private List<Ride> rides;
        private List<Car> cars;
        private List<string> drivers;

        public List<Car> Cars { get; set; }
        public List<string> Drivers { get; set; }
        public List<Ride> Rides { get; set; }

        public void AddCar(Car c)
        {
            Cars.Add(c);
        }

        public void AddDriver(string d)
        {
            Drivers.Add(d);
        }

        public void AddRide(Ride r)
        {
            Rides.Add(r);
            Cars.Remove(r.Car);
            Drivers.Remove(r.Driver);
        }

        public System()
        {
            Cars = new List<Car>();
            Drivers = new List<string>();
            Rides = new List<Ride>();
        }
    }
}
