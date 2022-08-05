using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunter.Core.Messaging.Models
{
    public class MessageReceivedEventArgs : EventArgs
    {
        public string Message { get; set; }

        public MessageReceivedEventArgs(string message)
        {
            Message = message;
        }

    }
}
