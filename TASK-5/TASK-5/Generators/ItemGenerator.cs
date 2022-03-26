using Bogus;
using Task_5.Models;

namespace Task_5.Generators;

public class ItemGenerator
{
    private static readonly int BarcodeMinimumValue = 1000;
    private static readonly int BarcodeMaximumValue = 9999;
    private static readonly decimal MinimumPrice = 0.7M;
    private static readonly decimal MaximumPrice = 5M;
    private static readonly string[] ItemNames = {"juice", "milk", "ice-cream", "beer", "bread"};
    

    public static Item GenerateItem()
    {
        var item = new Faker<Item>().CustomInstantiator(f => new Item())
            .RuleFor(item => item.Barcode, (f, item) => f.Random.Int(
                BarcodeMinimumValue, BarcodeMaximumValue))
            .RuleFor(item => item.Category, (f, item) => f.Commerce.ProductMaterial())
            .RuleFor(item => item.ItemName, (f, item) => f.PickRandomParam(ItemNames))
            .RuleFor(item => item.Price, (f, item) => f.Random.Decimal(MinimumPrice, MaximumPrice));

        return item.Generate();
    }

    public static List<Item> GenerateItems()
    {
        var itemBag = new List<Item>();
        for (var i = 0; i < 4; i++)
        {
            itemBag.Add(GenerateItem());
        }

        return itemBag;
    }
}
