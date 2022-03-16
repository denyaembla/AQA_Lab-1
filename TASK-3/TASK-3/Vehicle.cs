using Bogus;

namespace TASK_3;

public class Vehicle
{
    internal string Model { get; set; }
    private int Year { get; set; }
    private string Owner { get; set; }
    internal Engine _Engine { get; set; }
    
    private const int MinimumManufactureYear = 1930;
    private const int MaximumManufactureYear = 2020;
    
    public static Vehicle CreateVehicle()
    {
        var vehicle = new Faker<Vehicle>()
            .CustomInstantiator(faker => new Vehicle())
            .RuleFor(v => v.Model, (f, v) => f.Vehicle.Manufacturer())
            .RuleFor(v => v.Year, (f, v) => f.Random.Int(
                MinimumManufactureYear, MaximumManufactureYear))
            .RuleFor(v => v.Owner, (f, v) => f.Name.FullName())
            .RuleFor(v => v._Engine, (f, v) => Engine.CreateEngine());

        return vehicle.Generate();
    }
 
}
