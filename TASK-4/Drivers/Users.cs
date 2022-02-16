using Bogus;

namespace Drivers;

public abstract class Users
{


    public static string name;
    public static string lastname;
    public static DateOnly birthDateTime;
    public static bool isEligibleToDrive = true;

    public Users(string name, string lastname, DateOnly birthDateTime, bool isEligibleToDrive)
    {
    }
 
}
