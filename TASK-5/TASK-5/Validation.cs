using System.Text.RegularExpressions;
using Task_5.Models;

namespace Task_5;

public class Validation
{
    public static bool SameIdChecker(Guid passportId, List<User> users)
    {
        foreach (var user in users)
        {
            if (user.PassportId.Equals(passportId))
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
            item.ItemName.Equals("Alcohol"))
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"{user.FullName} cannot buy alcohol (age is under 18)");
            Console.ResetColor();
            return false;
        }

        return true;
    }

    internal class InputValidation
    {
        private const string OnlyLettersPattern = "^[a-zA-Z]+$";
        private const string GuidPattern = @"\w{32}$";
        private const string AgePattern = @"^[1-9]{2}$";
        
      
        public static bool NameValidation(string input)
        {
            if (string.IsNullOrWhiteSpace(input) || !Regex.Match(
                    input, OnlyLettersPattern, RegexOptions.IgnoreCase).Success)
            {
                return false;
            }

            return true;
        }
        
        public static bool AgeValidation(string input)
        {
            if (string.IsNullOrWhiteSpace(input) || !Regex.Match(input, AgePattern).Success)
            {
                return false;
            }

            return true;
        }
        public static bool GuidValidation(string input)
        {
            if (string.IsNullOrWhiteSpace(input) || !Regex.Match(input, GuidPattern).Success)
            {
                return false;
            }

            return true;
        }
        

    }
}
