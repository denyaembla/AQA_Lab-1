namespace Drivers;
using Bogus;

public class Car
{
   public Vehicle _vehicle;
   public string CarName;
   public Car(Vehicle vehicle, string carName)
   {
      _vehicle = vehicle;
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

   
