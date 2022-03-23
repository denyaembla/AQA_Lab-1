using Bogus;
using Task_4.Models;

namespace Task_4.Generators;

public class EmployeeGenerator : Employee
{
    internal static readonly Random RandomAmountToGenerate = new();
    public const decimal MinimumSalary = 1000;
    public const decimal MaximumSalary = 2500;

    public static Employee GenerateEmployee()
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

    public static List<IUser> GenerateAFewEmployees()
    {
        var employeeList = new List<IUser>();
        for (var i = 0; i < RandomAmountToGenerate.Next(3, 5); i++) employeeList.Add(GenerateEmployee());

        return employeeList;
    }
}
