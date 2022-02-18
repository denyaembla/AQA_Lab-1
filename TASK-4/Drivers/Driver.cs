using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Bogus.DataSets;

namespace Drivers;
using Bogus;

public class Driver
{
    Guid ID = Guid.NewGuid();
    public static DateTimeOffset licenseDateTime;
    public static Car _car;
    public static string name;
    public static string lastname;
    public static DateTimeOffset birthDateTime;
    public static bool IsEligibleToDrive = true;

    public Driver(string name, string lastname, DateTimeOffset birthDateTime, bool isEligibleToDrive,
        DateTimeOffset licenseDateTime, Car car)
    {
        Driver.name = name;
        Driver.lastname = lastname;
        Driver.birthDateTime = birthDateTime;
        Driver.licenseDateTime = licenseDateTime;
        _car = car;
    }

    private static DateTimeOffset minimumDate = new DateTime(1950, 01, 01);
    private static DateTimeOffset maximumDate = new DateTime(2000, 01, 01);

    private static Driver CreateDriver()
    {
        var driver = new Faker<Driver>()
            .CustomInstantiator(faker => new Driver(
                faker.Name.FirstName(),
                faker.Name.LastName(),
                faker.Date.BetweenOffset(minimumDate, maximumDate),
                true,
                faker.Date.BetweenOffset(minimumDate.AddYears(16), maximumDate),
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
                chosenDriver.DisplayTechStats();
                break;
            case 2:
                chosenDriver.DisplayExploitationStats();
                break;
        }
    }

    private void DisplayDriver()
    {
        var birthdayToString = birthDateTime.DateTime.ToString("MM/dd/yyyy");
        Console.WriteLine($" Driver's name is {name} {lastname}," +
                          $" born on {birthdayToString}," +
                          $" with ID {ID} \n ");
    }

    private void DisplayTechStats()
    {
        Console.WriteLine($"\nThe car is: {_car.CarName} {_car._vehicle.Model} \n" +
                          $"Engine power is {_car._vehicle._engine.Power} h.p. \n" +
                          $"Maximum speed is {_car._vehicle._engine.MaxSpeed:F0} km/h \n"  +
                          $"Used fuel is {_car._vehicle._engine.FuelType} \n"  +
                          $"This car's capacity is {_car._vehicle._engine.Capacity} miles");
    }

    private void DisplayExploitationStats()
    {
        var drivingYearsAmount = DateTime.Now - birthDateTime.AddYears(16);
        Console.WriteLine($"Current driver's amount of years driving: {drivingYearsAmount.Days / 365}");
        
        
        
        
        Console.WriteLine("\nPlease, enter an estimated travel length amount (kilometers)");
        var travelLength = Convert.ToInt32(Console.ReadLine());
        var countedTravelTime =Convert.ToInt32(travelLength / _car._vehicle._engine.MaxSpeed * 60);
        var travelTime = TimeSpan.FromMinutes(countedTravelTime);
        Console.WriteLine("Approximate travel time is {0:t}", travelTime);
    }
        
}

