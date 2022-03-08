using Bogus;
using Shop.Models;

namespace Shop;

public static class ItemsGenerator
{
    public static List<Item> groceryBag = new();

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
  
    public static void DisplayItems(List<Item> groceryBag)
    {
        Console.WriteLine("\n");
        foreach (var item in groceryBag)
        { 
            Console.WriteLine($"ITEM: {item.ItemName}, {item.Category}, barcode #{item.Barcode}, costs {item.Price}$");
        }
        
    }
}
