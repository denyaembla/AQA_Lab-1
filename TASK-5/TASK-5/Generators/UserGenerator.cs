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
            .RuleFor(u => u.FullName, (f, u) => f.Name.FullName())
            .RuleFor(u => u.Age, (f, u) => f.Random.Int(MinimumAge, MaximumAge))
            .RuleFor(u => u.PassportId, (f, u) => _counter++)
            .RuleFor(u => u.GroceryBag, (f, u) => new List<Item>());

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

    public static User GenerateUserFromConsole(int passportId)
    {
        Console.Write("Enter new user's name \n");
        var inputName = Console.ReadLine();
        Console.Write("Enter new user's lastname \n");
        var inputLastname = Console.ReadLine();
        Console.Write("Enter new user's age \n");
        var inputAge = Convert.ToInt32(Console.ReadLine());
        var user = new User
        {
            PassportId = passportId, 
            Age = inputAge,
            FullName = inputName + " " + inputLastname,
            GroceryBag = new List<Item>()
        };
        return user;
    }
}
