using System.ComponentModel;
using Bogus;
using Task_4.Models;
using Task_4.ReportGenerators;

namespace Task_4.Generators;

public class UserFactory
{
    public static List<IUser> GenerateUsers(UserType userType)
    {
        var userList = new List<IUser>();
        switch (userType)
        {
            case UserType.Candidate:
                userList = CandidateGenerator.GenerateAFewCandidates();
                break;

            case UserType.Employee:
                userList = EmployeeGenerator.GenerateAFewEmployees();
                break;

            default:
                throw new ArgumentException($"Generation failed, wrong UserType {userType}",
                    nameof(userType));
        }

        return userList;
    }
}
