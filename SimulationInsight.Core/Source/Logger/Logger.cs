using Serilog;

namespace SimulationInsight.Core;

public static class Logger
{
    public static void Initialise(string fileName)
    {
        var log = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(fileName)
            .CreateLogger();

        Log.Logger = log;
    }

    public static void Information(string messageTemplate)
    {
        Log.Logger.Information(messageTemplate);
    }

    public static void Warning(string messageTemplate)
    {
        Log.Logger.Warning(messageTemplate);
    }

    public static void Error(string messageTemplate)
    {
        Log.Logger.Error(messageTemplate);
    }

    public static void Close()
    {
        Log.CloseAndFlush();
    }
}