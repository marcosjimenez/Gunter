using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
