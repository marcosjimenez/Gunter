using Gunter.Core.Cache;
using System.Text;

namespace Gunter.Core.Cache.Commands
{
    public partial class CacheCommandParser
    {
        [CacheCommandMethod(Command = "del", HelpText = "Deletes objects: del [file/dir/coll/vol] [name]")]
        public string ParseDelete(params string[] parameters)
        {
            if (parameters.Length <= 2)
                return "Invalid parameters";

            string objectType = parameters[1];
            string name = parameters[2];

            var retVal = string.Empty;

            switch (parameters[1])
            {
                case "file":
                    retVal = TryDeleteFile(name);
                    break;
                case "coll":
                    retVal = TryDeleteCollection(name);
                    break;
                case "dir":
                    retVal = TryDeleteFolder(name);
                    break;
                case "vol":
                default:
                    retVal = $"Invalid parameter {parameters[1]}";
                    break;
            }

            return retVal;
        }

        public string TryDeleteFile(string fileName)
        {

            return ExternalDataCache.Instance.TryDeleteFile(CurrentFolder, fileName) ? string.Empty : $"cannot delete {fileName}";
        }

        private string TryDeleteFolder(string folderName)
        {
            return ExternalDataCache.Instance.TryDeleteFolder(CurrentFolder, folderName) ? string.Empty : $"Cannot delete {folderName}";
        }

        public string TryDeleteCollection(string collectionName)
        {
            var retVal = ExternalDataCache.Instance.TryDeleteCollection(collectionName) ? string.Empty : $"cannot delete {collectionName}";

            if (retVal.Length > 0)
            {
                StringBuilder sb = new StringBuilder(retVal);
                sb.AppendLine();
                sb.AppendLine("Consider using the complete collection name. Current folder collections:");
                sb.AppendLine();
                foreach (var item in CurrentFolder.Files)
                {
                    sb.AppendLine($"\t{item.Name}");
                }

                return sb.ToString();
            }
            return retVal;
        }
    }
}
