using Gunter.Core.Cache;

namespace Gunter.Core.Cache.Commands
{
    public partial class CacheCommandParser
    {
        [CacheCommandMethod(Command = "md", HelpText = "MakeDir: md [directoryname]")]
        public string ParseMkDir(params string[] parameters)
        {
            if (parameters.Length < 1)
                return string.Empty;

            try
            {
                ExternalDataCache.Instance.TryCreateFolder(parameters[1], CurrentFolder, out var folder);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return string.Empty;
        }
    }
}
