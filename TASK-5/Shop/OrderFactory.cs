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

    
    public static List<Order> CreateFiveOrders(User user, List<Item> groceryBag)
    {
        var orderList = new List<Order>();
        for (int i = 1; i <= 5; i++)
        {
            orderList.Add(CreateOrder(UserFactory.GenerateUser(), GoodsGenerator.GenerateGroceryBag()));
        }
        return orderList;

    }

    public static void DisplayEveryUser(List<Order> orderList)
    {
        Console.WriteLine("User's list: \n");
        foreach (var everyOrder in orderList)
        {
           Console.WriteLine($"{everyOrder.User._name} {everyOrder.User._lastname}");
        }
    }

    public static void DisplayUsersPurchase(List<Order> orderList)
    {
        Console.WriteLine("Enter user's whose purchase you want to see (from 1 to 5)");
        var userChooser = Convert.ToInt32(Console.ReadLine()) - 1;
        GoodsGenerator.DisplayItems(orderList[userChooser].GroceryBag);
    }
}

