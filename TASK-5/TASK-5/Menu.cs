using Task_5.Generators;
using Task_5.Models;

namespace Task_5;

public class Menu
{
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
                    AddOneItemToBag(users);
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

    public static List<User> GenerateUsers(int count)
    {
        var users = new List<User>();
        for (var i = 0; i < count; i++) users.Add(UserGenerator.CreateUser());

        return users;
    }

    private static void DisplayEveryClient(List<User> usersContainer)
    {
        var counter = 0;
        Console.WriteLine();
        foreach (var user in usersContainer)
        {
            counter++;
            Console.WriteLine($"{counter}. {user.FullName} || Age is {user.Age} || ID is {user.PassportId}");
        }
    }

    private static void DisplayClientPurchases(List<User> users, int userNumber)
    {
        decimal totalPrice = 0;
        foreach (var items in users[userNumber - 1].GroceryBag)
        {
            Console.WriteLine($"{items.Barcode} || {items.Category} || {items.Price}$ || {items.ItemName}");
            totalPrice += items.Price;
        }

        Console.WriteLine($"Total: {totalPrice}$");
    }

    private static void DisplayClientPurchases(List<User> users)
    {
        decimal totalPrice = 0;
        string input;
        int itemNumber;
        do
        {
            Console.WriteLine("Please, enter User number (starts from 1): ");
            input = Console.ReadLine();
        } while (!int.TryParse(input, out itemNumber));

        foreach (var items in users[itemNumber - 1].GroceryBag)
        {
            Console.WriteLine($"{items.Barcode} || {items.Category} || {items.Price}$ || {items.ItemName}");
            totalPrice += items.Price;
        }

        Console.WriteLine($"Total: {totalPrice}$");
    }

    private static void GenerateUserFromConsole(List<User> users)
    {
        Console.WriteLine("Enter new user's ID");
        var userPassportIdInput = Console.ReadLine();
        Guid passportId;
        while (!Validation.InputValidation.GuidValidation(userPassportIdInput)
               || !Guid.TryParse(userPassportIdInput, out passportId))
        {
            Console.WriteLine("User's passport ID cannot be empty and it's length has to be 32 symbols");
            userPassportIdInput = Console.ReadLine();
        }

        if (Validation.SameIdChecker(passportId, users))
        {
            users.Add(UserGenerator.CreateUserUsingConsole(passportId));
            Console.WriteLine("You've added new user successfully");
        }
        else
        {
            Console.WriteLine("User cannot be added, this ID already exists");
        }
    }

    private static void AddOneItemToBag(List<User> users)
    {
        Console.WriteLine("Choose userNumber to add new item to");
        var userNumber = Convert.ToInt32(Console.ReadLine());
        DisplayClientPurchases(users, userNumber);
        Console.WriteLine("You are in a process of generating item:\n" +
                          " Please, enter 1 to add a non-alcohol item, 2 for an alcohol item only, \n" +
                          " enter 3 to generate item manually");
        var temporaryItem = Convert.ToInt32(Console.ReadLine()) switch
        {
            1 => ItemGenerator.GenerateItems()[0],
            2 => ItemGenerator.GenerateAlcoholItem(),
            3 => ItemGenerator.CreateItemManually(),
            _ => new Item()
        };

        if (Validation.AlcoholAgeChecker(users[userNumber - 1], temporaryItem))
            users[userNumber - 1].GroceryBag.Add(temporaryItem);

        Console.WriteLine($"{users[userNumber - 1].FullName}'s current purchases are: ");
        DisplayClientPurchases(users, userNumber);
    }

    private static void RemoveItemFromBag(List<User> users)
    {
        Console.WriteLine("Choose user, whose purchase you want to remove");
        var userNumber = Convert.ToInt32(Console.ReadLine());

        DisplayClientPurchases(users, userNumber);

        Console.WriteLine("Choose item you want to remove");
        var itemNumberToRemove = Convert.ToInt32(Console.ReadLine()) - 1;

        Console.WriteLine($"{users[userNumber - 1].FullName}'s purchase" +
                          $" {users[userNumber - 1].GroceryBag[itemNumberToRemove].ItemName} is removed");
        users[userNumber - 1].GroceryBag.RemoveAt(itemNumberToRemove);

        Console.WriteLine($"{users[userNumber - 1].FullName}'s current purchases are: ");
        DisplayClientPurchases(users, userNumber);
    }
}