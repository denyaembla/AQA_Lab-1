using Bogus;
using Task_5.Models;

namespace Task_5.Generators;

public class UserGenerator
{
    private static int _counter = 1;
    private const int MinimumAge = 16;
    private const int MaximumAge = 60;

    public static User GenerateUserWithoutItems()
    {
        var userWithoutItems = new Faker<User>().CustomInstantiator(
                faker => new User())
            .RuleFor(u => u.FullName, (f, u)=> f.Name.FullName())
            .RuleFor(u => u.Age, (f, u) => f.Random.Int(MinimumAge, MaximumAge))
            .RuleFor(u => u.PassportId, (f, u)=> _counter++);

        return userWithoutItems.Generate();
    }
    
    public static User GenerateUserWithItems()
    {
        var userWithItems = new Faker<User>().CustomInstantiator(
                faker => new User())
            .RuleFor(u => u.FullName, (f, u)=> f.Name.FullName())
            .RuleFor(u => u.Age, (f, u) => f.Random.Int(MinimumAge, MaximumAge))
            .RuleFor(u => u.PassportId, (f, u)=> _counter++)
            .RuleFor(u => u.GroceryBag, (u, f)=> ItemGenerator.GenerateItems());

        return userWithItems.Generate();
    }
}
