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

    
}


