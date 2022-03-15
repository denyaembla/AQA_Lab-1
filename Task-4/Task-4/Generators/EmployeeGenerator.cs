using Bogus;
using Task_4.Models;

namespace Task_4.Generators;

public class EmployeeGenerator : Employee
{
    protected static List<Employee> EmployeeContainer = new();
    private static Random Count = new();
    private const decimal MinimumSalary = 1000;
    private const decimal MaximumSalary = 2500;


    private static Employee GenerateEmployee()
    {
        var employee = new Faker<Employee>()
                .RuleFor(e => e.Id, Guid.NewGuid)
                .RuleFor(e => e.Name, f => f.Person.FirstName)
                .RuleFor(e => e.Lastname, f => f.Person.LastName)
                .RuleFor(e => e.JobTitle, f => f.Name.JobTitle())
                .RuleFor(e => e.Salary, f => f.Finance.Amount(MinimumSalary, MaximumSalary))
                .RuleFor(e => e.CompanyName, f => f.Company.CompanyName())
                .RuleFor(e => e.CompanyCountry, f => f.Address.Country())
                .RuleFor(e => e.CompanyCity, f => f.Address.City())
                .RuleFor(e => e.CompanyStreet, f => f.Address.StreetAddress());
        
            return employee.Generate();
    }

    public static void AddEmployee()
    {
        EmployeeContainer.Add(GenerateEmployee());
    }
    public static void GenerateAFewEmployees()
    {
        for (var i = 0; i < Count.Next(minValue: 2, maxValue: 4); i++)
        {
            AddEmployee();
        }
    }
}
