using Groupwork.Models;

namespace Groupwork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            using (var context = new ParkmanContext())
            {
                // Query ParkingLots
                var parkingLots = context.ParkingLots.ToList();
                Console.WriteLine("Parking Lots:");
                foreach (var lot in parkingLots)
                {
                    Console.WriteLine($"- {lot.Name} ({lot.Location}), Capacity: {lot.Capacity}");
                }

                // Add a new Vehicle
                var newVehicle = new Vehicle
                {
                    LicensePlate = "NEW123",
                    OwnerName = "Nemo Demo",
                    VehicleType = "SUV"
                };
                context.Vehicles.Add(newVehicle);
                context.SaveChanges();
                Console.WriteLine("New vehicle added successfully.");

                var AllvehiclesFromDb = context.Vehicles.ToList();
                Console.WriteLine("All Cars:");
                foreach (var car in AllvehiclesFromDb)
                {
                    Console.WriteLine($"- {car.OwnerName} ({car.LicensePlate}), VehicleType: {car.VehicleType}");
                }
            }
        }
    }
}
