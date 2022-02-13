using System.Collections;
using System.ComponentModel;
using Bogus;

namespace OOP;

public class CandidateReportGenerator : CandidateGenerator
{

    public CandidateReportGenerator(Guid id, string lastname, string name, string desiredJobPosition,
        string desiredJobDescription, int desiredSalary) : base(id, lastname, name, desiredJobPosition,
        desiredJobDescription, desiredSalary)
    {
    }


    public  void SortAndDisplayCandidates()
    {
        
        {
            Cointainer.Sort((c1, c2) =>
            {
                int result = c1.desiredSalary.CompareTo(c1.desiredSalary);
                return result == 0 ? c1.desiredJobPosition.CompareTo(c2.desiredJobPosition) : result;
            });
            foreach (var candidate in candidatesList)
            {
                candidate.Display();
                

            }
        }
    }
}
    

 



