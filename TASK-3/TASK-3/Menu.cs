namespace TASK_3;

public class Menu
{
    public static void CreateAndShowThreeDrivers()
    {
        Console.Write(">>> List of every user<<< \n");
        var driversList = new List<Driver>();
        for (var i = 0; i < 3; i++)
        {
            var driver = Driver.CreateDriver();
            Driver.DisplayDriver(driver);
            if (driver.isDriver)
            {
                driversList.Add(driver);
            }
        }

        Console.Write("\n > List of viable drivers <");
        foreach (var viableDriver in driversList)
        {
            Driver.DisplayDriver(viableDriver);
        }
        
        var driverNumberToDisplay = 0;
        
        do
        {
            Console.WriteLine("Please, choose your driver\n");
            driverNumberToDisplay = Convert.ToInt32(Console.ReadLine()) - 1;
        } while (driverNumberToDisplay is not (0 or 1 or 2));

        Driver.DisplayDriver(driversList[driverNumberToDisplay]);
        var chosenDriver = driversList[driverNumberToDisplay];
        

        var statsTypeToDisplay = 1;
        while (statsTypeToDisplay is 1 or 2)
        {
            Console.WriteLine("\n > Choose stats to display: < \n" +
                              " Enter '1' to see vehicle technical stats\n " +
                              "Enter '2' to see exploitation stats,\n" +
                              "To exit press 3\n");
            statsTypeToDisplay = Convert.ToInt32(Console.ReadLine());
            switch (statsTypeToDisplay)
            {
                case 1:
                    DisplayVehicleStats(chosenDriver);
                    break;
                
                case 2:
                    DisplayExploitationStats(chosenDriver);
                    break;
            }
        }
    }
    
    
    private static void DisplayVehicleStats(Driver driver)
    {
        Console.WriteLine($"\nCar model is:{driver._Vehicle.Model} \n" +
                          $"Vehicle owner is {driver._Vehicle.Owner}" +
                          $"Engine power equals {driver._Vehicle._Engine.Power} h.p. \n" +
                          $"Maximum speed: {driver._Vehicle._Engine.MaxSpeed:F0} km/h \n" +
                          $"Fuel used is {driver._Vehicle._Engine.FuelType} \n" +
                          $"Capacity is {driver._Vehicle._Engine.Capacity} kilometers");
    }
    
    private static void DisplayExploitationStats(Driver driver)
    {
        var drivingYearsAmount = DateTime.Now - driver.LicenseDate;
        Console.WriteLine($"Current driver's amount of years driving: {drivingYearsAmount.Days / 365}");
        string distance;
        do
        {
            Console.WriteLine("Please, enter distance value in kilometers");
            distance = Console.ReadLine();
        } while (Convert.ToInt32(distance) <= 0 && string.IsNullOrWhiteSpace(distance));

        var resultDistance = Convert.ToInt32(distance);
        
        var travelTime = TimeSpan.FromMinutes(Convert.ToInt32(resultDistance / driver._Vehicle._Engine.MaxSpeed*60));
        Console.WriteLine($"Approximate travel time is {travelTime.Hours} hours and {travelTime.Minutes} minutes");
    }
}
