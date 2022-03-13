using Task_4.Generators;

namespace Task_4.ReportGenerators;

public class EmployeeReportGenerator : EmployeeGenerator
{
    public EmployeeReportGenerator(Guid id, string lastname, string name, string jobTitle,
        string companyName, string companyCountry, string companyCity, string companyStreet, int salary) :
        base(id, lastname, name, jobTitle, companyName, companyCountry,
            companyCity, companyStreet, salary)
    {

    }

    private static void SortEmployees()
    {
        employeeContainer.Sort((c1, c2) =>
        {
            var result = c1.CompanyName.CompareTo(c1.CompanyName);
            return result == 0 ? c2.Salary.CompareTo(c1.Salary) : result;
        });
        
    }

    public static void EmployeeReport()
    {
        SortEmployees();
        Console.WriteLine("Employee list: \n");
        foreach (var employee in employeeContainer)
        {
            Console.WriteLine($"{employee.Id}, {employee.CompanyName}," +
                              $" {employee.Lastname} {employee.Name}, salary is {employee.Salary}");
        }
    }
}
