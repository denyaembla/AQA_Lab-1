namespace Humanity;

public class Candidate
{
    private Guid id = new(); /* GUID */
    private string lastname;
    private string name;
    private string desiredJobPosition;
    private string desiredJobDescription;
    private double desiredSalary;

    public Candidate(string lastname, string name, string desiredJobPosition, string desiredJobDescription, double desiredSalary)
    {
        this.lastname = lastname;
        this.name = name;
        this.desiredJobPosition = desiredJobPosition;
        this.desiredJobDescription = desiredJobDescription;
        this.desiredSalary = desiredSalary;
    }

    public void Display()
    {
        Console.WriteLine($"I am {lastname + " " + name}. I want to be a {desiredJobPosition}" +
                          $" {desiredJobDescription}, with {desiredSalary} salary. My ID number is {id}");
    }
}
