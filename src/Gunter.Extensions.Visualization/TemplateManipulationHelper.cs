using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunter.Extensions.Visualization
{
    public static class TemplateManipulationHelper
    {
        public static string ReplaceVariable(this string mainString, string variable, string value)
            => mainString.Replace($"@@{variable}", value);
    }

}
