using System.Reflection;
using System.Runtime.InteropServices;
using System.IO;

namespace Task_6.Services;

public class FilePathHandler
{
    private const string DataFolder = "Data";
    private const string dataFile = "appsettings.json";
    private const string InvoiceFolder = "InvoiceOutput";
    
    public static string JSonDataPath()
    {
        var separator = Path.DirectorySeparatorChar;
        var enviroment = Environment.ProcessPath;
        var subPath = Directory.GetParent(enviroment).Parent.FullName;
        var fullPath = Directory.GetParent(subPath).Parent.FullName +
                                    separator + DataFolder + separator + dataFile;
        return fullPath;
    }
    
    public static string InvoiceOutputPath()
    {
        var separator = Path.DirectorySeparatorChar;
        var environment = Environment.ProcessPath;
        var subPath = Directory.GetParent(environment).Parent.FullName;
        var fullPath = Directory.GetParent(subPath).Parent.FullName +
                       separator + InvoiceFolder + separator;
        return fullPath;
    }
}
