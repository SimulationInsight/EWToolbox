using static SimulationInsight.MathLibrary.DateTimeUtilities;

namespace SimulationInsight.MathLibrary;

public static class DateTimeExtensionMethods
{
    public static DateTime FromUnixTime(this double unixTime)
    {
        var dateTime = ConvertUnixTimeToDateTime(unixTime);

        return dateTime;
    }

    public static double ToUnixTime(this DateTime dateTime)
    {
        var unixTime = ConvertDateTimeToUnixTime(dateTime);

        return unixTime;
    }
}