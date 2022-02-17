using System.Net;
using Bogus;

namespace Drivers;

public class Engine
{
    

    public int Capacity;
    public int Power;
    public double MaxSpeed;
 public enum FuelType
 {
     Diesel,
     Gasoline
 };
    public Engine(int capacity, int power, Enum FuelType, double maxSpeed)
    {
        Capacity = capacity;
        Power = power;
        FuelType = Engine.FuelType.Diesel;
        MaxSpeed = maxSpeed;
    }

    
    public static Engine CreateEngine()
    {
        Engine engine =  new Faker<Engine>()
            .CustomInstantiator(faker => new Engine(
                faker.Random.Int(min:50, max:250),
                faker.Random.Int(min:70, max:160),
                faker.PickRandom<Enum>(Engine.FuelType.Diesel, Engine.FuelType.Gasoline),
                faker.Random.Double(100, 220)));
        return engine;
    }

    
}
