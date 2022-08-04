using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunter.Extensions.InfoSources
{
    public static class InfoSourceConstants
    {
        public const string CAT_COMMUNICATION = "Comunicaciones";
        public const string SUB_BOTS = "Bots";

        public const string CAT_INFORMATION = "Servicios de Información";
        public const string SUB_ENCYCLOPAEDIA = "encyclopaedia";

        public const string CAT_WEATHER = "Meteorología";
        public const string SUB_OFFICIAL = "Predicciones Oficiales";
        public const string SUB_NONOFFICIAL = "Predicciones No Oficiales";

        private static string[] Gategories = { 
            CAT_COMMUNICATION, 
            CAT_INFORMATION, 
            CAT_WEATHER 
        };

        private static string[] SubCategories =
        {
            SUB_OFFICIAL,
            SUB_NONOFFICIAL,
            SUB_ENCYCLOPAEDIA,
            SUB_BOTS
        };

    }
}
