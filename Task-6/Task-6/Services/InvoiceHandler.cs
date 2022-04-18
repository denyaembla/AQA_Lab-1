using Newtonsoft.Json;
using Task_6.Models;

namespace Task_6.Services;

public class InvoiceHandler
{
    private static Invoice CreateInvoiceObject(Phone phone)
    {
        var invoice = new Invoice
        {
            PhoneModel = phone.Model,
            Date = DateTime.Now.ToString(),
            Price = phone.Price
        };

        return invoice;
    }

    private static string SerializeInvoice(Invoice invoice)
    {
        var jsonInvoice = "";
        var settings = new JsonSerializerSettings {Formatting = Formatting.Indented};
        jsonInvoice = JsonConvert.SerializeObject(invoice, settings);

        return jsonInvoice;
    }

    private static void WriteInFile(string json)
    {
        Directory.CreateDirectory(FilePathHandler.InvoiceOutputPath());
        const string fileName = "invoice.json";
        var path = Path.Combine(FilePathHandler.InvoiceOutputPath(), fileName);
        var file = new StreamWriter(path);
        file.Write(json);
        file.Close();
    }

    public static void HandleInvoice(Phone phone)
    {
        Invoice invoice;
        try
        {
            invoice = CreateInvoiceObject(phone);
        }
        catch (NullReferenceException ex)
        {
            Messages.BadInvoiceGeneration();
            Messages.Info($"{ex}");
            throw;
        }
        catch (ArgumentException ex)
        {
            Messages.BadInvoiceGeneration();
            Messages.Info($"{ex}");
            throw;
        }
        catch (Exception ex)
        {
            Messages.BadInvoiceGeneration();
            Messages.Info($"{ex}");
            throw;
        }

        string jsonInvoice = null;
        try
        {
            jsonInvoice = SerializeInvoice(invoice);
        }
        catch (NullReferenceException ex)
        {
            Messages.BadInvoiceSerialization();
            Messages.Info($"{ex}");
        }
        catch (IOException ex)
        {
            Messages.BadInvoiceSerialization();
            Messages.Info($"{ex}");
        }
        catch (ArgumentNullException ex)
        {
            Messages.BadInvoiceSerialization();
            Messages.Info($"{ex}");
        }
        catch (JsonSerializationException ex)
        {
            Messages.BadInvoiceSerialization();
            Messages.Info($"{ex}");
        }

        try
        {
            WriteInFile(jsonInvoice);
        }
        catch (FileNotFoundException ex)
        {
            Messages.BadInvoiceInfileWriting();
            Messages.Info($"{ex}");
        }
        catch (IOException ex)
        {
            Messages.BadInvoiceInfileWriting();
            Messages.Info($"{ex}");
        }
        catch (ArgumentException ex)
        {
            Messages.BadInvoiceInfileWriting();
            Messages.Info($"{ex}");
        }
        catch (NullReferenceException ex)
        {
            Messages.BadInvoiceInfileWriting();
            Messages.Info($"{ex}");
        }

        Messages.GoodInvoice(invoice);
    }
}
