using Bogus;

namespace Shop;

public class User
{
    public User(int passportId, string? name, string? lastname, int age)
    {
        passportID = passportId;
        _name = name;
        _lastname = lastname;
        _age = age;
    }
   
    public int passportID; /* WRITE get/set */
    public string? _name;
    public string? _lastname;
    public  int _age;
    
    
   

    
    
    
}
