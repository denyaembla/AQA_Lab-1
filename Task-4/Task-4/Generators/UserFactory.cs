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
                userList = ConvertToIUserFromCandidates(CandidateGenerator.GenerateAFewCandidates());
                break;

            case UserType.Employee:
                userList = ConvertToIUserFromEmployee(EmployeeGenerator.GenerateAFewEmployees());
                break;

            default:
                throw new ArgumentException($"Generation failed, wrong UserType {userType}",
                    nameof(userType));
        }

        return userList;
    }

    private static List<IUser> ConvertToIUserFromCandidates(List<Candidate> candidatesList)
    {
        var boxedToIUser = new List<IUser>();

        foreach (var user in candidatesList)
            if (user is IUser)
                boxedToIUser.Add(user);

        return boxedToIUser;
    }

    private static List<IUser> ConvertToIUserFromEmployee(List<Employee> employeesList)
    {
        var boxedToIUserList = new List<IUser>();

        foreach (var user in employeesList)
            if (user is IUser)
                boxedToIUserList.Add(user);

        return boxedToIUserList;
    }
}
