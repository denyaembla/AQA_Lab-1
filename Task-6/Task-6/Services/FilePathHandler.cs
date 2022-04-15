using System.Reflection;
using System.Runtime.InteropServices;
using System.IO;

namespace Task_6.Services;

public class FilePathHandler
{
    private const string DataFolder = "Data";
    private const string DataFile = "appsettings.json";
    private const string InvoiceFolder = "InvoiceOutput";
    private static readonly char Separator = Path.DirectorySeparatorChar;
    private static string _environmentString = Environment.ProcessPath;

    public static string JSonDataPath()
    {
        var subPath = Directory.GetParent(_environmentString).Parent.FullName;
        var fullPath = Directory.GetParent(subPath).Parent.FullName +
                       Separator + DataFolder + Separator + DataFile;
        return fullPath;
    }

    public static string InvoiceOutputPath()
    {
        var subPath = Directory.GetParent(_environmentString).Parent.FullName;
        var fullPath = Directory.GetParent(subPath).Parent.FullName +
                       Separator + InvoiceFolder + Separator;
        return fullPath;
    }
}
