using CommandLine;
using CommandLine.Text;
using Controls.ParserOptions;
using Gunter.Core.Contracts;
using Gunter.Core.Messaging;
using Gunter.Core.Messaging.Models;

namespace Controls
{
    public partial class ConsoleViewer : UserControl, IMessagingComponent
    {
        private MessagingClient? messagingClient;

        private int recentPosition = 1;
        private List<string> RecentCommands = new();
        public event Action<string> ReceiveMessage;
        public string MessagingClientId => messagingClient?.Id ?? String.Empty;

        private readonly Parser parser;


        public ConsoleViewer()
        {
            InitializeComponent();
            parser = new Parser(config => config.HelpWriter = null);
        }

        private void AddText(string text)
            =>  txtConsole.AppendText($"{text}{Environment.NewLine}");


        private string ParseCommand(params string[] args)
        {
            var helpWriter = new StringWriter();
            var parser = new Parser(with => with.HelpWriter = helpWriter);

            var parserResult = parser.ParseArguments<MessageOptions, CVarOptions>(args);

            return parserResult.MapResult(
                       (MessageOptions opts) => RunMessageCommand(opts),
                       (CVarOptions opts) => RunCvarCommand(opts),
                        errs => DisplayHelp(parserResult, errs));
        }

        static string DisplayHelp(ParserResult<object> parserResult, IEnumerable<Error> errs)
        {
            var helpText = HelpText.AutoBuild(parserResult, h =>
            {
                h.AutoHelp = false;     // hides --help
                h.AutoVersion = false;  // hides --version
                h.Copyright = String.Empty;
                h.Heading = String.Empty;
                return HelpText.DefaultParsingErrorsHandler(parserResult, h);
            }, e => e);
            return helpText;
        }

        private string RunMessageCommand(MessageOptions options)
        {
            var retVal = string.Empty;

            if (options.Send?.Count() > 0)
            {
                var parameters = options.Send.ToList();
                messagingClient.SendToComponent(parameters[0].ToString(), parameters[1].ToString());

                retVal = $"Message sent to { parameters[1] }";
            }

            return retVal;
        }


        private string RunCvarCommand(CVarOptions options)
        {
            var retVal = string.Empty;

            


            return retVal;
        }

        private string ExecuteCommand(string command)
        {
            var retVal = string.Empty;

            AddText($":> {command}");

            var result = string.Empty;
            var parameters = command.Trim().ToLower().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            if (parameters.Count() == 0)
                return String.Empty;

            result = ParseCommand(parameters);
            AddText(result);
            return retVal;

            //switch (parameters[0])
            //{
            //    case "sendmessage":
            //        if (parameters.Length > 2)
            //        {
            //            messagingClient.SendToComponent(parameters[2], parameters[1]);
            //        }
            //        break;
            //    case "list_msgcli" :
            //        var sb = new StringBuilder();
            //        foreach(var item in MessagingHelper.Instance.GetClientIds())
            //        {
            //            sb.AppendLine(item);
            //        }
            //        result = sb.ToString();
            //        break;
            //    case "cls":
            //        txtConsole.Clear();
            //        break;
            //    case "ver":
            //        result = "Ver 1.0";
            //        break;
            //    default:
            //        result = $"Invalid command: {command}";
            //        break;
            //}
        }

        private void ConsoleView_Load(object sender, EventArgs e)
        {
            GetClient();
        }

        private void txtCommand_KeyUp(object sender, KeyEventArgs e)
        {
            var command = txtCommand.Text;
            switch (e.KeyCode)
            {
                case Keys.Return:
                    ExecuteCommand(command);
                    RecentCommands.Add(command);
                    txtCommand.AutoCompleteCustomSource.Add(command);
                    recentPosition = 0;
                    txtCommand.Clear();
                    break;
                case Keys.Up:
                    var lastCommand = GetLastCommand();
                    if (!string.IsNullOrWhiteSpace(lastCommand))
                        txtCommand.Text = lastCommand;
                    break;
                case Keys.Down:
                    var nextCommand = GetNextCommand();
                    if (!string.IsNullOrWhiteSpace(nextCommand))
                        txtCommand.Text = nextCommand;
                    break;
            }
        }

        private string GetLastCommand()
        {
            string retVal = string.Empty;

            if (recentPosition < RecentCommands.Count && recentPosition >= 0)
            {
                recentPosition++;
                retVal = RecentCommands[RecentCommands.Count() - recentPosition];
            }

            return retVal;
        }

        private string GetNextCommand()
        {
            string retVal = string.Empty;

            if (recentPosition > 1)
            {
                recentPosition--;
                retVal = RecentCommands[RecentCommands.Count() - recentPosition];
            }

            return retVal;
        }


        public void GetClient()
        {
            messagingClient = MessagingHelper.Instance.CreateClient("ConsoleViewer");
            messagingClient.MessageReceived += (sender, e) =>
            {
                AddText(e.Message);
            };
            messagingClient.ConnectAsync();
        }

    }
}

