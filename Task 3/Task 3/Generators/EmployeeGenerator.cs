using Bogus;
using Task_3.Models;

namespace Task_3.Generators;

public class EmployeeGenerator : Employee
{
    public EmployeeGenerator(Guid id, string lastname, string name, string jobTitle,
        string companyName, string companyCountry, string companyCity, string companyStreet, int salary) :
        base(id,  lastname,  name,  jobTitle,  companyName,  companyCountry,
            companyCity,  companyStreet,  salary)
    {
        
    }
    public static List<Employee> employeeContainer = new();
    public static Random count = new();
    public static Random randomSalary = new();

    public static void GenerateOneEmployee()
    {
        employeeContainer.Add(new Faker<Employee>().CustomInstantiator(fake => new Employee(
            new Guid(),
            fake.Name.LastName(),
            fake.Name.FindName(),
            fake.Name.JobTitle(),
            fake.Company.CompanyName(),
            fake.Address.Country(),
            fake.Address.City(),
            fake.Address.StreetAddress(),
            randomSalary.Next(500, 2500))));
    }
    public static void GenerateAFewEmployees()
    {
        for (var i = 0; i < count.Next(minValue: 3, maxValue: 3); i++)
        {
            GenerateOneEmployee();
        }
    }
}
