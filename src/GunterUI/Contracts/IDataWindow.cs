using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    internal interface IDataWindow
    {
        bool SetExtraData(object data);
        Form Form { get; }

    }
}
