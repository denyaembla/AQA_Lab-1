using NLog;
using Task_6.Services;

NLog.Config.SimpleConfigurator.ConfigureForConsoleLogging();

var container = JSonService.JSonHandler();
var shops = container.shops;
PhoneSearch.PrintByOperatingSystem(shops);
PhoneSearch.PrintAvailablePhones(shops);
var phone = PhonePurchase.GetPhone(shops);
InvoiceHandler.HandleInvoice("invoice", phone);
