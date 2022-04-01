namespace Task_5.Models;

public class User
{
    public Guid PassportId { get; set; }
    public string FullName { get; set; }
    public int Age { get; set; }
    public List<Item> GroceryBag { get; set; }
}
