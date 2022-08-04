using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunter.Extensions.Models
{
    public abstract class SystemEventLogValoration<T>
    {
        protected string Id = Guid.NewGuid().ToString();

        public abstract T Severity { get; set; }

    }
}
