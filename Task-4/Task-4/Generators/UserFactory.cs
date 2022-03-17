using Task_4.Models;

namespace Task_4.Generators;

public class UserFactory
{
    public static void GenerateUsers(UserType userType)
    {
        switch (userType)
        {
            case UserType.Employee:
                EmployeeGenerator.GenerateAFewEmployees();
                break;
            case UserType.Candidate:
                CandidateGenerator.GenerateAFewCandidates();
                break;
        }
    }
}
