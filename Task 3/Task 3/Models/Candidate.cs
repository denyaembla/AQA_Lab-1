namespace Task_3.Models;

public class Candidate
{
    public Guid Id = Guid.NewGuid(); /* GUID */
    public string Lastname { get; }
    public string Name { get; }
    public string DesiredJobPosition { get; }
    public string DesiredJobDescription { get; }
    public int DesiredSalary { get; }


    public Candidate(Guid id, string lastname, string name, string desiredJobPosition, string desiredJobDescription,
        int desiredSalary)
    {
        Lastname = lastname;
        Name = name;
        DesiredJobPosition = desiredJobPosition;
        DesiredJobDescription = desiredJobDescription;
        DesiredSalary = desiredSalary;
    }

    public void Display()
    {
        Console.WriteLine($"I am {Lastname} {Name}, candidate. I want to be a {DesiredJobPosition} at " +
                          $" {DesiredJobDescription}, with a salary of {DesiredSalary} . My ID number is {Id}");
    }

}
