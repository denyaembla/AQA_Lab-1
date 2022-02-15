using System.Net;
using Bogus;

namespace Drivers;

public class Engine
{
    

    private int Capacity;
    private int Power;

    public enum FuelType
    {
        Diesel,
        Gasoline
    };
 
    private int MaxSpeed;
    
    public Engine(int capacity, int power, Enum FuelType, int maxSpeed)
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
                faker.PickRandom<Enum>(FuelType.Diesel, FuelType.Gasoline),
                faker.Random.Int(100, 220)));
               return engine;
    }
}
