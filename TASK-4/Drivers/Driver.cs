namespace Drivers;

public class Driver : Users
{
    Guid licenseID = Guid.NewGuid();
    private DateOnly licenseDateTime;
    private Car _car;

    public Driver(string name, string lastname, DateOnly birthDateTime, bool isEligibleToDrive) :
        base(name, lastname, birthDateTime, isEligibleToDrive)
    {
    }
}
