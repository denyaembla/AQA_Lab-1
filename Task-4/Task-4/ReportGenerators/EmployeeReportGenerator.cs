using System.Collections;
using Task_4.Generators;
using Task_4.Models;

namespace Task_4.ReportGenerators;

public class EmployeeReportGenerator : EmployeeGenerator
{
    public static void DisplayEveryEmployee(List<IUser> employeeList)
    {
        Console.WriteLine("Employee list (unsorted)");
        var employees = ConvertFromFactory(employeeList);
        foreach (var employee in employees) employee.Display();
    }


    private static List<Employee> ConvertFromFactory(List<IUser> users)
    {
        var employeesResultContainer = new List<Employee>();

        foreach (var employee in users)
            if (employee is Employee)
                employeesResultContainer.Add(employee as Employee);

        return employeesResultContainer;
    }

    private static void SortEmployees(List<Employee> employeeContainer)
    {
        employeeContainer.Sort((c1, c2) =>
        {
            var result = c1.CompanyName.CompareTo(c2.CompanyName);
            return result == 0 ? c2.Salary.CompareTo(c1.Salary) : result;
        });
    }

    public static void Report(List<IUser> employeeContainer)
    {
        Console.WriteLine("\n Employee list (sorted):");

        var employeeResultContainer = ConvertFromFactory(employeeContainer);
        SortEmployees(employeeResultContainer);
        foreach (var employee in employeeResultContainer)
            Console.WriteLine($"{employee.Id} || {employee.CompanyName} || " +
                              $" {employee.Name} {employee.Lastname} || salary is {employee.Salary}");
    }
}
