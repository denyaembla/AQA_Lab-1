namespace Shop;

public class Order
{
    public Order(User user, List<Goods> groceryBag)
    {
        this.user = user;
        this.groceryBag = groceryBag;
        orderID++;
    }

    private User user;
    private List<Goods> groceryBag;
    private static int orderID = 1;
    public User User
    {
        get => user;
        set => user = value ?? throw new ArgumentNullException(nameof(value));
    }

    public List<Goods> GroceryBag
    {
        get => groceryBag;
        set => groceryBag = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int Id
    {
        get => orderID;
        set => orderID = value;
    }

    
}
