using Bogus;

namespace Drivers;

public class Users
{
    public string name;
    public string lastname;
    public DateOnly birthDateTime;
    public bool isEligibleToDrive;
    public Users(string name, string lastname, DateOnly birthDateTime, bool isEligibleToDrive)
    {
        this.name = name;
        this.lastname = lastname;
        this.birthDateTime = birthDateTime;
        this.isEligibleToDrive = isEligibleToDrive;
    }

    static DateOnly minDateForLicence = new DateOnly(1950, 01, 01);
    static DateOnly maxDateForLicence = new DateOnly(2002, 01, 01);
    private static List<Users> personsContainer = new List<Users>();
    
    public static void CreateThreeDrivers()
    {
        for(var i = 1; i<3; i++)
        personsContainer.Add(new Faker<Users>().
            CustomInstantiator(faker => new Users(
            faker.Name.FirstName(),
            faker.Name.LastName(),
            faker.Date.BetweenDateOnly(minDateForLicence, maxDateForLicence),
            faker.Database.Random.Bool())));
    }
}
