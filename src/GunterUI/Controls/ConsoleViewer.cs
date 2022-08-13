using ColorCode;
using ColorCode.Common;
using ColorCode.Parsing;
using ColorCode.Styling;
using Console;
using Gunter.Core.Cache.Commands;
using Gunter.Core.Contracts;
using Gunter.Core.Infrastructure.Cache;
using Gunter.Core.Messaging;
using Gunter.Core.Messaging.Models;

namespace Controls
{
    public partial class ConsoleViewer : UserControl, IMessagingComponent
    {
        private MessagingClient? messagingClient;

        private int recentPosition = 1;
        private int lastCharIndex = 0;
        private List<string> RecentCommands = new();
        public event Action<string> ReceiveMessage;
        public string MessagingClientId => messagingClient?.Id ?? String.Empty;

        private CacheCommandParser commandParser = new();

        public ConsoleViewer()
        {
            InitializeComponent();
        }

        private string GetPrompt()
        => $"{ExternalDataCache.VolumeName}:\\{ commandParser.GetCurrentPath()}>";


        private void AddText(string text)
        {

            //Languages.Load(new ConsoleLanguage());
            //var formatter = new ConsoleLanguageFormatter();
            //var html = formatter.GetRTFString(text, Languages.FindById("GunterConsole"));

            txtConsole.AppendText($"{text}{Environment.NewLine}");
            var lastreturn = txtConsole.Text.LastIndexOf(Environment.NewLine);
            if (txtConsole.SelectionLength == 0)
            {
                txtConsole.SelectionStart = txtConsole.TextLength;
            }
        }

        private string ExecuteCommand(string command)
        {
            var retVal = string.Empty;

            AddText($":> {command}");

            var parameters = command.Trim().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            if (parameters.Count() == 0)
                return string.Empty;

            if (parameters[0].ToLower() == "cls")
            {
                txtConsole.Clear();
                lastCharIndex = 0;
            }
            else
            {
                var result = commandParser.ParseCommand(parameters);
                if (!string.IsNullOrWhiteSpace(result))
                    AddText(result);
            }

            return retVal;          
        }

        private void ConsoleView_Load(object sender, EventArgs e)
        {
            GetClient();
            txtCommand.Text = GetPrompt();
            txtCommand.SelectionStart = GetPrompt().Length;
        }

        private void txtCommand_KeyUp(object sender, KeyEventArgs e)
        {
            
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
            messagingClient.TextMessageReceived += (sender, e) =>
            {
                AddText($"Received mqtt message: {e.Message}");
            };
            messagingClient.ConnectAsync();
        }

        private void txtCommand_KeyDown(object sender, KeyEventArgs e)
        {
            var prompt = GetPrompt();
            var command = txtCommand.Text.Substring(prompt.Length, txtCommand.Text.Length - prompt.Length).Replace("\r\n",string.Empty);

            switch (e.KeyCode)
            {
                case Keys.Back:
                    e.SuppressKeyPress = (txtCommand.SelectionStart <= prompt.Length);
                    break;
                case Keys.C:
                case Keys.V:
                    e.SuppressKeyPress = (txtCommand.SelectionStart < prompt.Length) || e.Control;
                    e.Handled = true;
                    break;
                case Keys.Return:
                    ExecuteCommand(command);
                    RecentCommands.Add(command);
                    txtCommand.AutoCompleteCustomSource.Add(command);
                    recentPosition = 0;
                    prompt = GetPrompt();
                    txtCommand.Text = prompt;
                    txtCommand.SelectionStart = prompt.Length;
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                    break;
                case Keys.Up:
                    var lastCommand = GetLastCommand();
                    if (!string.IsNullOrWhiteSpace(lastCommand))
                    {
                        txtCommand.Text = String.Concat(prompt, lastCommand);
                        txtCommand.SelectionStart = prompt.Length;

                    }
                    e.Handled = true;
                    break;
                case Keys.Down:
                    var nextCommand = GetNextCommand();
                    if (!string.IsNullOrWhiteSpace(nextCommand))
                    {
                        txtCommand.Text = String.Concat(prompt, nextCommand);
                        txtCommand.SelectionStart = prompt.Length;

                    }
                    e.Handled = true;
                    break;
                default:
                    e.SuppressKeyPress = (txtCommand.SelectionStart < prompt.Length);
                    break;
            }
        }
    }
}

