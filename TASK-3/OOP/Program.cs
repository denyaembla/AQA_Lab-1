// See https://aka.ms/new-console-template for more information
namespace OOP;

class Program
{
    
    static void Main(string[] args)
    {
        
        UserFactory.GenerateUser(); /*Doesnt work, probably inheritance issues  */
        CandidateGenerator.GenerateOneCandidate();
        CandidateGenerator.GenerateOneCandidate();
        CandidateGenerator.GenerateOneCandidate();
        CandidateReportGenerator.SortAndDisplayCandidates();
        

    }
}
