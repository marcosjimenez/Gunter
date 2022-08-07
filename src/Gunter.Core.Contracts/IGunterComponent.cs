using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunter.Core.Contracts
{
    public interface IGunterComponent
    {
        string ClassId { get; }
        string Id { get; }
        string Name { get; set; }
    }
}
