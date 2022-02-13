using System.Runtime.Serialization;
using Bogus;
namespace OOP;

public class CandidateGenerator : Candidate
{
    
    public CandidateGenerator(Guid id, string lastname, string name, string desiredJobPosition,
                                string desiredJobDescription, int desiredSalary)
            : base(id, lastname, name, desiredJobPosition, desiredJobDescription, desiredSalary)
    {
    }

    public List<Candidate> Cointainer;
    public void GenerateCandidates()
    {
        var candidatesList = new List<Candidate>(); /*have to create an interface for both classes */
        var count = new Random();
        var randomSalary = new Random();
        for (var i = 0; i < count.Next(minValue: 2, maxValue: 10); i++)
        {
            candidatesList.Add(new Faker<Candidate>().CustomInstantiator(fake => new Candidate(
                new Guid(),
                fake.Name.FirstName(),
                fake.Name.LastName(),
                fake.Name.JobTitle(),
                fake.Name.JobDescriptor(),
                randomSalary.Next(500, 2500))));
        }

        Cointainer = candidatesList;
        {
            /* candidatesList.Sort((c1, c2) =>
            {
                int result = c1.desiredSalary.CompareTo(c1.desiredSalary);
                return result == 0 ? c1.desiredJobPosition.CompareTo(c2.desiredJobPosition) : result;
            }); */
            foreach (var candidate in Cointainer)
            {
                candidate.Display();
               /* Console.WriteLine(candidatesList.GetType());
                Console.WriteLine(candidate.GetType()); */

            }
        }

        
    }

    
}


