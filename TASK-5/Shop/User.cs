using Bogus;

namespace Shop;

public class User
{
    public User(int passportId = default, string? name = null, string? lastname = null, int age = default)
    {
        passportID = passportId;
        _name = name;
        _lastname = lastname;
        _age = age;
    }


    public int counter = 1;
    public int passportID; /* WRITE get/set */
    public string? _name;
    public string? _lastname;
    public  int _age;
    
    
    List<User> usersContainer = new();
    
    
    public List<User> GenerateAndDisplayFiveUsers()
    {
        for (int i = 1; i <= 5; i++)
        {
            usersContainer.Add(new Faker<User>().CustomInstantiator(
                faker => new User(
                    counter++,
                    faker.Name.FirstName(),
                    faker.Name.LastName(),
                    faker.Random.Int(16, 35))));
            
        }
        return usersContainer;
    }

    public void DisplayUser()
    {
        Console.WriteLine($"{_name} {_lastname} with ID-{passportID} is {_age} years old.");
    }
    
}
