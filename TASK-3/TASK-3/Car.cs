using TASK_3;

namespace Drivers;
using Bogus;

public class Car
{
   public Vehicle Vehicle;
   public string CarName;

   private Car(Vehicle vehicle, string carName)
   {
      Vehicle = vehicle;
      CarName = carName;
   }
   
   public static Car CreateCar()
   {
      Car car = new Faker<Car>()
         .CustomInstantiator(faker => new Car(
            Vehicle.CreateVehicle(),
            faker.Name.FirstName()));
            return car;
   }
}

   
