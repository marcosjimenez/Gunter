using CommandLine;

namespace Gunter.Commands
{
    [Verb("persona")]
    internal class PersonaOptions : IExecutableCommand
    {
        public string CommandName => "persona";

        [Option(Group = "command", HelpText = "main command")]
        public string Command { get; set; }

        [Option(Group = "command", HelpText = "main command")]
        public IEnumerable<string> Arguments { get; set; }

        public string Description { get => string.Empty; }

        public bool IsAsync => false;

        public bool IsRunning => false;

        public PersonaOptions()
        {
            Arguments = new HashSet<string>();
            Command = string.Empty;
        }

        public void Execute()
        {
            Console.WriteLine(Command);
            foreach (var arg in Arguments)
                Console.WriteLine(arg);

        }
    }
}
