namespace Gunter.Core.Constants
{
    public static class ChainConstants
    {
        public static class LinkStatus
        {
            public const string Idle = "0";
            public const string Started = "100";
            public const string StartedWithChilds = "200";
            public const string Paused = "500";
            public const string Stopped = "800";
            public const string Completed = "1000";
            public const string Error = "9999";
        }
    }
}
