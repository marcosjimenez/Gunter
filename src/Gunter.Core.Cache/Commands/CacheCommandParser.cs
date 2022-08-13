using Gunter.Core.Infrastructure.Cache;
using System.Linq.Expressions;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace Gunter.Core.Cache.Commands
{
    public partial class CacheCommandParser
    {
        private static Dictionary<string, string> commands = new();
        public CacheFolder CurrentFolder;

        public CacheCommandParser()
        {
            CurrentFolder = ExternalDataCache.Instance.RootFolder;

            var methods = GetType()
                .GetMethods()
                .Where(m => m.GetCustomAttributes(typeof(CacheCommandMethodAttribute), false).Length > 0)
                .ToArray();

            foreach(var method in methods)
            {
                var key = method.GetCustomAttributes(true).FirstOrDefault() as CacheCommandMethodAttribute;
                commands.Add(key.Command, method.Name);
            }

        }

        public string GetCurrentPath()
        {
            var folder = CurrentFolder;
            string retVal = "";
            do
            {
                if (retVal.Length == 0)
                {
                    retVal = $"{folder.Name}\\";
                }
                else
                {
                    retVal = retVal.Insert(0, $"{folder.Name}\\");
                }

                folder = folder.Parent;
            } while (folder is not null);

            return retVal;
        }

        public string ParseCommand(params string[] parameters)
        {
            if (parameters is null || parameters.Count() == 0)
                return string.Empty;

            var strCommand = parameters[0].ToLower();
            if (commands.ContainsKey(strCommand))
            {
                var method= typeof(CacheCommandParser).GetMethod(commands[strCommand]);
                var result = (string)method.Invoke(this, new[] { parameters });
                return result.ToString();
            }
            else
                return $"Invalid command {strCommand}";
        }

    }
}
