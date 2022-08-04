namespace Gunter.Extensions.InfoSources
{
    public static class SpecializedInfoSources
    {
        public const string OpenWeather = "OpenWeather ";
        public const string Wikipedia = "Wikipedia";
        public const string Twitter = "Twitter TimeLine";
        public const string WindowsEventLog = "Windows Event Log";
        public const string AEMET = "AEMET Agencia Estatal de Meteorología";

        public static string[] GetList()
            => new[] {
                OpenWeather,
                AEMET,
                Wikipedia,
                Twitter,
                WindowsEventLog};
    }
}