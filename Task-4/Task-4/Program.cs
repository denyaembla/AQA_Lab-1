using Task_4.Generators;
using Task_4.ReportGenerators;


UserFactory.GenerateUser();
EmployeeGenerator.GenerateAFewEmployees();
EmployeeReportGenerator.EmployeeReport();

Console.WriteLine("\n \n ");

UserFactory.GenerateUser();
CandidateGenerator.GenerateAFewCandidates();
CandidateReportGenerator.CandidateReport();





