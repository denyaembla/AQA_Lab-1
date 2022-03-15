namespace TASK_3;

public class DriversGenerator
{
    public static void CreateAndShowThreeDrivers()
    {
        var driver1 = Driver.CreateDriver();
        Driver.DisplayDriver(driver1);
        var driver2 = Driver.CreateDriver();
        Driver.DisplayDriver(driver2);
        var driver3 = Driver.CreateDriver();
        Driver.DisplayDriver(driver3);
        var chosenDriver = new Driver();
        Console.WriteLine("Please, choose your driver");
        var driverToChoose = Convert.ToInt32(Console.ReadLine());
        switch (driverToChoose)
        {
            case 1:
                Driver.DisplayDriver(driver1);
                chosenDriver = driver1;
                break;
            case 2:
                Driver.DisplayDriver(driver2);
                chosenDriver = driver2;
                break;
            case 3:
                Driver.DisplayDriver(driver3);
                chosenDriver = driver3;
                break; 
            default: break;
        }

        Console.Out.WriteLine($"Chosen driver is = {chosenDriver.Fullname}");
        Console.WriteLine("Choose stats to show: \n Enter '1' to see vehicle technical stats " +
                          "\nEnter '2' to see exploitation stats ");
        var statsType = Convert.ToInt32(Console.ReadLine());
        switch(statsType)
        {
            case 1:
                Driver.DisplayVehicleStats(chosenDriver);
                
                break;
            case 2:
                Driver.DisplayExploitationStats(chosenDriver);
                break;
        }
    }
}
