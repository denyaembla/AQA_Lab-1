using System.Net;
using Bogus;

namespace Drivers;

public class Engine
{
    

    public int Capacity;
    public int Power;
    public double MaxSpeed;
    public string FuelType;
    
    public Engine(int capacity, int power,  double maxSpeed, string fuelType)
    {
        Capacity = capacity;
        Power = power;
        MaxSpeed = maxSpeed;
        FuelType = fuelType;
    }

    
    public static Engine CreateEngine()
    {
        Engine engine =  new Faker<Engine>()
            .CustomInstantiator(faker => new Engine(
                faker.Random.Int(min:50, max:250),
                faker.Random.Int(min:70, max:160),
                faker.Random.Double(100, 220),
                faker.PickRandom<string>("Diesel", "Gasoline")));
        return engine;
    }

    
}
