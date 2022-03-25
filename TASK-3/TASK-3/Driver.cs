using Bogus;
using Bogus.DataSets;

namespace TASK_3;

public class Driver : User
{
    private static readonly DateTimeOffset MinimumBirthDate = new DateTime(1950, 01, 01);
    private static readonly DateTimeOffset MaximumBirthDate = DateTime.Today;
    private static readonly DateTimeOffset MaximumLicenceDate = DateTime.Today;
    private Guid Id { get; set; }
    internal DateTimeOffset LicenseDate { get; set; }
    internal Vehicle _Vehicle { get; set; }

    private static DateTimeOffset BirthdayGeneration()
    {
        var birthdayDate = new Faker().Date.BetweenOffset(MinimumBirthDate, MaximumBirthDate);
        return birthdayDate;
    }
    
    private static bool IsDriverValidation(DateTimeOffset birthdayDate)
    {
        return DateTime.Now.Year - birthdayDate.Year >= 16;
    }

    public static Driver CreateDriver()
    {
        var birthday = BirthdayGeneration();
        var driver = new Faker<Driver>()
            .CustomInstantiator(faker => new Driver())
            .RuleFor(d => d.Id, (f, d) => Guid.NewGuid())
            .RuleFor(d => d.Fullname, (f, d) => f.Name.FullName())
            .RuleFor(d => d._Vehicle, (f, d) => Vehicle.CreateVehicle())
            .RuleFor(d => d.BirthDateTime, (f, d) => birthday)
            .RuleFor(d => d.LicenseDate, (f, d) => f.Date.BetweenOffset(
                birthday.DateTime.AddYears(16), MaximumLicenceDate))
            .RuleFor(d => d.isDriver, (f, d) => IsDriverValidation(
                birthday));
        return driver.Generate();
    }

    public static void DisplayDriver(Driver driver)
    {
        if (driver.isDriver)
        {
            var birthdayToString = driver.BirthDateTime.DateTime.ToString("MM/dd/yyyy");
            Console.WriteLine($"\n Driver's name is {driver.Fullname}," +
                              $" is driver," +
                              $" born on {birthdayToString}," +
                              $" with ID {driver.Id},");

            Console.WriteLine($"License's date of issue: {driver.LicenseDate:dd.MM.yyyy}");
        }
        else
        {
            Console.WriteLine($"\nSorry, user {driver.Fullname} is not eligible to drive." +
                              $" User age is {DateTime.Now.Year - driver.BirthDateTime.Year}");
        }
    }
}
