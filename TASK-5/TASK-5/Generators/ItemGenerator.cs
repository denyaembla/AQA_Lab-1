using Bogus;
using Task_5.Models;

namespace Task_5.Generators;

public class ItemGenerator
{
    private static readonly int BarcodeMinimumValue = 1000;
    private static readonly int BarcodeMaximumValue = 9999;
    private static readonly decimal MinimumPrice = 0.7M;
    private static readonly decimal MaximumPrice = 5M;
    private const string Alcohol = "Alcohol";
    private static Random count = new Random();
    private const int MinimumAmountOfItems = 1;
    private const int MaximumAmountOfItems = 5;

    public static List<Item> GenerateItems()
    {
        var items = new List<Item>();

        for (var i = 0; i < count.Next(MinimumAmountOfItems, MaximumAmountOfItems); i++)
        {
            items.Add(
                new Faker<Item>().CustomInstantiator(f => new Item())
                    .RuleFor(item => item.Barcode, (f, item) => f.Random.Int(
                        BarcodeMinimumValue, BarcodeMaximumValue))
                    .RuleFor(item => item.Category, (f, item) => f.Commerce.ProductName())
                    .RuleFor(item => item.ItemName, (f, item) => f.Commerce.Product())
                    .RuleFor(item => item.Price, (f, item) => decimal.Round(f.Random.Decimal(
                        MinimumPrice, MaximumPrice), 2))
            );
        }
        
        return items;
    }
   
    public static Item GenerateAlcoholItem()
    {
        var item = new Faker<Item>().CustomInstantiator(f => new Item())
            .RuleFor(item => item.Barcode, (f, item) => f.Random.Int(
                BarcodeMinimumValue, BarcodeMaximumValue))
            .RuleFor(item => item.Category, (f, item) => f.Commerce.ProductMaterial())
            .RuleFor(item => item.ItemName, (f, item) => Alcohol)
            .RuleFor(item => item.Price, (f, item) => decimal.Round(
                                                    f.Random.Decimal(MinimumPrice, MaximumPrice), 2));

        return item.Generate();
    }

    public static Item CreateItemManually()
    {
        Console.Write("Enter new item's barcode \n");
        var inputBarcode = Console.ReadLine();
        int barcode;
        while (string.IsNullOrWhiteSpace(inputBarcode) || !int.TryParse(inputBarcode, out barcode))
        {
            Console.WriteLine("Item's barcode have to contain digits only and cannot be empty.");
            inputBarcode = Console.ReadLine();
        }
        
        Console.Write("Enter new item's name \n");
        var inputItemName = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(inputItemName))
        {
            Console.WriteLine("Item's name cannot be empty.");
            inputItemName = Console.ReadLine();
        }
        
        Console.Write("Enter new item's category \n");
        var inputCategory = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(inputCategory) || inputCategory.Any(char.IsDigit))
        {
            Console.WriteLine("Item's barcode have to contain letters only and cannot be empty.");
            inputCategory = Console.ReadLine();
        }
        
        Console.Write("Enter new item's price \n");
        var inputPrice = Console.ReadLine();
        decimal price;
        while (inputPrice == null || !decimal.TryParse(inputPrice, out price))
        {
            Console.WriteLine("User's age cannot contain letters or be empty.");
            inputPrice = Console.ReadLine();
        }
        
        var item = new Item
        {
            Barcode = barcode,
            ItemName = inputItemName,
            Category = inputCategory,
            Price = price
        };
       return item;
    }
}
