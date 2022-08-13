namespace Gunter.Core.Messaging.Models
{
    public class TextMessageReceivedEventArgs : EventArgs
    {
        public string Message { get; set; }

        public TextMessageReceivedEventArgs(string message)
        {
            Message = message;
        }

    }
}
