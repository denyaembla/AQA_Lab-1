using System.ComponentModel;
using Bogus;
using Task_4.Models;

namespace Task_4.Generators;

public class UserFactory
{
    public static List<IUser> GenerateUsers(UserType userType)
    {

        var userList = new List<IUser>();
        switch (userType)
        {
            case UserType.Candidate:
                for (var i = 0; i < CandidateGenerator.RandomAmountToGenerate.Next(minValue: 3, maxValue: 5); i++)
                {
                    userList?.Add(CandidateGenerator.GenerateCandidate());
                }
                break;

            case UserType.Employee:
                for (var i = 0; i < EmployeeGenerator.RandomAmountToGenerate.Next(minValue: 2, maxValue: 6); i++)
                {
                    userList?.Add(EmployeeGenerator.GenerateEmployee());
                }
                break;

            default:
                throw new ArgumentException("Generation failed, wrong UserType ",
                    nameof(userType));
        }

        return userList!;
    }
    
}
