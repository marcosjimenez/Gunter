namespace GunterUI.Extensions
{
    public class WindowManager
    {
        public enum AvailableForm
        {
            ProcessForm = 10,
            InfoItemForm = 20,
            InfoSourceForm = 30,
            WebViewer = 40
        }

        private readonly Dictionary<string, Form> _forms;

        public MdiMain MainForm { get; set; }

        private static readonly Lazy<WindowManager> lazy = new Lazy<WindowManager>(() => new WindowManager());

        public static WindowManager Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        private WindowManager()
        {
            _forms = new();
        }
    }
}
