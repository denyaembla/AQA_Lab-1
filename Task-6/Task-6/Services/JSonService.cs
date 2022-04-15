using System.Reflection;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using NLog;
using Task_6.DTO;
using Task_6.Models;

namespace Task_6.Services;

public class JSonService
{
    public static ShopsDTO JSonHandler()
    {
        var container = new ShopsDTO();
        var jsonData = string.Empty;
        try
        {
            jsonData = File.ReadAllText(FilePathHandler.JSonDataPath());
        }
        catch (FileNotFoundException)
        {
            Messages._logger.Info("FileNotFound Exception at 'JSonHandler method'. ");
        }

        container = JsonConvert.DeserializeObject<ShopsDTO>(jsonData);
        return container;
    }
}
