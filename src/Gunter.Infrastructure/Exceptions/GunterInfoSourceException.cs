using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunter.Core.Infrastructure.Exceptions
{
    public class GunterInfoSourceException : Exception
    {

        public GunterInfoSourceException(string message) : base(message)
        {

        }

        public GunterInfoSourceException(string message, Exception ex) : base(message, ex)
        {

        }

    }
}
