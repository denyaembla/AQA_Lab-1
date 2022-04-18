using Bogus;
using Task_5.Models;

namespace Task_5.Generators;

public class UserGenerator
{
    private const int MinimumAge = 16;
    private const int MaximumAge = 60;

    public static User CreateUserWithoutItems()
    {
        var userWithoutItems = new Faker<User>().CustomInstantiator(
                faker => new User())
            .RuleFor(u => u.FullName, (f, u) => f.Name.FullName())
            .RuleFor(u => u.Age, (f, u) => f.Random.Int(MinimumAge, MaximumAge))
            .RuleFor(u => u.PassportId, (f, u) => Guid.NewGuid())
            .RuleFor(u => u.GroceryBag, (f, u) => new List<Item>());

        return userWithoutItems.Generate();
    }

    public static User CreateUser()
    {
        var userWithItems = new Faker<User>().CustomInstantiator(
                faker => new User())
            .RuleFor(u => u.FullName, (f, u) => f.Name.FullName())
            .RuleFor(u => u.Age, (f, u) => f.Random.Int(MinimumAge, MaximumAge))
            .RuleFor(u => u.PassportId, (f, u) => Guid.NewGuid())
            .RuleFor(u => u.GroceryBag, (u, f) => ItemGenerator.GenerateItems());

        return userWithItems.Generate();
    }

    public static User CreateUserUsingConsole(Guid passportId)
    {
        Console.Write("Enter new user's name \n");
        var inputName = Console.ReadLine();
        while (!Validation.InputValidation.NameValidation(inputName))
        {
            Console.WriteLine("User's firstname cannot contain numbers or be empty.");
            inputName = Console.ReadLine();
        }

        Console.Write("Enter new user's lastname \n");
        var inputLastname = Console.ReadLine();
        while (!Validation.InputValidation.NameValidation(inputLastname))
        {
            Console.WriteLine("User's lastname cannot contain numbers or be empty.");
            inputLastname = Console.ReadLine();
        }

        Console.Write("Enter new user's age \n");
        var inputAge = Console.ReadLine();
        int age;
        while (!Validation.InputValidation.AgeValidation(inputAge) || !int.TryParse(inputAge, out age))
        {
            Console.WriteLine("User's age cannot contain letters or be empty." +
                              " You are allowed to use our shop if you are over 11 and less than 99 years old.");
            inputAge = Console.ReadLine();
        }

        var user = new User
        {
            PassportId = passportId,
            Age = age,
            FullName = inputName + " " + inputLastname,
            GroceryBag = new List<Item>()
        };
        return user;
    }
}