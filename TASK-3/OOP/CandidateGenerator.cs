using Bogus;
namespace OOP;

public class CandidateGenerator : Candidate
{
    
    public CandidateGenerator(Guid id, string lastname, string name, string desiredJobPosition,
                                string desiredJobDescription, int desiredSalary)
            : base(id, lastname, name, desiredJobPosition, desiredJobDescription, desiredSalary)
    {
        
    }

    protected static List<Candidate> candContainer = new();
    public static Random count = new();
    public static Random randomSalary = new();

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
        
        for (var i = 0; i < count.Next(minValue: 2, maxValue: 2); i++)
        {
            GenerateOneCandidate();
        }
    }

    
}


