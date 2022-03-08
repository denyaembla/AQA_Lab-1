namespace Shop.Models;

public class Item
{
    public Item(int barcode = 0, string? itemName = "default", string? category = "default", decimal price = 0)
    {
        Barcode = barcode;
        ItemName = itemName;
        Category = category;
        Price = price;
        
    }

    public int Barcode;
    public string? ItemName;
    public string? Category;
    public decimal Price;
    
}


