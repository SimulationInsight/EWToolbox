namespace SimulationInsight.MathLibrary;

public static class DateTimeUtilities
{
    public static DateTime ConvertUnixTimeToDateTime(double unixTime)
    {
        var unixEpochTimeSeconds = (int)unixTime;
        var unixEpochTimeRemainder = Math.IEEERemainder(unixTime, 1.0);
        var unixEpochTimeMilliseconds = Math.Round(unixEpochTimeRemainder * 1e3);

        var dateTime = new DateTime(1970, 1, 1).AddSeconds(unixEpochTimeSeconds);

        dateTime = dateTime.AddMilliseconds(unixEpochTimeMilliseconds);

        return dateTime;
    }

    public static double ConvertDateTimeToUnixTime(DateTime dateTime)
    {
        var dateTimeOffset = new DateTimeOffset(dateTime);

        var unixTime = dateTimeOffset.ToUnixTimeMilliseconds() / 1000.0;

        return unixTime;
    }
}