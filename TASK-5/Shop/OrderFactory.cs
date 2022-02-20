namespace Shop;

public class OrderFactory
{
    //List<Item> itemCollection;
    public static Order CreateOrder(User user, List<Item> groceryBag)
    {
        var order = new Order(user, groceryBag);
        return order;
    }
    public static void DisplayOrder(Order order)
    {
        UserFactory.DisplayUser(order.User);
        GoodsGenerator.DisplayItems(order.GroceryBag);
    }
}

