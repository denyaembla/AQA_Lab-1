using Task_4.Generators;
using Task_4.ReportGenerators;

CandidateGenerator.GenerateOneCandidate();
UserFactory.GenerateUser();
CandidateGenerator.GenerateAFewCandidates();
CandidateReportGenerator.CandidateReport();

Console.WriteLine("\n \n ");

EmployeeGenerator.GenerateOneEmployee();
UserFactory.GenerateUser();
EmployeeGenerator.GenerateAFewEmployees();
EmployeeReportGenerator.EmployeeReport();

