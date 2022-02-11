using Bogus;

namespace Humanity;

public class Candidate : IDisplay
{
    public Guid id = Guid.NewGuid(); /* GUID */
    public string lastname { get; }
    public string name { get; } 
    public string desiredJobPosition { get; }
    public string desiredJobDescription { get; }
    public int desiredSalary { get; }

    public Candidate(Guid id, string lastname, string name, string desiredJobPosition, string desiredJobDescription, int desiredSalary)
    {
        this.lastname = lastname;
        this.name = name;
        this.desiredJobPosition = desiredJobPosition;
        this.desiredJobDescription = desiredJobDescription;
        this.desiredSalary = desiredSalary;
    }

    public void Display()
    {
        Console.WriteLine($"I am {lastname} {name}. I want to be a {desiredJobPosition} at " +
                          $" {desiredJobDescription}, with a salary of {desiredSalary} . My ID number is {id}");
    }

    public void GenerateCandidates()
    {
        var candidatesList = new List<Candidate>(); /*have to create an interface for both classes */
        var count = new Random();
        var randomSalary = new Random();
        for (var i = 0; i < count.Next(2,5); i++)
        {
            candidatesList.Add(new Faker<Candidate>().CustomInstantiator(fake => new Candidate(
                new Guid(),
                fake.Name.FirstName(),
                fake.Name.LastName(),
                fake.Name.JobTitle(),
                fake.Name.JobDescriptor(),
                randomSalary.Next(500, 2500))));
        }
        
    }
}
