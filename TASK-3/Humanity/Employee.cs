namespace Humanity;

public class Employee : IDisplay
{
    private Guid _id = new();
    private string _lastname;
    private string _name;
    private string _jobTitle;
    private double _salary;
    private string _companyName;
    private string _companyCountry;
    private string _companyCity;
    private string _companyStreet;


    public Employee(string lastname, string name, string jobTitle, double salary, string companyName, string companyCountry, string companyCity, string companyStreet)
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

    public void Display()
    {
        Console.WriteLine($"I am {Name + " " + Lastname}, {JobTitle}, in {CompanyName}, " + 
                          $"{CompanyCountry}, {CompanyCity} town, {CompanyStreet} street," +
                          $" and my salary is {Salary}. My ID number is {_id}");
    }

}
