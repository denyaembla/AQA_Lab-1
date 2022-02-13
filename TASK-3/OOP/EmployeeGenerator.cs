namespace OOP;
using Bogus;


public class EmployeeGenerator : Employee
{
    
    public EmployeeGenerator(Guid id, string lastname, string name, string jobTitle,
        string companyName, string companyCountry, string companyCity, string companyStreet, int salary) :
        base(id,  lastname,  name,  jobTitle,  companyName,  companyCountry,
             companyCity,  companyStreet,  salary)
    {
        
    }
    

    public static List<Employee> emplContainer;
    public static void GenerateEmployee()
    {
        emplContainer = new List<Employee>(); /*have to create an interface for both classes */
        var count = new Random();
        var randomSalary = new Random();
        for (var i = 0; i < count.Next(minValue: 2, maxValue: 10); i++)
        {
            emplContainer.Add(new Faker<Employee>().CustomInstantiator(fake => new Employee(
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
        
        {
            
            foreach (var employee in emplContainer)
            {
                employee.Display();
               
            }
        }

        
    }

    
}
