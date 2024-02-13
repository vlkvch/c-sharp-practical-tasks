using System;

namespace Lab
{
    class Program
    {
        static void Main()
        {
            var carOne = new Car("BMW", "X5", false);
            var carTwo = new Car("Volvo", "V90", false);
            var carThree = new Car("Kia", "Rio", true);

            var system = new System();

            system.AddCar(carOne);
            system.AddCar(carTwo);
            system.AddCar(carThree);

            system.AddDriver("Bob");
            system.AddDriver("Carl");
            system.AddDriver("John");

            Console.WriteLine("Доступные машины:");

            foreach (Car c in system.Cars)
                Console.WriteLine($"{system.Cars.IndexOf(c) + 1}. {c.Make} {c.Model}");

            Console.Write("Выберите номер машины:\n> ");
            int carIndex = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("Доступные водители:");
            
            foreach (string d in system.Drivers)
                Console.WriteLine($"{system.Drivers.IndexOf(d) + 1}. {d}");

            Console.Write("Выберите водителя:\n> ");
            int driverIndex = int.Parse(Console.ReadLine()) - 1;

            system.AddRide(new Ride(system.Cars[carIndex], system.Drivers[driverIndex]));

            Console.WriteLine(system.Rides[0]);

            system.Rides[0].Complete();

            Console.WriteLine(system.Rides[0]);
        }
    }
}
