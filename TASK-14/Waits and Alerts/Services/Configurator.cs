using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Alerts_and_Waits.Services;

public static class Configurator
{
    private static readonly Lazy<IConfiguration> s_configuration;
    public static IConfiguration Configuration => s_configuration.Value;
    public static string AlertsUrl => Configuration.GetSection("URLs").GetSection("Alerts").Value;
    public static string OnlinerUrl => Configuration.GetSection("URLs").GetSection("Onliner").Value;
    public static string BrowserType => Configuration[nameof(BrowserType)];
    public static int WaitingTime => int.Parse(Configuration[nameof(WaitingTime)]);


    static Configurator()
    {
        s_configuration = new Lazy<IConfiguration>(BuildConfiguration);
    }

    internal static IConfiguration BuildConfiguration()
    {
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var builder = FileConfigurationExtensions.SetBasePath(new ConfigurationBuilder(), basePath)
            .AddJsonFile("appsettings.json");

        var appSettingFiles = Directory.EnumerateFiles(basePath, "appsettings.json");

        foreach (var appSettingFile in appSettingFiles) builder.AddJsonFile(appSettingFile);

        return builder.Build();
    }
}