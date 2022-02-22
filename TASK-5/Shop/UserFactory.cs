using Bogus;

namespace Shop;

public class UserFactory
{
    public static int counter = 1;
    static List<User> usersContainer = new();
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
    
    public static List<User> GenerateRandomAmountOfUsers()        //Adds random amount of users to usersContainer in form of another list<User>;
    {
        var randomAmount = new Random();
        var amount = Convert.ToInt32(randomAmount.Next(2, 2));
        for (int i = 1; i <= amount; i++)        //without random while testing;
        {
            usersContainer.Add(new Faker<User>().CustomInstantiator(
                faker => new User(
                    counter++,          //assignment of ID as a counter (1-2-3-4-5).
                    faker.Name.FirstName(),
                    faker.Name.LastName(),
                    faker.Random.Int(16, 35))));
        }
        return usersContainer;
    }
    public static User GenerateUserFromConsole()
    {
        Console.Write("You are going to create new user \n Enter new user's passportID \n"); //Add validation;
        var inputPassportId = Convert.ToInt32(Console.ReadLine());

        if (Validation.SameIdChecker(inputPassportId, usersContainer))
        {
            Console.Write("Enter new user's name \n");
            var inputName = Console.ReadLine();
            Console.Write("Enter new user's lastname \n");
            var inputLastname = Console.ReadLine();
            Console.Write("Enter new user's age \n");
            var inputAge = Convert.ToInt32(Console.ReadLine());
            var newUser = new User(inputPassportId, inputName, inputLastname, inputAge);
            return newUser;
        }

        throw new Exception("User with this passport ID already exists");
    }
    
    
    public static List<User> AddNewUserToContainer(User user)
    {
        usersContainer.Add(user);
        return usersContainer;
    }

    public static void DisplayUser(User user)
    {
        Console.WriteLine($"{user._name} {user._lastname} with ID-{user.passportID} is {user._age} years old.");
    }
    public static void DisplayEveryUser()
    {
        foreach (var u in usersContainer)
        {
            DisplayUser(u);
        }
    }
    
    
}
