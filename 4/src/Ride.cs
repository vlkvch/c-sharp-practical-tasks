using System;
using System.Collections.Generic;

namespace Lab
{
    public class Ride
    {
        private Car car;
        private string driver;
        private string state;

        public Car Car
        {
            get
            {
                return car;
            }
            set
            {
                if (value.NeedsRepair)
                {
                    Console.WriteLine("[!] Машине нужна починка");
                }
                else
                {
                    car = value;
                }
            }
        }
        public string Driver { get; set; }
        public string State { get; set; }

        public override string ToString()
        {
            return $"{Car.Make} {Car.Model}, {Driver}: {State}";
        }

        public void Complete()
        {
            State = "Completed";
        }

        public Ride(Car car, string driver)
        {
            Car = car;
            Driver = driver;
            State = "Ongoing";
        }
    }
}
