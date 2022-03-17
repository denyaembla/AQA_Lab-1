using Task_4;
using Task_4.Generators;
using Task_4.Models;
using Task_4.ReportGenerators;

var employeeReport = new EmployeeReportGenerator();
var candidateReport = new CandidateReportGenerator();

UserFactory.GenerateUsers(UserType.Employee);
UserFactory.GenerateUsers(UserType.Candidate);

candidateReport.Report();
employeeReport.Report();






