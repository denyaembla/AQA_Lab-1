using Bogus;
using Bogus.DataSets;

namespace TASK_3;

public class Driver : User
{
    private Guid Id { get; set; }
    private DateTimeOffset LicenseDate { get; set; }
    private Vehicle _Vehicle { get; set; }
    
    private static readonly DateTimeOffset MinimumBirthDate = new DateTime(1950, 01, 01);
    private static readonly DateTimeOffset MaximumBirthDate = new DateTime(2000, 01, 01);
    private static readonly DateTimeOffset MinimumLicenceDate = MinimumBirthDate.AddYears(16);
    private static readonly DateTimeOffset MaximumLicenceDate = new DateTime(2022, 01, 01);

    public static Driver CreateDriver()
    {
        var driver = new Faker<Driver>()
            .CustomInstantiator(faker => new Driver())
            .RuleFor(d => d.Id, (f, d) => Guid.NewGuid())
            .RuleFor(d => d.Fullname, (f, d) => f.Name.FullName())
            .RuleFor(d => d._Vehicle, (f, d) => Vehicle.CreateVehicle())
            .RuleFor(d => d.BirthDateTime, (f, d) => f.Date.BetweenOffset(
                MinimumBirthDate, MaximumBirthDate))
            .RuleFor(d => d.LicenseDate, (f,d) => f.Date.BetweenOffset(
                MinimumLicenceDate, MaximumLicenceDate));

        return driver.Generate();
    }
    
    public static void DisplayDriver(Driver driver)
    {
        var birthdayToString = driver.BirthDateTime.DateTime.ToString("MM/dd/yyyy");
        Console.WriteLine($" Driver's name is {driver.Fullname}," +
                          $" born on {birthdayToString}," +
                          $" licence's date of issue: {driver.LicenseDate}," +
                          $" with ID {driver.Id} \n ");
    }
   
    public static void DisplayExploitationStats(Driver driver)
    {
        var drivingYearsAmount = DateTime.Now - driver.LicenseDate;
        Console.WriteLine($"Current driver's amount of years driving: {drivingYearsAmount.Days / 365}");
        Console.WriteLine("\nPlease, enter an estimated travel length amount (kilometers)");
        var travelLength = Convert.ToInt32(Console.ReadLine());
        var countedTravelTime = Convert.ToInt32(travelLength / driver._Vehicle._Engine.MaxSpeed * 60);
        var travelTime = TimeSpan.FromMinutes(countedTravelTime);
        Console.WriteLine("Approximate travel time is {0:t}", travelTime);
    }
     
    public static void DisplayVehicleStats(Driver driver)
    {
        Console.WriteLine($"\nCar model is:{driver._Vehicle.Model} \n" +
                          $"Engine power equals {driver._Vehicle._Engine.Power} h.p. \n" +
                          $"Maximum speed: {driver._Vehicle._Engine.MaxSpeed:F0} km/h \n"  +
                          $"Fuel used is {driver._Vehicle._Engine.FuelType} \n"  +
                          $"Capacity is {driver._Vehicle._Engine.Capacity} kilometers");
    }
}

