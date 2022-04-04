using Task_6.DTO;
using Task_6.Models;
using System.Linq;

namespace Task_6.Services;

public class PhoneSearch
{
    public static void PrintByOperatingSystem(List<Shop> shops)
        {
            foreach (var shop in shops)
            {
                var iosDevicesCount = shop.PhonesList.Count(p =>
                    p.OperatingSystem.Contains("IOS") && p.IsAvailable == true);
                var androidDevicesCount = shop.PhonesList.Count(p =>
                    p.OperatingSystem.Contains("Android") && p.IsAvailable);

                Console.WriteLine("Shop name: {0}, \nShop ID: {1}.",
                    shop.Name,
                    shop.Id);
                Console.WriteLine("Has {0} IOS devices and {1} android devices.\n",
                    iosDevicesCount,
                    androidDevicesCount);
            }
        }

        public static void PrintAvailablePhones(List<Shop> shops)
        {
            Messages.PhoneModelsList();
            var userInput = UserInputService.UserInput();
            foreach (var shop in shops)
            {
                Console.WriteLine("\nStore: {0}, {1}\n", shop.Name, shop.Description);
                foreach (var phone in shop.PhonesList.Where(phone => phone.Model.Contains(userInput)))
                {
                    Console.WriteLine(
                        "Model: {0}\n" +
                        "Operation system: {1}\n" +
                        "Price: {2}$\n",
                    phone.Model, phone.OperatingSystem, phone.Price);
                }
            }
        }
}
