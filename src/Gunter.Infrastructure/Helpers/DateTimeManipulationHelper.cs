namespace Gunter.Core.Infrastructure.Helpers
{
    public static class DateTimeManipulationHelper
    {
        public const string Segundos = "s - Segundos";
        public const string Minutos = "m - Minutos";
        public const string Horas = "h - Horas";
        public const string Dias = "d - Días";
        public const string Semanas = "s - Semanas";
        public const string Meses = "M - Meses";
        public const string Anyos = "a - Años";

        public static string[] GetFormats() => new[] { Segundos, Minutos, Horas, Dias, Semanas, Meses, Anyos };


        public static TimeSpan DEFAULT_EXPIRATION = new TimeSpan(0, 0, 30);
        public static TimeSpan OneDayTimeSpan => new TimeSpan(1, 0, 0, 0);
        public static TimeSpan HalfDayTimeSpan => new TimeSpan(0, 12, 0, 0);
        public static TimeSpan QuarterDayTimeSpan => new TimeSpan(0, 6, 0, 0);
        public static TimeSpan OneMonth => new TimeSpan(30, 0, 0, 0);

        public static string GetRelativeDateTime(DateTime date)
        {
            TimeSpan ts = DateTime.Now - date;
            if (ts.TotalMinutes < 1 && ts.Seconds == 0)//seconds ago
                return $"just now";
            if (ts.TotalMinutes < 1)//seconds ago
                return $"{Convert.ToInt32(ts.Seconds)} seconds ago";
            if (ts.TotalHours < 1)//min ago
                return (int)ts.TotalMinutes == 1 ? "1 Minute ago" : (int)ts.TotalMinutes + " Minutes ago";
            if (ts.TotalDays < 1)//hours ago
                return (int)ts.TotalHours == 1 ? "1 Hour ago" : (int)ts.TotalHours + " Hours ago";
            if (ts.TotalDays < 7)//days ago
                return (int)ts.TotalDays == 1 ? "1 Day ago" : (int)ts.TotalDays + " Days ago";
            if (ts.TotalDays < 30.4368)//weeks ago
                return (int)(ts.TotalDays / 7) == 1 ? "1 Week ago" : (int)(ts.TotalDays / 7) + " Weeks ago";
            if (ts.TotalDays < 365.242)//months ago
                return (int)(ts.TotalDays / 30.4368) == 1 ? "1 Month ago" : (int)(ts.TotalDays / 30.4368) + " Months ago";
            //years ago
            return (int)(ts.TotalDays / 365.242) == 1 ? "1 Year ago" : (int)(ts.TotalDays / 365.242) + " Years ago";
        }
    }
}

