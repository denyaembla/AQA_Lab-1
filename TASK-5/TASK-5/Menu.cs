using Task_5.Generators;
using Task_5.Models;

namespace Task_5;

public class Menu
{
    private static readonly Random _amount = new();
    
    public static void MainMenu(List<User> users)
    {
        
    }
    
    public static List<User> GenerateFiveUsersWithItems()
    {
        var shopContainer = new List<User>();
        for (var i = 0; i <= _amount.Next(5,5) ; i++)
        {
            shopContainer.Add(UserGenerator.GenerateUserWithItems());
        }
        
        return shopContainer;
    }
    
    public static void DisplayEveryClient(List<User> usersContainer)
    {
        foreach (var user in usersContainer)
        {
            Console.WriteLine($"{user.FullName} || Age is {user.Age} || ID is {user.PassportId}");
        }
    }

    public static void DisplayClientPurchases(List<User> users, int userNumber)
    {
        decimal totalPrice = 0;
        foreach (var items in users[userNumber].GroceryBag)
        {
            Console.WriteLine($"{items.Barcode} || {items.Category} || {items.Price} || {items.ItemName}");
            totalPrice += items.Price;
        }
        Console.WriteLine($"Total price is {decimal.Round(totalPrice)}$");
    }

    
    
    public static void DisplayItems(List<Item> itemBag)
    {
        Console.WriteLine("\n");
        foreach (var item in itemBag)
        { 
            Console.WriteLine($"ItemName {item.Barcode} || {item.Category}" +
                              $" || Barcode #{item.ItemName} || costs {item.Price}$");
        }
    }
    
    public static void GenerateUserFromConsole(List<User> users) 
    {
        Console.Write("You are going to create new user \n Enter new user's passportID \n"); //Add validation;
        var inputPassportId = Convert.ToInt32(Console.ReadLine());

        if (Validation.SameIdChecker(inputPassportId, users))
        {
            Console.Write("Enter new user's name \n");
            var inputName = Console.ReadLine();
            Console.Write("Enter new user's lastname \n");
            var inputLastname = Console.ReadLine();
            Console.Write("Enter new user's age \n");
            var inputAge = Convert.ToInt32(Console.ReadLine());
            var validNewUser = new User {PassportId = inputPassportId, 
                                            Age = inputAge, FullName = inputName + " " + inputLastname};
            users.Add(validNewUser);
            Console.Write("You've  added new user successfully");
        }
        
        Console.WriteLine("You've tried to generate User with already existing Id, user cannot be added");
    }
    
    
    

}
