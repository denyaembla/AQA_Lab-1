namespace Shop.Models;

public class User
{
    public User(int passportId, string? name, string? lastname, int age)
    {
        PassportId = passportId;
        Name = name;
        Lastname = lastname;
        Age = age;
    }
   
    public int PassportId;
    public string? Name;
    public string? Lastname;
    public int Age;
    public List<Item> GroceryBag;







}
