﻿namespace ScottPlot.TickGenerators.TimeUnits;

public class Decisecond : ITimeUnit
{
    public IReadOnlyList<int> Divisors => StandardDivisors.Decimal;

    public TimeSpan MinSize => TimeSpan.FromMilliseconds(100);

    public DateTime Snap(DateTime dt)
    {
        return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, (dt.Millisecond / 100) * 100);
    }

    public string GetDateTimeFormatString()
    {
        bool clockHas24Hours = CultureInfo.CurrentCulture.DateTimeFormat.LongTimePattern.Contains("H");
        string hourSpecifier = clockHas24Hours ? "HH" : "hh";
        return $"{CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern}\n{hourSpecifier}:mm:ss.f"; // TODO: This assumes colons as the separators, but consider (some) French-language locales use 12h30 rather than 12:30
    }

    public DateTime Next(DateTime dateTime, int increment = 1)
    {
        return dateTime.AddMilliseconds(increment * 100);
    }
}
