namespace Task_6.Models;

public class Shop
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Phone> PhonesList { get; set; }
}