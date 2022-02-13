namespace OOP;


public class EmployeeReportGenerator : EmployeeGenerator
{

    public EmployeeReportGenerator(Guid id, string lastname, string name, string jobTitle,
        string companyName, string companyCountry, string companyCity, string companyStreet, int salary) :
        base(id, lastname, name, jobTitle, companyName, companyCountry,
            companyCity, companyStreet, salary)
    {

    }
    public static void SortAndDisplayEmployee()
    {
        emplContainer.Sort((c1, c2) =>
            {
                int result = c1.desiredSalary.CompareTo(c1.desiredSalary);
                return result == 0 ? c1.desiredJobPosition.CompareTo(c2.desiredJobPosition) : result;
            });
            foreach (var candidate in candContainer)
            {
                candidate.Display();
                

            }
    
    }
}
