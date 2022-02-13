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
                int result = c1.companyName.CompareTo(c1.companyName);
                return result == 0 ? c2.salary.CompareTo(c1.salary) : result;
            });
            foreach (var candidate in emplContainer)
            {
                candidate.Display();
                

            }
    
    }
}
