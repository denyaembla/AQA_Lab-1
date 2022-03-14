using Task_4.Generators;

namespace Task_4.ReportGenerators;

public class CandidateReportGenerator : CandidateGenerator
{
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
            Console.WriteLine($"{candidate.Id} || {candidate.Lastname} {candidate.Name} ||" +
                              $" {candidate.DesiredJobPosition}|| salary {candidate.DesiredSalary}"); 
        }
    }

    
}
