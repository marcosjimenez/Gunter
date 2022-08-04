using Gunter.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunter.Core.Contracts
{
    public interface IGunterVisualizationHandler
    {
        byte[] GetImage();

        string GetHTML();
    }
    public interface IGunterVisualizationHandler<T> : IGunterVisualizationHandler
    {
        
    }
}
