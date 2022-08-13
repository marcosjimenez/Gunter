using static Gunter.Core.Infrastructure.Log.GunterLogItem;

namespace Gunter.Core.Infrastructure.Log
{
    public class GunterLog
    {
        public delegate void OnLogDelegate(object sender, GunterLogItemEventArgs e);

        private static readonly Lazy<GunterLog> lazy = new(() => new GunterLog());
        public static GunterLog Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        public event OnLogDelegate OnLog;

        private GunterLog()
        {

        }

        public void Log(object sender, string message, GunterLogItemSeverity severity = GunterLogItemSeverity.Information, string originId = "")
            => Log(sender, new GunterLogItem { OriginId = originId, Severity = severity, Message = message });

        public void Log(object sender, GunterLogItem message)
        {
            //if (!typeof(IGunterComponent).IsAssignableFrom(sender.GetType()))
            //    return;

            OnLog?.Invoke(sender,
                new GunterLogItemEventArgs
                {
                    GunterLogItem = message,
                });
        }
    }

    public class GunterLogItem
    {
        public enum GunterLogItemSeverity
        {
            Trace = 0,          // Logs that contain the most detailed messages.These messages may contain sensitive application data.These messages are disabled by default and should never be enabled in a production environment.
            Debug = 1,          // Logs that are used for interactive investigation during development. These logs should primarily contain information useful for debugging and have no long-term value.
            Information = 2,    // Logs that track the general flow of the application.These logs should have long-term value.
            Warning = 3,        // Logs that highlight an abnormal or unexpected event in the application flow, but do not otherwise cause the application execution to stop.
            Error = 4,          // Logs that highlight when the current flow of execution is stopped due to a failure.These should indicate a failure in the current activity, not an application-wide failure.
            Critical = 5,       // Logs that describe an unrecoverable application or system crash, or a catastrophic failure that requires immediate attention.
            None = 6            // Not used for writing log messages.Specifies that a logging category should not write any messages.
        }
        public string OriginId { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public GunterLogItemSeverity Severity { get; set; } = GunterLogItemSeverity.Information;
    }

    public class GunterLogItemEventArgs : EventArgs
    {
        public GunterLogItem GunterLogItem { get; set; } = new GunterLogItem();
    }
}
