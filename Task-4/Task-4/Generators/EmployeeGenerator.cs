using Bogus;
using Task_4.Models;

namespace Task_4.Generators;

public class EmployeeGenerator : Employee
{
    public static List<Employee> employeeContainer = new();
    public static Random count = new();
    public static Random randomSalary = new();

    public static Employee GenerateEmployee()
    {
        var employee = new Faker<Employee>()
                .RuleFor(e => e.Id, Guid.NewGuid)
                .RuleFor(e => e.Name, f => f.Person.FirstName)
                .RuleFor(e => e.Lastname, f => f.Person.LastName)
                .RuleFor(e => e.JobTitle, f => f.Name.JobTitle())
                .RuleFor(e => e.Salary, f => f.Finance.Amount())
                .RuleFor(e => e.CompanyName, f => f.Company.CompanyName())
                .RuleFor(e => e.CompanyCountry, f => f.Address.Country())
                .RuleFor(e => e.CompanyCity, f => f.Address.City())
                .RuleFor(e => e.CompanyStreet, f => f.Address.StreetAddress());
        
            return employee.Generate();
    }

    public static void AddEmployee()
    {
        employeeContainer.Add(GenerateEmployee());
    }
    public static void GenerateAFewEmployees()
    {
        for (var i = 0; i < count.Next(minValue: 3, maxValue: 3); i++)
        {
            AddEmployee();
        }
    }
}
