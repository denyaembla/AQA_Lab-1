using Bogus;

namespace TASK_3;

public class Engine
{
    private const int MinimumCapacity = 50;
    private const int MaximumCapacity = 170;
    private const int MinimumPower = 50;
    private const int MaximumPower = 170;
    private const double MinimumSpeed = 90;
    private const double MaximumSpeed = 140;

    private static readonly string[] FuelTypes = {"Gasoline", "Diesel"};

    public int Capacity { get; set; }
    public int Power { get; set; }
    public double MaxSpeed { get; set; }
    public string FuelType { get; set; }

    public static Engine CreateEngine()
    {
        var engine = new Faker<Engine>()
            .CustomInstantiator(faker => new Engine())
            .RuleFor(e => e.Capacity, (f, e) => f.Random.Int(MinimumCapacity, MaximumCapacity))
            .RuleFor(e => e.Power, (f, e) => f.Random.Int(MinimumPower, MaximumPower))
            .RuleFor(e => e.MaxSpeed, (f, e) => f.Random.Double(MinimumSpeed, MaximumSpeed))
            .RuleFor(e => e.FuelType, (f, e) => f.PickRandomParam(FuelTypes));

        return engine.Generate();
    }
}