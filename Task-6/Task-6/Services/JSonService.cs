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
        const string FileName = "data.json";
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var fullPath = $"{basePath}{Path.DirectorySeparatorChar}{FileName}";
        
        var container = new ShopsDTO();
        const string filename = "data.json";
        var path = Path.Combine(Environment.CurrentDirectory, @"Data", filename);
        var jsonData = string.Empty;
        try
        {
            jsonData = File.ReadAllText(FilePathHandler.JSonDataPath());
            
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("FileNotFound Exception at 'JSonHandler method'. ");
        }

        container = JsonConvert.DeserializeObject<ShopsDTO>(jsonData);
        return container;
    }
}
