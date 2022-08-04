using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunter.Core.Messaging.Contracts
{
    public interface IMessage
    {
        string Id { get; }
        string Title { get; }
        string Message { get; }
        IEnumerable<object> Attachments { get; }
    }
}
