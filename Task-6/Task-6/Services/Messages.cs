using Microsoft.VisualBasic;
using NLog;
using NLog.Fluent;
using Task_6.Models;

namespace Task_6.Services;

public class Messages
{
    public static Logger _logger = LogManager.GetCurrentClassLogger();

    public static void Info(string message)
    {
        _logger.Info(message);
    }

    public static void WrongInput()
    {
        Info("Wrong input, try again.");
    }

    public static void PhoneModelsList()
    {
        Info("Please, enter a model name or it's part (to display a list).");
    }

    public static void PhoneModelInput()
    {
        Info("Please, enter phone model you want to buy.");
    }

    public static void ShopInput()
    {
        Info("Which shop you want to buy your phone at?");
    }

    public static void ShopNotFound()
    {
        Info("Shop not found, please try again");
    }

    public static void PhoneNotFound()
    {
        Info("Phone not found, please try again.");
    }

    public static void PhoneOutOfStock()
    {
        Info("This phone model is out of stock. You can try your luck with another one.");
    }

    public static void GoodInvoice(Invoice invoice)
    {
        Info($"Order for {invoice.PhoneModel} with {invoice.Price}$ price is successfully created." +
             $"Date is {invoice.Date}");
    }

    public static void BadInvoiceGeneration()
    {
        Info("Invoice object generation went wrong (phone object may be null).");
    }

    public static void BadInvoiceInfileWriting()
    {
        Info("Invoice generation went wrong. Please, try again.");
    }

    public static void BadInvoiceSerialization()
    {
        Info("Invoice generation went wrong. Please, try again.");
    }
}
