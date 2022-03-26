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
        for (var i = 0; i < _amount.Next(5,5) ; i++)
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
        Console.WriteLine($"Total: {totalPrice}$");
    }

    
    
    public static void DisplayItems(List<Item> itemBag)     //why am i not using this
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
        Console.Write("You are going to create new user \n Enter new user's passportID \n");
        var inputPassportId = Convert.ToInt32(Console.ReadLine()) - 1;

        if (Validation.SameIdChecker(inputPassportId, users))
        {
            users.Add(UserGenerator.GenerateUserFromConsole(inputPassportId));
            Console.WriteLine("You've  added new user successfully");
        }
        else
        {
            Console.WriteLine("You've tried to generate User with already existing Id, user cannot be added");
        }
    }

    public static void DeleteItemFromBag(List<User> users)
    {
         Console.WriteLine("Choose user, whose purchase you want to remove");
         var userNumber = Convert.ToInt32(Console.ReadLine()) + 1;
         
         DisplayClientPurchases(users, userNumber);
         
         Console.WriteLine("Choose item you want to remove");
         var itemNumberToRemove = Convert.ToInt32(Console.ReadLine()) + 1;
         
         Console.WriteLine($"{users[userNumber].FullName}'s purchase" +
                           $" {users[userNumber].GroceryBag[itemNumberToRemove].ItemName} is removed");
         users[userNumber].GroceryBag.RemoveAt(itemNumberToRemove);
         
         Console.WriteLine($"{users[userNumber].FullName}'s current purchases are: ");
         DisplayClientPurchases(users, userNumber);
    }

    public static void AddItemToBag(List<User> users)
    {
        Console.WriteLine("Choose userNumber to add new item to");
        var userNumber = Convert.ToInt32(Console.ReadLine());
        DisplayClientPurchases(users, userNumber);
        Console.WriteLine("You are generating item:\n Please, enter 1 to randomize item (can be beer), 2 for beer only");
        var temporaryItem = new Item();
        switch (Convert.ToInt32(Console.ReadLine()))
        {
            case 1:
                temporaryItem = ItemGenerator.GenerateItem();
                break;
            case 2:
                temporaryItem = ItemGenerator.GenerateBeer();
                break;
        }

        if (Validation.AlcoholAgeChecker(users[userNumber], temporaryItem))
        {
            users[userNumber].GroceryBag.Add(temporaryItem);
        }
        
        Console.WriteLine($"{users[userNumber].FullName}'s current purchases are: ");
        DisplayClientPurchases(users, userNumber);
    }
}
