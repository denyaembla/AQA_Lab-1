using System.Net;
using Bogus;

namespace Drivers;

public class Engine
{
    

    private int Capacity;
    private int Power;

    public enum fuelType
    {
        Diesel,
        Gasoline
    };
 
    private int MaxSpeed;
    
    public Engine(int capacity, int power, Enum fuelType, int maxSpeed)
    {
        Capacity = capacity;
        Power = power;
        fuelType = fuelType;
        MaxSpeed = maxSpeed;
    }

    
   

    public static void CreateEngine()
    {
        
        var engine = new Faker<Engine>()
            .CustomInstantiator(faker => new Engine(
                faker.Random.Int(min:50, max:250),
                faker.Random.Int(min:70, max:160),
                faker.PickRandom(fuelType),
                faker.Random.Int(100, 220)));
    }
}
