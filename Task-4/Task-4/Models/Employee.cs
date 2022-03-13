namespace Task_4.Models;

public class Employee
{
    public Guid Id = Guid.NewGuid();
    public string Lastname { get; }
    public string Name { get; }
    public string JobTitle { get; }
    public string CompanyName { get; }
    public string CompanyCountry { get; }
    public string CompanyCity { get; }
    public string CompanyStreet { get; }
    public int Salary { get; }
    public Employee(Guid id, string lastname, string name, string jobTitle, string companyName,
        string companyCountry, string companyCity, string companyStreet, int salary)
    {
        
        Lastname = lastname;
        Name = name;
        JobTitle = jobTitle;
        CompanyName = companyName;
        CompanyCountry = companyCountry;
        CompanyCity = companyCity;
        CompanyStreet = companyStreet;
        Salary = salary;
    }

    public void Display()
    {
        Console.WriteLine($"I am {Name + " " + Lastname}, {JobTitle}, I am employee in {CompanyName}, " + 
                          $"{CompanyCountry}, {CompanyCity} town, {CompanyStreet} street," +
                          $" and my salary is {Salary}. My ID number is {Id}");
    }
}
