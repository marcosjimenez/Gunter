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

        public ConsoleViewer()
        {
            InitializeComponent();
        }

        private void AddText(string text)
            =>  txtConsole.AppendText($"{text}{Environment.NewLine}");

        private string ExecuteCommand(string command)
        {
            var retVal = string.Empty;

            AddText($":> {command}");

            var result = string.Empty;
            var parameters = command.Trim().ToLower().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            if (parameters.Count() == 0)
                return String.Empty;

            //result = commandManager.ProcessCommand(parameters);
            //if (!string.IsNullOrWhiteSpace(result))
            //    AddText(result);

            return retVal;          
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
                AddText($"Received mqtt message: {e.Message}");
            };
            messagingClient.ConnectAsync();
        }

    }
}

