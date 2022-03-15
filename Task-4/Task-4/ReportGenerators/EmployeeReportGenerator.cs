using Task_4.Generators;

namespace Task_4.ReportGenerators;

public class EmployeeReportGenerator : EmployeeGenerator
{
    
    private static void SortEmployees()
    {
        EmployeeContainer.Sort((c1, c2) =>
        {
            var result = c1.CompanyName.CompareTo(c2.CompanyName);
            return result == 0 ? c2.Salary.CompareTo(c1.Salary) : result;
        });
    }

    public static void EmployeeReport()
    {
        SortEmployees();
        Console.WriteLine("Employee list: \n");
        foreach (var employee in EmployeeContainer)
        {
            Console.WriteLine($"{employee.Id} || {employee.CompanyName} || " +
                              $" {employee.Lastname} {employee.Name} || salary is {employee.Salary}");
        }
    }
    
}
