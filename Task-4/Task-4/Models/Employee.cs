using System.Collections;

namespace Task_4.Models;

public class Employee : IDisplay, IUser
{
    public Guid Id { get; set; }
    public string Lastname { get; set; }
    public string Name { get; set; }
    public string JobTitle { get; set; }
    public string CompanyName { get; set; }
    public string CompanyCountry { get; set; }
    public string CompanyCity { get; set; }
    public string CompanyStreet { get; set; }
    public decimal Salary { get; set; }
    
    public void Display()
    {
        Console.WriteLine($"I am {Name + " " + Lastname}, {JobTitle}, I am employee in {CompanyName}, " + 
                          $"{CompanyCountry}, {CompanyCity} town, {CompanyStreet} street," +
                          $" and my salary is {Salary}. My ID number is {Id}");
    }
    
}
