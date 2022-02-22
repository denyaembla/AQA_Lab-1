using Bogus;

namespace Shop;

public static class ItemsGenerator
{
    static List<Item> groceryBag = new();

    public static List<Item> GenerateFewItemsGroceryBag()
    {
        for (int i = 1; i <= 2; i++)
        {
            groceryBag.Add(new Faker<Item>().CustomInstantiator(
                faker => new Item(
                    faker.Random.Int(50, 1500),
                    faker.PickRandomParam("Say sauce",
                        "White Bread", "Cheese", "Milk", "Orange Juice", "Beer"),
                    faker.PickRandomParam("Bread", "Grocery",
                        "Milk Products", "Juices", "Alcohol"),
                    faker.Random.Int(10, 25))));
        }

        return groceryBag;
    }

    public static Item AddOneItemFromConsole()
    {
        Console.Write("You are going to create new Item \nEnter new item's barcode \n"); //Add validation for input;
        var inputBarcode = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter item's name \n");
        var inputItemName = Console.ReadLine();
        Console.Write("Enter item's name/type \n");
        var inputCategory = Console.ReadLine();
        Console.Write("Enter item's price \n");
        var inputPrice = Convert.ToInt32(Console.ReadLine());
        var newGood = new Item(inputBarcode, inputItemName, inputCategory, inputPrice);
        return newGood;
    }
    
    public static List<Item> AddToGroceryBagFromConsole()
    {
        groceryBag.Add(AddOneItemFromConsole()); //дописать собирание в ордер;
        return groceryBag;
    }
    
    public static void DisplayItems(List<Item> groceryBag)
    {
        Console.WriteLine("\n");
        foreach (var item in groceryBag)
        { 
            Console.WriteLine($"ITEM: {item.itemName}, {item.category}, barcode #{item.barcode}, costs {item.price}$");
        }
        
    }
}
