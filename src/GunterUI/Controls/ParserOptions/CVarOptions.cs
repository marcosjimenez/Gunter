using CommandLine;

namespace Controls.ParserOptions
{
    [Verb("cvar", HelpText = "Manages variables")]
    public class CVarOptions
    {
        [Option("list", Required = false, HelpText = "List variables")]
        public string Filter { get; set; }

        [Option("add", Required = false, HelpText = "Add variables")]
        public IEnumerable<string> Values { get; set; }

        //[Option(Group = "add", HelpText = "Prefix to append to file name")]
        //public string Add { get; set; }

        //[Option(Group = "remove", HelpText = "Suffix to append to file name")]
        //public string Remove { get; set; }

        //[Option("source", HelpText = "The path of a file to rename")]
        //public string FilePath { get; set; }

    }
}
