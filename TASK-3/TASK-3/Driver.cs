using Bogus;
using Drivers;

namespace TASK_3;

public class Driver : User
{
    Guid _id = Guid.NewGuid();
    public static DateTimeOffset LicenseDateTime;
    public static Car Car;
    

    private Driver(string name, string lastname, DateTimeOffset birthDateTime, bool isEligibleToDrive,
        DateTimeOffset licenseDateTime, Car car)
    {
        Driver.Name = name;
        Driver.Lastname = lastname;
        Driver.BirthDateTime = birthDateTime;
        Driver.LicenseDateTime = licenseDateTime;
        Car = car;
    }

    private static readonly DateTimeOffset MinimumDate = new DateTime(1950, 01, 01);
    private static readonly DateTimeOffset MaximumDate = new DateTime(2000, 01, 01);

    public static Driver CreateDriver()
    {
        var driver = new Faker<Driver>()
            .CustomInstantiator(faker => new Driver(
                faker.Name.FirstName(),
                faker.Name.LastName(),
                faker.Date.BetweenOffset(MinimumDate, MaximumDate),
                true,
                faker.Date.BetweenOffset(MinimumDate.AddYears(16), MaximumDate),
                Car.CreateCar()));
        return driver;
    }

    

    public void DisplayDriver()
    {
        var birthdayToString = BirthDateTime.DateTime.ToString("MM/dd/yyyy");
        Console.WriteLine($" Driver's name is {Name} {Lastname}," +
                          $" born on {birthdayToString}," +
                          $" with ID {_id} \n ");
    }

    public void DisplayTechStats()
    {
        Console.WriteLine($"\nThe car is: {Car.CarName} {Car.Vehicle.Model} \n" +
                          $"Engine power is {Car.Vehicle.Engine.Power} h.p. \n" +
                          $"Maximum speed is {Car.Vehicle.Engine.MaxSpeed:F0} km/h \n"  +
                          $"Used fuel is {Car.Vehicle.Engine.FuelType} \n"  +
                          $"This car's capacity is {Car.Vehicle.Engine.Capacity} kilometers");
    }

    public void DisplayExploitationStats()
    {
        var drivingYearsAmount = DateTime.Now - BirthDateTime.AddYears(16);
        Console.WriteLine($"Current driver's amount of years driving: {drivingYearsAmount.Days / 365}");
        Console.WriteLine("\nPlease, enter an estimated travel length amount (kilometers)");
        var travelLength = Convert.ToInt32(Console.ReadLine());
        var countedTravelTime =Convert.ToInt32(travelLength / Car.Vehicle.Engine.MaxSpeed * 60);
        var travelTime = TimeSpan.FromMinutes(countedTravelTime);
        Console.WriteLine("Approximate travel time is {0:t}", travelTime);
    }
        
}

