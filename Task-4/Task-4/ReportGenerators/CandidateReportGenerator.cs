using Task_4.Generators;
using Task_4.Models;

namespace Task_4.ReportGenerators;

public class CandidateReportGenerator : CandidateGenerator
{
    public static void DisplayEveryCandidate(List<IUser> candidateList)
    {
        Console.WriteLine("Candidate list (unsorted)");
        var candidates = ConvertFromFactory(candidateList);
        foreach (var candidate in candidates) candidate.Display();
    }


    private static List<Candidate> ConvertFromFactory(List<IUser> users)
    {
        var candidatesContainerToDisplay = new List<Candidate>();

        foreach (var candidate in users)
            if (candidate is Candidate)
                candidatesContainerToDisplay.Add(candidate as Candidate);

        return candidatesContainerToDisplay;
    }

    private static void SortCandidates(List<Candidate> candidatesList)
    {
        candidatesList.Sort((c1, c2) =>
        {
            var result = c1.DesiredJobPosition.CompareTo(c2.DesiredJobPosition);
            return result == 0 ? c1.DesiredSalary.CompareTo(c2.DesiredSalary) : result;
        });
    }

    public static void Report(List<IUser> candidatesList)
    {
        Console.WriteLine("\n Candidates list (sorted):");

        var candidatesResultContainer = ConvertFromFactory(candidatesList);
        SortCandidates(candidatesResultContainer);
        foreach (var candidate in candidatesResultContainer)
            Console.WriteLine($"{candidate.Id} || {candidate.Lastname} {candidate.Name} ||" +
                              $" {candidate.DesiredJobPosition} || salary {candidate.DesiredSalary}");
    }
}
