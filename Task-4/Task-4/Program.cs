using Task_4.Generators;
using Task_4.ReportGenerators;

CandidateGenerator.AddCandidate();
UserFactory.GenerateUser();
CandidateGenerator.GenerateAFewCandidates();
CandidateReportGenerator.CandidateReport();

Console.WriteLine("\n \n ");

EmployeeGenerator.GenerateEmployee();
UserFactory.GenerateUser();
EmployeeGenerator.GenerateAFewEmployees();
EmployeeReportGenerator.EmployeeReport();

