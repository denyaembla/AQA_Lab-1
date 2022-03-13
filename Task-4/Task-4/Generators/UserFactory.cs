namespace Task_4.Generators;

public class UserFactory
{
    public static void GenerateUser()
    {
        Console.WriteLine($"Enter 1, if you want to add another Employee.\n" +
                          $"Enter 2, if you want to add another Candidate.");
        
        var userType = Convert.ToInt32(Console.ReadLine());
        
        switch (userType)
        {
            case 1:
                EmployeeGenerator.GenerateOneEmployee();
                break;
            case 2:
                CandidateGenerator.GenerateOneCandidate();
                break;
        }
    }
}
