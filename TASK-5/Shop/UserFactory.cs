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
                counter++,
                faker.Name.FirstName(),
                faker.Name.LastName(),
                faker.Random.Int(16, 35)));
        return user;
    }
   
    public static void DisplayUser(User user)
    {
        Console.WriteLine($"{user._name} {user._lastname} with ID-{user.passportID} is {user._age} years old.");
    }
    
}
