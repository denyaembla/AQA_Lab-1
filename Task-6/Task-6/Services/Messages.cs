using NLog;
using Task_6.Models;

namespace Task_6.Services;

public class Messages
{
    public static Logger _logger = LogManager.GetCurrentClassLogger();

    // public static void Print(string message)
    // {
    //     try
    //     {
    //         _logger.Info(message);
    //     }
    //     catch (NullReferenceException e)
    //     {
    //         _logger.Info("**Error: This string is null, check it**.");
    //         _logger.Info(e.StackTrace);
    //     }
    // }

    public static void WrongInput()
    {
        _logger.Info("Wrong input, try again.");
    }

    public static void PhoneModelsList()
    {
        _logger.Info("Please, enter a model name or it's part (to display a list).");
    }

    public static void PhoneModelInput()
    {
        _logger.Info("Please, enter phone model you want to buy.");
    }

    public static void ShopInput()
    {
        _logger.Info("Which shop you want to buy your phone at?");
    }

    public static void ShopNotFound()
    {
        _logger.Info("Shop not found, please try again");
    }

    public static void PhoneNotFound()
    {
        _logger.Info("Phone not found, please try again.");
    }

    public static void PhoneOutOfStock()
    {
        _logger.Info("This phone model is out of stock. You can try your luck with another one.");
    }

    public static void GoodInvoice(Invoice invoice)
    {
        _logger.Info("Order for {model} with {price}$ price is successfully created." +
                     "Date is {date}",
            invoice.PhoneModel,
            invoice.Price, invoice.Date);
    }

    public static void BadInvoiceGeneration()
    {
        _logger.Info("Invoice object generation went wrong (phone object may be null).");
    }

    public static void BadInvoiceInfileWriting()
    {
        _logger.Info("Invoice generation went wrong. Please, try again.");
    }

    public static void BadInvoiceSerialization()
    {
        _logger.Info("Invoice generation went wrong. Please, try again.");
    }
}
