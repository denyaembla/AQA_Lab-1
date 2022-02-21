using System.Runtime.InteropServices;
using Bogus;
namespace Shop;

public class Goods
{
    public Goods(int barcode = default, string? itemName = null, string? category = null, decimal price = default)
    {
        this.barcode = barcode;
        this.itemName = itemName;
        this.category = category;
        this.price = price;
    }

    public int barcode;
    public string? itemName;
    public string category;
    public decimal price;

    
}


