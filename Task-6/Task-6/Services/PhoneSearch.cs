using Task_6.Models;

namespace Task_6.Services;

public class PhoneSearch
{
    private enum OperatingSystemType
    {
        IOS,
        Android
    }

    public static void PrintByOperatingSystem(List<Shop> shops)
    {
        foreach (var shop in shops)
        {
            var iosDevicesCount = shop.PhonesList.Count(p =>
                p.OperatingSystemType.Contains(OperatingSystemType.Android.ToString()) &&
                p.IsAvailable);
            var androidDevicesCount = shop.PhonesList.Count(p =>
                p.OperatingSystemType.Contains(OperatingSystemType.IOS.ToString()) &&
                p.IsAvailable);

            Messages.Info($"Shop name: {shop.Name}, \nShop ID: {shop.Id}.");
            Messages.Info($"Has {iosDevicesCount} IOS devices and {androidDevicesCount} android devices.\n");
        }
    }

    public static void PrintAvailablePhones(List<Shop> shops)
    {
        Messages.PhoneModelsList();
        var userInput = UserInputService.UserInput();
        foreach (var shop in shops)
        {
            Messages.Info($"\nStore: {shop.Name}, {shop.Description}\n");
            foreach (var phone in shop.PhonesList.Where(phone => phone.Model.Contains(userInput)))
                Messages.Info(
                    $"Model: {phone.Model}\n" +
                    $"Operating system: {phone.OperatingSystemType}\n" +
                    $"Price: {phone.Price}$\n");
        }
    }
}
