using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunter.Commands
{
    internal interface IExecutableCommand
    {
        string CommandName { get; }

        bool IsAsync { get; }

        bool IsRunning { get; }

        void Execute();
    }
}
