namespace Drivers;
using Bogus;
public class Driver : Users
{
    public Driver(DateOnly licenseDateTime, Car car)
    {
        this.licenseDateTime = licenseDateTime;
        _car = new Car();
    }

    Guid ID = Guid.NewGuid();
    public DateOnly licenseDateTime;
    public Car _car = new Car();

   



public static void CreateDrivers()
    {
        List<Driver> driversList = new List<Driver>();
        for(var i = 1; i<3; i++)
            driversList.Add(new Faker<Driver>().
                CustomInstantiator(faker => new Driver(
                    faker.Name.())));
    }
}   
