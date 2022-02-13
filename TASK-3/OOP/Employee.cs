using Bogus;

namespace OOP;

public class Employee : IDisplay
{
    public Guid ID = Guid.NewGuid();
    public string lastname { get; }
    public string name { get; }
    public string jobTitle { get; }
    public string companyName { get; }
    public string companyCountry { get; }
    public string companyCity { get; }
    public string companyStreet { get; }
    public int salary { get; }
    public Employee(Guid id, string lastname, string name, string jobTitle, string companyName,
                    string companyCountry, string companyCity, string companyStreet, int salary)
    {
        
        this.lastname = lastname;
        this.name = name;
        this.jobTitle = jobTitle;
        this.companyName = companyName;
        this.companyCountry = companyCountry;
        this.companyCity = companyCity;
        this.companyStreet = companyStreet;
        this.salary = salary;
    }

    public void Display()
    {
        Console.WriteLine($"I am {name + " " + lastname}, {jobTitle}, in {companyName}, " + 
                          $"{companyCountry}, {companyCity} town, {companyStreet} street," +
                          $" and my salary is {salary}. My ID number is {ID}");
    }

}
