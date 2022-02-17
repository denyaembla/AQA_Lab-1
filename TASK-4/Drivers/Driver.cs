using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Drivers;
using Bogus;

public class Driver
{
    Guid ID = Guid.NewGuid();
    public static DateTimeOffset licenseDateTime;
    public static Car _car;
    public static string name;
    public static string lastname;
    public static DateOnly birthDateTime;
    public static bool IsEligibleToDrive = true;

    public Driver(string name, string lastname, DateOnly birthDateTime, bool isEligibleToDrive,
        DateTimeOffset licenseDateTime, Car car)
    {
        Driver.name = name;
        Driver.lastname = lastname;
        Driver.birthDateTime = birthDateTime;
        Driver.licenseDateTime = licenseDateTime;
        _car = car;
    }
    
    public static DateTimeOffset minDateForLicence = new DateTimeOffset(new DateTime(1950, 01, 01));
    public static DateTimeOffset maxDateForLicence = new DateTimeOffset(new DateTime(2000, 01, 01));

    public static Driver CreateDriver()
    {
        var driver = new Faker<Driver>()
            .CustomInstantiator(faker => new Driver(
                faker.Name.FirstName(),
                faker.Name.LastName(),
                faker.Date.PastDateOnly(),
                true,
                faker.Date.BetweenOffset(minDateForLicence, maxDateForLicence),
                Car.CreateCar()));
                
        return driver;
        }

    public static void CreateAndShowThreeDrivers()
    {
        var driver1 = CreateDriver();
        driver1.DisplayDriver();
        var driver2 = CreateDriver();
        driver2.DisplayDriver();
        var driver3 = CreateDriver();
        driver3.DisplayDriver();
        var chosenDriver = driver1;
        Console.WriteLine("Please, choose your driver");
        var driverToChoose = Convert.ToInt32(Console.ReadLine());
        switch (driverToChoose)
            {
                case 1:
                    chosenDriver = driver1;
                    chosenDriver.DisplayTechStats();
                    break;
                case 2:
                    chosenDriver = driver2;
                    chosenDriver.DisplayTechStats();
                    break;
                case 3:
                    chosenDriver = driver3;
                    chosenDriver.DisplayTechStats();
                    break; 
                default: break;
            }
        Console.WriteLine("Choose stats to show: \n 1 to see technical stats \n 2 to see exploitation stats");
        var statsType = Convert.ToInt32(Console.ReadLine());
        switch(statsType)
        {
            case 1:
                chosenDriver.DisplayExplStats();
                break;
            case 2:
                chosenDriver.DisplayExplStats();
                break;
        }
    }

    public void DisplayDriver()
    {   
        Console.WriteLine($"Driver's name is {name} {lastname}," +
                          $" born on {birthDateTime}," +
                          $" with ID {ID} \n ");
    }
    public void DisplayTechStats()
    {
        Console.WriteLine($"The car is: {_car.CarName} {_car._vehicle.Model} \n" +
                          $"Engine power is {_car._vehicle._engine.Power} h/p \n" +
                          $"Maximum speed is {_car._vehicle._engine.MaxSpeed} km/h \n"  +
                          $"This car's capacity is {_car._vehicle._engine.Capacity} miles");
    }
    public void DisplayExplStats()
    {
        Console.WriteLine($"Current driver's years of driving: {birthDateTime.AddYears(16)}" +
                          $"Time for 100 kilometers is {100 / _car._vehicle._engine.MaxSpeed } hours");
    }
        
}

