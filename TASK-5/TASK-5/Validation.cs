using Task_5.Models;

namespace Task_5;

public class Validation
{
    public static bool SameIdChecker(int passportId, List<User> users)
    {
        foreach (var u in users)
        {
            if (u.PassportId.Equals(passportId))
            {
                Console.Out.WriteLine("You are trying to add new User with same passportID");
                return false;
            }
        }

        return true;
    }

    public static bool AlcoholAgeChecker(User user, Item item)
    {
        if (user.Age < 18 &&
            item.ItemName.Equals("** BEER **"))
        {
            Console.WriteLine($"{user.FullName} cannot buy alcohol (age is under 18)");
            return false;
        }

        return true;
    }
}
