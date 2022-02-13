// See https://aka.ms/new-console-template for more information
namespace OOP;

class Program
{
    
    static void Main(string[] args)
    {
        
        
        EmployeeGenerator.GenerateEmployee();
        Console.Write(" \n ");
        EmployeeReportGenerator.SortAndDisplayEmployee();
    }
}
