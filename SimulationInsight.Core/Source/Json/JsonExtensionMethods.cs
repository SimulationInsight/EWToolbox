using Newtonsoft.Json;

namespace SimulationInsight.Core;

public static class JsonExtensionMethods
{
    public static string ConvertToJsonString<T>(this T value, Formatting formatting = Formatting.Indented)
    {
        var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto };

        var outputString = JsonConvert.SerializeObject(value, formatting, settings);

        return outputString;
    }

    public static T ConvertFromJsonString<T>(string jsonString)
    {
        var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto };

        var value = JsonConvert.DeserializeObject<T>(jsonString, settings);

        return value;
    }

    public static void WriteToJsonFile<T>(this string outputString, string fileName)
    {
        Logger.Information($"      Writing {fileName}");

        File.WriteAllText(fileName, outputString);
    }

    public static void WriteToJsonFile<T>(this T value, string fileName, Formatting formatting = Formatting.Indented)
    {
        Logger.Information($"      Writing {fileName}");

        var outputString = value.ConvertToJsonString(formatting);

        File.WriteAllText(fileName, outputString);
    }

    public static T ReadFromJsonFile<T>(string fileName)
    {
        Logger.Information($"      Reading {fileName}");

        var outputString = File.ReadAllText(fileName);

        var value = ConvertFromJsonString<T>(outputString);

        return value;
    }
}