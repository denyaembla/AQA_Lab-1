using NLog;
using Task_6.Exceptions;
using Task_6.Models;

namespace Task_6.Services;

public static class PhonePurchase
{
    private static bool PhoneCanBeFound(List<Shop> shops, string userInputModel)
    {
        var phoneCanBeFound = shops.SelectMany(shop => shop.PhonesList).Any(
            phone => phone.Model.Equals(userInputModel));

        return phoneCanBeFound;
    }

    private static bool PhoneIsInStock(List<Shop> shops, string userInputModel)
    {
        var phoneIsInStock = shops.SelectMany(shop => shop.PhonesList)
            .Where(phone => phone.Model.Equals(userInputModel))
            .Any(phone => phone.IsAvailable);

        return phoneIsInStock;
    }

    private static List<Shop> GetValidShops(List<Shop> shops, string userInputModel)
    {
        var validShops = shops.Where(shop =>
            shop.PhonesList.Any(phone => phone.Model.Equals(userInputModel) && phone.IsAvailable)).ToList();

        return validShops;
    }

    public static bool ShopNameIsValid(List<Shop> shops, string userInputShop)
    {
        var phoneCanBeFound = shops.Any(shop => shop.Name.Equals(userInputShop));

        return phoneCanBeFound;
    }

    public static Phone GetPhone(List<Shop> shops)
    {
        Messages.PhoneModelInput();
        var userInputModel = UserInputService.UserInput();

        var validShops = new List<Shop>();
        while (!PhoneCanBeFound(shops, userInputModel))
        {
            Messages._logger.Info("Phone model name is wrong. Please, try again");
            userInputModel = UserInputService.UserInput();
        }

        try
        {
            if (PhoneCanBeFound(shops, userInputModel))
            {
                if (PhoneIsInStock(shops, userInputModel))
                {
                    validShops = GetValidShops(shops, userInputModel);
                    Messages._logger.Info("Phone {model} successfully found.", userInputModel);
                }
                else
                {
                    Messages.PhoneOutOfStock();
                    throw new PhoneNotFoundException();
                }
            }
            else
            {
                Messages.PhoneNotFound();
                throw new PhoneNotFoundException();
            }
        }
        catch (PhoneNotFoundException)
        {
            Messages._logger.Error("Phone {model} was not found", userInputModel);
        }

        Messages.ShopInput();
        var userInputShop = UserInputService.UserInput();


        while (!ShopNameIsValid(shops, userInputShop))
        {
            Messages.ShopNotFound();
            userInputShop = UserInputService.UserInput();
        }

        List<Phone> phones = null;
        try
        {
            if (ShopNameIsValid(shops, userInputShop))
                phones = validShops.Select(s =>
                    s.PhonesList.Single(p => p.Model.Equals(userInputModel))).ToList();
        }
        catch (ShopNotFoundException ex)
        {
            Messages._logger.Info(ex);
            throw;
        }
        catch (InvalidOperationException ex)
        {
            Messages._logger.Info(ex);
            throw;
        }
        catch (NullReferenceException ex)
        {
            Messages._logger.Info(ex);
            throw;
        }

        return phones.First();
    }
}
