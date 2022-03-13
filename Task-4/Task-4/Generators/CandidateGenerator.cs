using Bogus;
using Task_4.Models;

namespace Task_4.Generators;

public class CandidateGenerator : Candidate
{
    public CandidateGenerator(Guid id, string lastname, string name, string desiredJobPosition,
        string desiredJobDescription, int desiredSalary)
        : base(id, lastname, name, desiredJobPosition, desiredJobDescription, desiredSalary)
    {
        
    }
    public static List<Candidate> candContainer = new();
    static Random count = new();
    static Random randomSalary = new();

    public static void GenerateOneCandidate()
    {
        candContainer.Add(new Faker<Candidate>().CustomInstantiator(fake => new Candidate(
            new Guid(),
            fake.Name.FirstName(),
            fake.Name.LastName(),
            fake.Name.JobTitle(),
            fake.Name.JobDescriptor(),
            randomSalary.Next(500, 2500))));
    }
    public static void GenerateAFewCandidates()
    {
        for (var i = 0; i < count.Next(2, 2); i++)
        {
            GenerateOneCandidate();
        }
    }
}
