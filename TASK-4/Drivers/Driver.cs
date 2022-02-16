using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Drivers;
using Bogus;

public class Driver
{
    Guid ID = Guid.NewGuid();
    public DateTimeOffset licenseDateTime;
    public Car car;
    public string name;
    public string lastname;
    public DateOnly birthDateTime;
    public static bool isEligibleToDrive = true;

    public Driver(string name, string lastname, DateOnly birthDateTime, bool isEligibleToDrive,
        DateTimeOffset licenseDateTime, Car _car)
    {
        this.name = name;
        this.lastname = lastname;
        this.birthDateTime = birthDateTime;
        this.licenseDateTime = licenseDateTime;
        car = _car;
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

        
}

