using System.Globalization;

namespace _01._Logger.Utilities;

public static class DateTimeConverter
{
    public static DateTime ConvertStringToDateTime(string dateString) => DateTime.ParseExact(dateString, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
}