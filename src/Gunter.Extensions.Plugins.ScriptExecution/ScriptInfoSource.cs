using Gunter.Core.Components;
using Gunter.Core.Components.BaseComponents;
using Gunter.Core.Contracts;
using Gunter.Core.Models;
using Gunter.Extensions.InfoSources.Specialized.Models;

namespace Gunter.Extensions.InfoSources.Specialized
{
    public class ScriptInfoSource : InfoSourceBase<ScriptInfoSourceItem>, IGunterInfoSource
    {
        public string Category { get => InfoSourceConstants.CAT_EXECUTION; }
        public string SubCategory { get => InfoSourceConstants.SUB_SCRIPT; }

        private ScriptInfoSourceItem lastItem { get; set; } = new();


        private Dictionary<string, ScriptInfoSourceItem> data = new();

        public ScriptInfoSourceItem LastItem { get => lastItem; }

        public bool IsOnline => false;

        private readonly IGunterInfoItem? _container;
        public IGunterInfoItem? Container { get => _container; }

        private const string PROP_EXECUTABLE = "Executable";
        private const string PROP_FILENAME = "File path";
        //private ScriptEngine _engine;
        //private ScriptScope _scope;

        public ScriptInfoSource() : base()
        {
            Name = "Python Script InfoSource";
            SpecialProperties = new SpecialProperties();
            _mandatoryInputs.AddOrUpdate(PROP_EXECUTABLE, "python");
            _mandatoryInputs.AddOrUpdate(PROP_FILENAME, string.Empty);
            lastItem = new();
        }

        public ScriptInfoSource(string id)
        {
            Id = id;
        }

        public ScriptInfoSource(IGunterInfoItem container, string id, string name)
        {
            Id = id;
            Name = name;
            SpecialProperties = new SpecialProperties();
            _mandatoryInputs.AddOrUpdate(PROP_EXECUTABLE, "python");
            _mandatoryInputs.AddOrUpdate(PROP_FILENAME, string.Empty);
            lastItem = new();
            _container = container;
        }

        public object GetLastItem()
        {
            if (lastItem is null)
                GetLastData();

            return lastItem;
        }

        public override Dictionary<string, ScriptInfoSourceItem> GetLastData()
        {
            SpecialProperties.TryGetProperty(PROP_FILENAME, out string? fileName);

            var result = ExecuteScript(fileName);
            if (string.IsNullOrEmpty(result))
                return data;

            lastItem = new ScriptInfoSourceItem { Result = result };

            if (data.ContainsKey(fileName))
                data[fileName] = lastItem;
            else
                data.Add(fileName, LastItem);

            return data;
        }

        public void Update()
        {
            GetLastData();
        }

        private string ExecuteScript(string fileName)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            process.StartInfo.FileName = "python";
            process.StartInfo.Arguments = fileName;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardInput = true;
            process.Start();
            string result = "";
            while (!process.HasExited)
            {
                result += process.StandardOutput.ReadToEnd();
            }
            return result;
        }

        //private ScriptEngine GetEngine()
        //{ 
        //    if(_engine is null)
        //    {
        //        _engine = Python.CreateEngine();
        //        Dictionary<string, object> parameters = new();
        //        foreach(var item in SpecialProperties.Properties)
        //            parameters.Add(item.Key, item.Value);
        //        _scope = _engine.CreateScope(parameters);
        //    }

        //    return _engine;
        //}


        //private PyhtonScriptInfoSourceItem ExecuteScript(string fileName)
        //{
        //    PyhtonScriptInfoSourceItem retVal = new();

        //    var engine = GetEngine();
        //    if (engine is null)
        //        return retVal;

        //    using var writer = new StringWriter();
        //    engine.Runtime.IO.RedirectToConsole();
        //    var oldOut = Console.Out;
        //    Console.SetOut(writer);

        //    try
        //    {
        //        _scope = engine.ExecuteFile(fileName);

        //    }
        //    catch(Exception ex)
        //    {
        //        writer.WriteLine(ex.Message);
        //        writer.Flush();
        //    }

        //    retVal.Result = writer.GetStringBuilder().ToString();
        //    writer.Close();
        //    Console.SetOut(oldOut);

        //    return retVal;
        //}
    }
}
