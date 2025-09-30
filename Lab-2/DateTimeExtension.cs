namespace Lab_2;

public static class DateTimeExtension
{
    public static string CustomFormat(this DateTime source)
    {
        return $"{source.Year}*{source.Month}*{source.Day}";
    }
}
