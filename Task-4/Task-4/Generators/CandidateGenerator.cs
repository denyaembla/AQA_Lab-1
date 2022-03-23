using Bogus;
using Task_4.Models;

namespace Task_4.Generators;

public class CandidateGenerator : Candidate
{
    internal static readonly Random RandomAmountToGenerate = new();
    private const decimal MinimumSalary = 1000;
    private const decimal MaximumSalary = 2000;

    public static Candidate GenerateCandidate()
    {
        var candidate = new Faker<Candidate>().CustomInstantiator(f => new Candidate())
            .RuleFor(c => c.Id, Guid.NewGuid)
            .RuleFor(c => c.Lastname, (f, c) => f.Name.LastName())
            .RuleFor(c => c.Name, (f, c) => f.Name.FirstName())
            .RuleFor(c => c.DesiredSalary, (f, c) => f.Finance.Amount(MinimumSalary, MaximumSalary))
            .RuleFor(c => c.DesiredJobDescription, (f, c) => f.Name.JobDescriptor())
            .RuleFor(c => c.DesiredJobPosition, (f, c) => f.Name.JobTitle())
            .RuleFor(c => c.Id, f => Guid.NewGuid());

        return candidate.Generate();
    }

    public static List<Candidate> GenerateAFewCandidates()
    {
        var candidatesList = new List<Candidate>();
        for (var i = 0; i < RandomAmountToGenerate.Next(3, 5); i++) candidatesList.Add(GenerateCandidate());

        return candidatesList;
    }
}
