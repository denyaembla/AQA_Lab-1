namespace OOP;

public class UserFactory
{
    public static void GenerateUser()
    {
        Console.WriteLine($"Enter 1, if you want to add another Employee.\n" +
                          $"Enter 2, if you want to add another Candidate.");
        var _userType = Console.Read();
        
        switch (_userType)
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
