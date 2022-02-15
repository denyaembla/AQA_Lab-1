using Bogus;

namespace Drivers;

public class Users
{
    public string name;
    public string lastname;
    public DateOnly birthDateTime;
    public bool isEligibleToDrive = true;


    protected static DateOnly minDateForLicence = new DateOnly(1950, 01, 01);
    protected static DateOnly maxDateForLicence = new DateOnly(2005, 01, 01);
    private static List<Users> personsContainer = new List<Users>();
    
    }
