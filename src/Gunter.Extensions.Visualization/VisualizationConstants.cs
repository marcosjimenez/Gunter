using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunter.Extensions.Visualization
{
    public static class VisualizationConstants
    {
        public const string DisplayStyleHTML = "HTML";
        public const string DisplayStyleString = "String";
        public const string DisplayStyleImage = "Image";

        public readonly static string[] DisplayStyles = new [] {
            DisplayStyleString,
            DisplayStyleHTML,
            DisplayStyleImage
        };

    }
}
