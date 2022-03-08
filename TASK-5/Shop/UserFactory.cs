using Bogus;
using Microsoft.CSharp.RuntimeBinder;
using Shop.Models;

namespace Shop;

public static class UserFactory
{
    public static int Counter = 1;
    public static List<User> UsersContainer = new();
    public static User GenerateUser()
    {
        var user = new Faker<User>().CustomInstantiator(
            faker => new User(
                Counter++,          //assignment of ID as a counter (1-2-3-4-5).
                faker.Name.FirstName(),
                faker.Name.LastName(),
                faker.Random.Int(16, 35)));
        return user;
    }
    public static void AddUserFromConsole()
    {
        Console.Write("You are going to create new user \n Enter new user's passportID \n"); //Add validation;
        var inputPassportId = Convert.ToInt32(Console.ReadLine());

        if (Validation.SameIdChecker(inputPassportId, UsersContainer))
        {
            Console.Write("Enter new user's name \n");
            var inputName = Console.ReadLine();
            Console.Write("Enter new user's lastname \n");
            var inputLastname = Console.ReadLine();
            Console.Write("Enter new user's age \n");
            var inputAge = Convert.ToInt32(Console.ReadLine());
            var newUser = new User(inputPassportId, inputName, inputLastname, inputAge);
            UsersContainer.Add(newUser);
        }
        else
        {
            throw new Exception("User with this passport ID already exists");
        }
        
    }
    
    public static List<User> GenerateRandomAmountOfUsers()
    {
        var randomAmount = new Random();
        var amount = Convert.ToInt32(randomAmount.Next(2, 2));
        for (int i = 1; i <= amount; i++)
        {
            UsersContainer.Add(GenerateUser());
        }
        return UsersContainer;
    }
    
    public static void DisplayUser(User user)
    {
        Console.WriteLine($"\n{user.Name} {user.Lastname} with ID-{user.PassportId} is {user.Age} years old.");
    }
    public static void DisplayEveryUser()
    {
        foreach (var u in UsersContainer)
        {
            DisplayUser(u);
        }
    }
    
    
}
