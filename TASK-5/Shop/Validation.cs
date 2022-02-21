using System.Net.Http.Headers;

namespace Shop;

public class Validation
{
    public static bool SameUserIdChecker(User newUser, List<User> users)
    {
        foreach (var u in users)
        {
            if (u.passportID.Equals(newUser.passportID)) 
            {
                Console.Out.WriteLine("You are trying to add new User with same barcode");
                return false;
            }
        }
        return true;
    }

    public static bool AlcoholAgeChecker(User user, Goods goods)
    {
        if (!(user._age < 18 && (goods.category.Equals("Alcohol") || goods.itemName.Equals("Beer"))))
        {
            {
                Console.WriteLine($"{user._lastname} {user._name} cannot buy alcohol (age is under 18)");
            }
            return false;
        }

        return true; //redundant else was here
    }
    
}
