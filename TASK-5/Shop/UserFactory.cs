using Bogus;

namespace Shop;

public class UserFactory
{
    public static int counter = 1;
    List<User> usersContainer = new();
    public static User GenerateUser()
    {
        var user = new Faker<User>().CustomInstantiator(
            faker => new User(
                counter++,          //assignment of ID as a counter (1-2-3-4-5).
                faker.Name.FirstName(),
                faker.Name.LastName(),
                faker.Random.Int(16, 35)));
        return user;
    }
   
    public static void DisplayUser(User user)
    {
        Console.WriteLine($"{user._name} {user._lastname} with ID-{user.passportID} is {user._age} years old.");
    }

    public static User GenerateUserFromConsole()
    {
        Console.Write("You are going to create new user \n Enter new user's passportID \n"); //Add validation;
        var inputPassportId = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter new user's name \n");
        var inputName = Console.ReadLine();
        Console.Write("Enter new user's lastname \n");
        var inputLastname = Console.ReadLine();
        Console.Write("Enter new user's age \n");
        var inputAge = Convert.ToInt32(Console.ReadLine());
        var newUser = new User(inputPassportId, inputName, inputLastname, inputAge);
        return newUser;
    }
}
