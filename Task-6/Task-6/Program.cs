using Task_6.Services;

NLog.Config.SimpleConfigurator.ConfigureForConsoleLogging();

var shops = JSonService.JSonHandler().Shops;
PhoneSearch.PrintByOperatingSystem(shops);
PhoneSearch.PrintAvailablePhones(shops);
var phone = PhonePurchase.GetPhone(shops);
InvoiceHandler.HandleInvoice(phone);
