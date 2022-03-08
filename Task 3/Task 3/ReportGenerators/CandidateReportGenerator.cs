using Task_3.Generators;

namespace Task_3.ReportGenerators;

public class CandidateReportGenerator : CandidateGenerator
{
    protected CandidateReportGenerator(Guid id, string lastname, string name, string desiredJobPosition,
        string desiredJobDescription, int desiredSalary)
        : base(id, lastname, name, desiredJobPosition,
        desiredJobDescription, desiredSalary)
    {
    }
    private static void SortCandidates()
    {
        candContainer.Sort((c1, c2) =>
            {
                var result = c1.DesiredSalary.CompareTo(c2.DesiredSalary);
                return result == 0 ? c1.DesiredJobPosition.CompareTo(c2.DesiredJobPosition) : result;
            });
    }
    public static void CandidateReport()
    {
        SortCandidates();
        Console.WriteLine("Candidates list: \n");
        foreach (var candidate in candContainer)
        {
            Console.WriteLine($"{candidate.Id}, {candidate.Lastname} {candidate.Name}," +
                              $" {candidate.DesiredJobPosition}, salary {candidate.DesiredSalary}"); 
        }
    }

    
}
