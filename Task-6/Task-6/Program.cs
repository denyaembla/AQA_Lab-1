using NLog;
using Task_6.Services;


var config = new NLog.Config.LoggingConfiguration();
var logconsole = new NLog.Targets.ConsoleTarget("logconsole");
config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
LogManager.Configuration = config;

var container = JSonService.JSonHandler();
var shops = container.shops;
PhoneSearch.PrintByOperatingSystem(shops);
PhoneSearch.PrintAvailablePhones(shops);
var phone = PhonePurchase.GetPhone(shops);
InvoiceHandler.HandleInvoice("invoice", phone);


