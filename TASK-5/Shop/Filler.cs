using Shop.Models;

namespace Shop;

public static class Filler
{

    public static void FillEveryUserBagRandomly(List<User> usersContainer)
    {
        foreach (var u in usersContainer)
        {
            u.GroceryBag = new List<Item>(ItemsGenerator.GenerateFewItemsGroceryBag());
        }
        
    }

    public static void AddOneItemToBagFromConsole()
    {
        Console.WriteLine("Please, choose USER NUMBER to add item to his bag");
        var userNumber = Convert.ToInt32(Console.ReadLine()) - 1;
        
            Console.Write("You are going to add new Item");
            Console.Write("Enter item's name \n");
            var inputItemName = Console.ReadLine();
            Console.Write("Enter item's name/type \n");
            var inputCategory = Console.ReadLine();
            Console.Write("Enter new item's barcode \n");
            var inputBarcode = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter item's price \n");
            var inputPrice = Convert.ToInt32(Console.ReadLine());
            var newItem = new Item(inputBarcode, inputItemName, inputCategory, inputPrice);
            if (Validation.AlcoholAgeChecker(UserFactory.UsersContainer[userNumber], newItem))
            {
                UserFactory.UsersContainer[userNumber].GroceryBag.Add(newItem);
            }
            else
            {
                throw new Exception("User is too young to buy alcohol");
            }
    }
    
    
    

    public static void DisplayPurchaseOfEveryUser(List<User> result)
    {
        foreach (var user in result)
        {
            UserFactory.DisplayUser(user);
            ItemsGenerator.DisplayItems(user.GroceryBag);
        }
    }
    
    public static void DisplayUserAndHisBag()
    {
        Console.WriteLine("Enter user number whose purchases you want to see (from 1 to 5)");
        var userChooser = Convert.ToInt32(Console.ReadLine()) - 1;
        var user = UserFactory.UsersContainer[userChooser];
        UserFactory.DisplayUser(user);
        ItemsGenerator.DisplayItems(user.GroceryBag);
    }
    
   
    
    public static void DeleteFromTheBag(List<Item> groceryBag, int selectedProductIndex)
    {
        groceryBag.RemoveAt(selectedProductIndex);
    }
}

