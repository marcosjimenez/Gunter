using Gunter.Core.Infrastructure.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunter.Core.Cache.Commands
{
    public partial class CacheCommandParser
    {

        CacheFolder? ParentFolder;

        [CacheCommandMethod(Command = "cd", HelpText = "ChangeDir: cd [directoryname]")]
        public string ParseChangeDir(params string[] parameters)
        {
            if (parameters.Length <= 1)
                return CurrentFolder.Name;

            try
            {
                var paramFolderName = parameters[1];
                if (paramFolderName == "\\")
                { 
                    CurrentFolder = ExternalDataCache.Instance.RootFolder;
                    ParentFolder = null;
                }
                else if (paramFolderName == ".." && ParentFolder is not null)
                {
                    CurrentFolder = ParentFolder;
                    ParentFolder = ParentFolder.Parent;
                }
                else
                {
                    var folder = CurrentFolder.Folders.Where(x => x.Value.Name == paramFolderName)
                        .SingleOrDefault().Value;
                    if (folder is null)
                        return $"Invalid folder {paramFolderName}";

                    var parent = CurrentFolder;
                    CurrentFolder = folder;
                    folder.Parent = parent;
                    ParentFolder = parent;
                    
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return string.Empty;
        }
    }
}
