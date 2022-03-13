using Bogus;

namespace TASK_3;

public class Vehicle
{ 
    public string Model;
    public int Year;
    public string Owner;
    public Engine Engine;
    public Vehicle(string model, int year, string owner, Engine engine)
    {
        Model = model;
        Year = year;
        Owner = owner;
        Engine = engine;
    }

   
    public static Vehicle CreateVehicle()
    {
        var vehicle = new Faker<Vehicle>()
            .CustomInstantiator(faker => new Vehicle(
                faker.PickRandom("Volvo S90", "Mercedes CV-930", "Audi V2020"),
                faker.Random.Int(min: 1960, max: 2022),
                User.Lastname,
                Engine.CreateEngine()));
        return vehicle;
    }   
}
