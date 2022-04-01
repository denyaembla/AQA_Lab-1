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

    public static Item GenerateItem()
    {
        var item = new Faker<Item>().CustomInstantiator(f => new Item())
            .RuleFor(item => item.Barcode, (f, item) => f.Random.Int(
                BarcodeMinimumValue, BarcodeMaximumValue))
            .RuleFor(item => item.Category, (f, item) => f.Commerce.ProductName())
            .RuleFor(item => item.ItemName, (f, item) => f.Commerce.Product())
            .RuleFor(item => item.Price, (f, item) => decimal.Round(f.Random.Decimal(
                MinimumPrice, MaximumPrice), 2));

        return item.Generate();
    }

    internal static List<Item> GenerateItems(int count)
    {
        var itemBag = new List<Item>();
        for (var i = 0; i < count; i++)
        {
            itemBag.Add(GenerateItem());
        }

        return itemBag;
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
}
