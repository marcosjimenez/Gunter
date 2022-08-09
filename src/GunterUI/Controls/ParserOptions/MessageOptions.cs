using CommandLine;

namespace Controls.ParserOptions
{
    [Verb("message", HelpText = "Manages MQTT messages")]
    public class MessageOptions
    {
        [Option('s', "send", Required = false, HelpText = "Send message")]
        public IEnumerable<string> Send { get; set; }


        [Option('l', "list", Required = false, HelpText = "List connected clients")]
        public string ListParameter { get; set; }
    }
}
