namespace Gunter.Extensions.InfoSources.Specialized.Models
{
    public class WindowsEventLevel
    {
        public string LevelName { get; set; }
        public int LevelID { get; set; }
        public string ShowAs { get; set; }
        public string Description { get; set; }

        private WindowsEventLevel()
        {

        }

        public static List<WindowsEventLevel> GetStandardLevels()
        {
            var critical = new WindowsEventLevel
            {
                LevelName = "Critical Error",
                LevelID = 30,
                ShowAs = "Critical",
                Description = "Events that demand the immediate attention of the system administrator. They are generally directed at the global (system-wide) level, such as System or Application. They can also be used to indicate that an application or system has failed or stopped responding."
            };
            var error = new WindowsEventLevel
            {
                LevelName = "Error",
                LevelID = 40,
                ShowAs = "Error",
                Description = "Events that indicate problems, but in a category that does not require immediate attention."
            };
            var warning = new WindowsEventLevel
            {
                LevelName = "Warning",
                LevelID = 50,
                ShowAs = "Warning",
                Description = "Events that provide forewarning of potential problems; although not a response to an actual error, a warning indicates that a component or application is not in an ideal state and that some further actions could result in a critical error."
            };
            var information = new WindowsEventLevel
            {
                LevelName = "Information",
                LevelID = 80,
                ShowAs = "Informational",
                Description = "Events that pass noncritical information to the administrator, similar to a note that says: 'For your information.'"
            };
            var verbose = new WindowsEventLevel
            {
                LevelName = "Verbose",
                LevelID = 100,
                ShowAs = "Informational",
                Description = "Verbose status, such as progress or success messages."
            };

            return new()
            {
                critical,
                error,
                warning,
                information,
                verbose
            };
        }
    }
}

