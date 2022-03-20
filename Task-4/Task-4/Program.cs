using Task_4;
using Task_4.Generators;
using Task_4.Models;
using Task_4.ReportGenerators;

var candidateList = UserFactory.GenerateUsers(UserType.Candidate);
var employeeList = UserFactory.GenerateUsers(UserType.Employee);

CandidateReportGenerator.DisplayEveryCandidate(candidateList);
Console.Out.WriteLine();
CandidateReportGenerator.Report(candidateList);
Console.Out.WriteLine();
EmployeeReportGenerator.DisplayEveryEmployee(employeeList);
Console.Out.WriteLine();
EmployeeReportGenerator.Report(employeeList);






