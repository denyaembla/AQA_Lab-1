using System.Net.Http.Headers;

namespace Shop;

public class Validation
{
    public static bool SameIdChecker(int passportID, List<User> users)
    {
        foreach (var u in users)
        {
            if (u.passportID.Equals(passportID))
            {
                Console.Out.WriteLine("You are trying to add new User with same passportID");
                return false;
            }
        }
        return true;
    }

    public static bool AlcoholAgeChecker(User user, Item item) // Add to ORder;
    {
        if (!(user._age < 18 && (item.category.Equals("Alcohol") || item.itemName.Equals("Beer"))))
        {
            {
                Console.WriteLine($"{user._lastname} {user._name} cannot buy alcohol (age is under 18)");
            }
            return false;
        }

        return true; //redundant else was here
    }
    
}
