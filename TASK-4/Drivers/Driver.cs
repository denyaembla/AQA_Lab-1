namespace Drivers;

public class Driver : Person
{
    Guid licenseID = Guid.NewGuid();
    private DateTime licenseDateTime;
    private Car _car;
}
