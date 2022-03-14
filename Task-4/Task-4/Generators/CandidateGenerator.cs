using Bogus;
using Task_4.Models;

namespace Task_4.Generators;

public class CandidateGenerator : Candidate
{
    protected static List<Candidate> candContainer = new();
    static readonly Random randomAmount = new();
    static readonly Random randomSalary = new();
    private static Candidate GenerateCandidate()
    {
        var candidate = new Faker<Candidate>().
            CustomInstantiator(f => new Candidate())
            .RuleFor(c => c.Lastname, (f, c) => f.Name.LastName())
            .RuleFor(c => c.Name, (f, c) => f.Name.FirstName())
            .RuleFor(c => c.DesiredSalary, (f, c) => randomSalary.Next(500, 2500))
            .RuleFor(c => c.DesiredJobDescription, (f, c) => f.Name.JobDescriptor())
            .RuleFor(c => c.DesiredJobPosition, (f, c) => f.Name.JobTitle())
            .RuleFor(c => c.Id, f => Guid.NewGuid());
        
        return candidate.Generate();
    }

    public static void AddCandidate()
    {
        candContainer.Add(GenerateCandidate());
    }
    public static void GenerateAFewCandidates()
    {
        for (var i = 0; i < randomAmount.Next(2, 2); i++)
        {
            AddCandidate();
        }
    }
    
}
