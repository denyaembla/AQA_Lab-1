using Task_4.Generators;

namespace Task_4.ReportGenerators;

public class CandidateReportGenerator : CandidateGenerator, IReportGenerator
{
    private static void SortCandidates()
    {
        CandidatesContainer.Sort((c1, c2) =>
            {
                var result = c1.DesiredSalary.CompareTo(c2.DesiredSalary);
                return result == 0 ? c1.DesiredJobPosition.CompareTo(c2.DesiredJobPosition) : result;
            });
    }
    public void Report()
    {
        SortCandidates();
        Console.WriteLine("Candidates list: \n");
        foreach (var candidate in CandidatesContainer)
        {
            Console.WriteLine($"{candidate.Id} || {candidate.Lastname} {candidate.Name} ||" +
                              $" {candidate.DesiredJobPosition}|| salary {candidate.DesiredSalary}"); 
        }
    }

    
}
