using Task_5.Generators;
using Task_5.Models;

namespace Task_5;

public class Menu
{
    private static readonly Random _amount = new();
    
    public static void MainMenu(List<User> users)
    {
        var exit = true;
        while (exit)
        {
            Console.WriteLine();
            Console.WriteLine("You are in Main Menu, you can do: \n" +
                              "1. Display every user.\n" +
                              "2. Display user's goods with total cost.\n" +
                              "3. Add new user from the console.\n" +
                              "4. Add goods to user's bag.\n" +
                              "5. Remove goods from user's bag.\n" +
                              "To exit, press any number, except number above (0, for example)");
            string input;
            int menuItem;
            do
            {
                Console.Write("Please, enter option number: ");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out menuItem));

            switch (menuItem)
            {
                case 1:
                    DisplayEveryClient(users);
                    break;
                case 2:
                    DisplayClientPurchases(users);
                    break;
                case 3:
                    GenerateUserFromConsole(users);
                    break;
                case 4:
                    AddItemToBag(users);
                    break;
                case 5:
                    RemoveItemFromBag(users);
                    break;
                default:
                    exit = false;
                    break;
            }
        }
    }

    public static List<User> GenerateFiveUsers()
    {
        var users = new List<User>();
        for (int i = 0; i < 5; i++)
        {
            users.Add(UserGenerator.GenerateUserWithItems());
        }
        
        return users;
    }

    private static void DisplayEveryClient(List<User> usersContainer)
    {
        Console.WriteLine();
        foreach (var user in usersContainer)
        {
            Console.WriteLine($"{user.FullName} || Age is {user.Age} || ID is {user.PassportId}");
        }
    }

    private static void DisplayClientPurchases(List<User> users, int userNumber)        //counting from 1;
    {
        decimal totalPrice = 0;
        foreach (var items in users[userNumber-1].GroceryBag)
        {
            Console.WriteLine($"{items.Barcode} || {items.Category} || {items.Price} || {items.ItemName}");
            totalPrice += items.Price;
        }
        Console.WriteLine($"Total: {totalPrice}$");
    }
    
    private static void DisplayClientPurchases(List<User> users)            //overload with manual number input
    {
        decimal totalPrice = 0;
        string input;
        int itemNumber;
        do
        {
            Console.WriteLine("Please, enter User number (starts from 1): ");
            input = Console.ReadLine();
        } while (!int.TryParse(input, out itemNumber));
        
        foreach (var items in users[itemNumber-1].GroceryBag)
        {
            Console.WriteLine($"{items.Barcode} || {items.Category} || {items.Price} || {items.ItemName}");
            totalPrice += items.Price;
        }
        Console.WriteLine($"Total: {totalPrice}$");
    }
   
    private static void DisplayItems(List<Item> itemBag)     //why am i not using this???
    {
        Console.WriteLine("\n");
        foreach (var item in itemBag)
        { 
            Console.WriteLine($"ItemName {item.Barcode} || {item.Category}" +
                              $" || Barcode #{item.ItemName} || costs {item.Price}$");
        }
    }
    
    private static void GenerateUserFromConsole(List<User> users) 
    {
        Console.Write("You are going to create new user \n Enter new user's passportID \n");
        var inputPassportId = Convert.ToInt32(Console.ReadLine());

        if (Validation.SameIdChecker(inputPassportId, users))
        {
            users.Add(UserGenerator.GenerateUserFromConsole(inputPassportId));
            Console.WriteLine("You've added new user successfully");
        }
        else
        {
            Console.WriteLine("User cannot be added");
        }
    }

    

    private static void AddItemToBag(List<User> users)
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

        if (Validation.AlcoholAgeChecker(users[userNumber-1], temporaryItem))
        {
            users[userNumber-1].GroceryBag.Add(temporaryItem);
        }
        
        Console.WriteLine($"{users[userNumber-1].FullName}'s current purchases are: ");
        DisplayClientPurchases(users, userNumber);
    }
    
    private static void RemoveItemFromBag(List<User> users)
    {
        Console.WriteLine("Choose user, whose purchase you want to remove");
        var userNumber = Convert.ToInt32(Console.ReadLine());
         
        DisplayClientPurchases(users, userNumber);
         
        Console.WriteLine("Choose item you want to remove");
        var itemNumberToRemove = Convert.ToInt32(Console.ReadLine()) - 1;
         
        Console.WriteLine($"{users[userNumber-1].FullName}'s purchase" +
                          $" {users[userNumber-1].GroceryBag[itemNumberToRemove].ItemName} is removed");
        users[userNumber-1].GroceryBag.RemoveAt(itemNumberToRemove);
         
        Console.WriteLine($"{users[userNumber-1].FullName}'s current purchases are: ");
        DisplayClientPurchases(users, userNumber);
    }
}
