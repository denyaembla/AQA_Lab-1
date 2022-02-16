using System.Collections;
using Bogus;

namespace Drivers;

public class Vehicle
{
    public Vehicle(string model, int year, string owner, Engine engine)
    {
        Model = model;
        Year = year;
        Owner = owner;
        _engine = engine;
    }

    public string Model;
    public int Year;
    public string Owner;
    public Engine _engine;
    public static Vehicle CreateVehicle()
    {
        var vehicle = new Faker<Vehicle>()
            .CustomInstantiator(faker => new Vehicle(
                faker.Name.FirstName(),
                faker.Random.Int(min: 1960, max: 2022),
                faker.Name.FullName(),
                Engine.CreateEngine()));
        return vehicle;
    }   
}
