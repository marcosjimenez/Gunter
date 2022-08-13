using Gunter.Core.Infrastructure.Cache;

namespace Gunter.Core.Cache.Commands
{
    public partial class CacheCommandParser
    {
        [CacheCommandMethod(Command = "up", HelpText = "Upload: up <localFilename> [<remoteFileName>]")]
        public string ParseUpload(params string[] parameters)
        {
            if (parameters.Length <= 1)
                return string.Empty;


            var source = parameters[1];
            var destination = Path.GetFileName((parameters.Length == 2) ? source : parameters[2]);


            if (!ExternalDataCache.Instance.TryUploadFile(source, destination, CurrentFolder))
                return $"Cannot upload {source} to {Path.Combine(CurrentFolder.Name, destination)}";
            else
                return string.Empty;
        }
    }
}
