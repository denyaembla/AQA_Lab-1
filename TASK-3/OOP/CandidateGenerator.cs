using Bogus;
namespace OOP;

public class CandidateGenerator : Candidate
{
    
    public CandidateGenerator(Guid id, string lastname, string name, string desiredJobPosition,
                                string desiredJobDescription, int desiredSalary)
            : base(id, lastname, name, desiredJobPosition, desiredJobDescription, desiredSalary)
    {
        
    }

    public static List<Candidate> candContainer;
    public static void GenerateCandidates()
    {
        candContainer = new List<Candidate>(); /*have to create an interface for both classes */
        var count = new Random();
        var randomSalary = new Random();
        for (var i = 0; i < count.Next(minValue: 2, maxValue: 10); i++)
        {
            candContainer.Add(new Faker<Candidate>().CustomInstantiator(fake => new Candidate(
                new Guid(),
                fake.Name.FirstName(),
                fake.Name.LastName(),
                fake.Name.JobTitle(),
                fake.Name.JobDescriptor(),
                randomSalary.Next(500, 2500))));
        }
        
        {
            
            foreach (var candidate in candContainer)
            {
                candidate.Display();
               
            }
        }

        
    }

    
}


