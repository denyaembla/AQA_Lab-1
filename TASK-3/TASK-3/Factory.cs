namespace TASK_3;

public static class Factory
{
    public static void CreateAndShowThreeDrivers()
    {
        var driver1 = Driver.CreateDriver();
        driver1.DisplayDriver();
        var driver2 = Driver.CreateDriver();
        driver2.DisplayDriver();
        var driver3 = Driver.CreateDriver();
        driver3.DisplayDriver();
        var chosenDriver = driver1;
        Console.WriteLine("Please, choose your driver");
        var driverToChoose = Convert.ToInt32(Console.ReadLine());
        switch (driverToChoose)
        {
            case 1:
                chosenDriver = driver1;
                chosenDriver.DisplayTechStats();
                break;
            case 2:
                chosenDriver = driver2;
                chosenDriver.DisplayTechStats();
                break;
            case 3:
                chosenDriver = driver3;
                chosenDriver.DisplayTechStats();
                break; 
            default: break;
        }
        Console.WriteLine("Choose stats to show: \n 1 to see technical stats \n 2 to see exploitation stats");
        var statsType = Convert.ToInt32(Console.ReadLine());
        switch(statsType)
        {
            case 1:
                chosenDriver.DisplayTechStats();
                break;
            case 2:
                chosenDriver.DisplayExploitationStats();
                break;
        }
    }
}
