using System.Text;

namespace Gunter.Core.Cache.Commands
{
    public partial class CacheCommandParser
    {
        [CacheCommandMethod(Command = "help", HelpText = "Show Help: help [command]")]
        public string ParseHelp(params string[] parameters)
        {
            if (parameters.Length < 1)
                return string.Empty;

            string command = parameters.Length > 1 ? parameters[1] : string.Empty;

            var methods = GetType()
                .GetMethods()
                .Where(m => m.GetCustomAttributes(typeof(CacheCommandMethodAttribute), false).Length > 0)
                .ToArray();

            var commandList = new List<KeyValuePair<string, string>>();
            foreach (var method in methods)
            {
                var key = method.GetCustomAttributes(true).FirstOrDefault() as CacheCommandMethodAttribute;
                commandList.Add(new KeyValuePair<string, string>(key.Command, key.HelpText));
            }

            var sb = new StringBuilder();
            sb.AppendLine("Available commands:");
            foreach (var key in commandList.OrderBy(x => x.Key))
                sb.AppendLine($"{key.Key}\t\t{key.Value}");

            return sb.ToString();
        }
    }
}
