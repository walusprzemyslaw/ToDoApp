using System.Globalization;

namespace ToDo.Core.Extensions;

public static class DateTimeExtensions
{
    public static DateTime ParseDate(this string dateString)
    {
        var result =  DateTime.ParseExact(dateString, "M/d/yyyy", CultureInfo.InvariantCulture);
        return result;
    }
}