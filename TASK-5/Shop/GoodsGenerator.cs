using Bogus;

namespace Shop;

public class GoodsGenerator
{
    static List<Item> groceryBag = new();

    public static List<Item> GenerateGroceryBag()
    {
        for (int j = 1; j <= 5; j++)
        {
            groceryBag.Add(new Faker<Item>().CustomInstantiator(
                faker => new Item(
                    faker.Random.Int(50, 1500),
                    faker.PickRandomParam("Say sauce", " White Bread", "Cheese", "Milk", "Orange Juice", "Beer"),
                    faker.PickRandomParam("Bread", "Grocery", "Milk Products", "Juices", "Alcohol"),
                    faker.Random.Int(10, 25))));
        }

        return groceryBag;
    }

    public static void DisplayItems(List<Item> groceryBag)
    {
        foreach (var item in groceryBag)
        {
            Console.WriteLine($"ITEM: {item.itemName}, {item.category} ID {item.ID} and costs {item.price}$ \n");
        }
        
    }
}
