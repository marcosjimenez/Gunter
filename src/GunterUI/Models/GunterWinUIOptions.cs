namespace Models
{
    public class GunterWinUIOptions
    {
        public bool MainLayoutAutoPersist { get; set; }
        public MainWindowStatus MainWindow { get; set; } = new ();
        public GunterWinUIOptionsGunterDefaults GunterDefaults { get; set; } = new();

        public class MainWindowStatus
        {
            public Point MainWindowLocation { get; set; }
            public Size MainWindowSize { get; set; }
        }

        public class GunterWinUIOptionsGunterDefaults
        {
            public string GenerationDirectory { get; set; } = string.Empty;
            public string PluginDirectory { get; set; } = string.Empty;
            public string IODirectory { get; set; } = string.Empty;
            public GunterWinUIOptionsGunterDefaultsFileSystem FileSystem { get; set; } = new();
            public class GunterWinUIOptionsGunterDefaultsFileSystem
            {
                public int CacheType { get; set; }

                public bool Versioning { get; set; } = true;

                public bool AutoSave { get; set; } = true;
            }
        }
    }
}
