using Gunter.Core.Infrastructure.Cache;
using System.Text;

namespace Gunter.Core.Cache.Commands
{
    public partial class CacheCommandParser
    { 
        [CacheCommandMethod(Command = "dir", HelpText = "Show files, directories and collections: dir [directoryname] [filtro]")]
        public string ParseDir(params string[] parameters)
        {
            if (parameters.Length < 1)
                return string.Empty;

            string directory = parameters.Length > 1 ? parameters[1] : string.Empty;

            var sb = new StringBuilder();
            sb.AppendLine($"El volumen de la unidad es {ExternalDataCache.VolumeName}");
            sb.AppendLine();
            sb.Append("Directorio de ");
            sb.AppendLine($"{ExternalDataCache.VolumeName}:{CurrentFolder.Name}");
            sb.AppendLine();

            if (!string.IsNullOrEmpty(CurrentFolder.ParentId))
            {
                sb.AppendLine($"<DIR>\t[.]");
                sb.AppendLine($"<DIR>\t[..]");
            }

            foreach (var dir in CurrentFolder.Folders)
                sb.AppendLine($"<DIR>\t{dir.Value.Name}");

            var result = CurrentFolder.Files;
            var collections = result
                .Where(x => x.ToString().IndexOf('_') > 1)
                .Select(x => x.ToString().Split('_').Skip(1).FirstOrDefault() ?? x.ToString());

            foreach (var col in collections)
                sb.AppendLine($"<COL>\t{col}");

            foreach (var file in CurrentFolder.Files)
                sb.AppendLine($"\t{file.Name}\t\t{new FileInfo(file.LocalPath).Length.ToString("0,0")} bytes");

            sb.AppendLine();
            sb.AppendLine($"Colecciones\t{collections.Count()}");
            sb.AppendLine($"Archivos\t{CurrentFolder.Files.Count()} ");
            sb.AppendLine($"Directorios\t{CurrentFolder.Folders.Count()}");

            return sb.ToString();
        }
    }
}
