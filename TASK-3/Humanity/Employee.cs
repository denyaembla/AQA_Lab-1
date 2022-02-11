using Bogus;

namespace Humanity;

public class Employee : IDisplay
{
    public Guid id = Guid.NewGuid();
    public string _lastname;
    public string _name;
    public string _jobTitle;
    public double _salary;
    public string _companyName;
    public string _companyCountry;
    public string _companyCity;
    public string _companyStreet;


    public Employee(Guid id, string lastname, string name, string jobTitle,
        double salary, string companyName, string companyCountry, string companyCity, string companyStreet)
    {
        
        this.Lastname = lastname;
        this.Name = name;
        this.JobTitle = jobTitle;
        this.Salary = salary;
        this.CompanyName = companyName;
        this.CompanyCountry = companyCountry;
        this.CompanyCity = companyCity;
        this.CompanyStreet = companyStreet;
    }

    public string Lastname
    {
        get => _lastname;
        set => _lastname = value;
    }

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public string JobTitle
    {
        get => _jobTitle;
        set => _jobTitle = value;
    }

    public double Salary
    {
        get => _salary;
        set => _salary = value;
    }

    public string CompanyName
    {
        get => _companyName;
        set => _companyName = value;
    }

    public string CompanyCountry
    {
        get => _companyCountry;
        set => _companyCountry = value;
    }

    public string CompanyCity
    {
        get => _companyCity;
        set => _companyCity = value;
    }

    public string CompanyStreet
    {
        get => _companyStreet;
        set => _companyStreet = value;
    }

    public Guid Id
    {
        get => id;
        set => id = value;
    }

    public void Display()
    {
        Console.WriteLine($"I am {Name + " " + Lastname}, {JobTitle}, in {CompanyName}, " + 
                          $"{CompanyCountry}, {CompanyCity} town, {CompanyStreet} street," +
                          $" and my salary is {Salary}. My ID number is {id}");
    }

    public void GenerateEmployees()
    {
        var employeesList = new List<Employee>(); /*have to create an interface for both classes */
        var count = new Random();
        var randomSalary = new Random();
        for (var i = 0; i < count.Next(2,5); i++)
        {
            employeesList.Add(new Faker<Employee>().CustomInstantiator(fake => new Employee(
                new Guid(),
                fake.Name.LastName(),
                fake.Name.FirstName(),
                fake.Name.JobTitle(),
                randomSalary.Next(500, 2500),
                fake.Company.CompanyName(),
                fake.Address.Country(),
                fake.Address.City(),
                fake.Address.StreetAddress())));
        }
    }
}
