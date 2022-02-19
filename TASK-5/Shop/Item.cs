using System.Runtime.InteropServices;
using Bogus;
namespace Shop;

public class Item
{
    public Item(int id = default, string? itemName = null, string? category = null, decimal price = default)
    {
        ID = id;
        this.itemName = itemName;
        this.category = category;
        this.price = price;
    }

    public int ID;
    public string? itemName;
    public string category;
    public decimal price;

    List<Item> groceryBag = new();
    public List<Item> GenerateGroceryBag()
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

    public void DisplayItems()
    {
        Console.WriteLine($"ITEM: {itemName}, {category} ID {ID} and costs {price}$ \n");
    }
}

