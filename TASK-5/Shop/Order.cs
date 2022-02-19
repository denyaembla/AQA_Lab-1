namespace Shop;

public class Order
{
    public Order(User user = null, List<Item> items = null)
    {
        User = user;
        this.items = items;
    }

    public User User;
    public List<Item> items;

    public void AlcoholCheck(User user, Item item)
    {
        if (User._age < 18 && (item.category == "Alcohol" || item.itemName == "Beer"))
        {
            item.itemName = null;
            item.category = null;
            Console.WriteLine("This user is too young to buy alcohol, item was taken away");
        }
    }
}
