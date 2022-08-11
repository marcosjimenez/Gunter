using Gunter.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunter.Core.Contracts
{
    public interface IGunterVisualizationHandler : IGunterComponent
    {
        List<string> AvailableVisualizationTypes { get; }

        bool CanHandle(IGunterInfoSource infoSource);

        byte[] GetImage();

        string GetHTML();
    }
}
