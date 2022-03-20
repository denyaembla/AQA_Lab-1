using System.Collections;

namespace Task_4.Models;

public class Candidate : IDisplay, IUser
{
    public Guid Id { get; set; }
    public string Lastname { get; set; }
    public string Name { get; set; }
    public string DesiredJobPosition { get; set; }
    public string DesiredJobDescription { get; set; }
    public decimal DesiredSalary { get; set; }
    public void Display()
    {
        Console.WriteLine($"I am {Lastname} {Name}. I want to be a {DesiredJobPosition} at " +
                          $" {DesiredJobDescription}, with a salary of {DesiredSalary} . My ID number is {Id}");
    }
    
}
