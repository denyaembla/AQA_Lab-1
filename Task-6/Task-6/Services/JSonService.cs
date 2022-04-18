using Newtonsoft.Json;
using Task_6.DTO;

namespace Task_6.Services;

public class JSonService
{
    public static ShopsDTO JSonHandler()
    {
        var jsonData = string.Empty;
        try
        {
            jsonData = File.ReadAllText(FilePathHandler.JSonDataPath());
        }
        catch (FileNotFoundException)
        {
            Messages.Info("FileNotFound Exception at 'JSonHandler method'. ");
        }

        return JsonConvert.DeserializeObject<ShopsDTO>(jsonData);
    }
}
