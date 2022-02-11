namespace Humanity;

public class Candidate
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
}
