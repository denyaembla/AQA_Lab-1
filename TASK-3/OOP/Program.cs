// See https://aka.ms/new-console-template for more information
namespace OOP;

class Program
{
    
    static void Main(string[] args)
    {
        CandidateGenerator.GenerateCandidates();
        Console.Write(" \n ");
        CandidateReportGenerator.SortAndDisplayCandidates();
        Console.Write(" \n \n");
        EmployeeGenerator.GenerateEmployee();
        Console.Write(" \n ");
        EmployeeReportGenerator.SortAndDisplayEmployee();
    }
}
