namespace Task_6.Services;

public class FilePathHandler
{
    private const string DataFolder = "Data";
    private const string DataFile = "appsettings.json";
    private const string InvoiceFolder = "InvoiceOutput";
    private static readonly char Separator = Path.DirectorySeparatorChar;
    private static string _environmentString = Environment.ProcessPath;
    private static string subPath = Directory.GetParent(_environmentString).Parent.FullName;

    public static string JSonDataPath()
    {
        var fullPath = Directory.GetParent(subPath).Parent.FullName + Separator + DataFolder + Separator + DataFile;
        return fullPath;
    }

    public static string InvoiceOutputPath()
    {
        var fullPath = Directory.GetParent(subPath).Parent.FullName + Separator + InvoiceFolder + Separator;
        return fullPath;
    }
}
