namespace Gunter.Core.Visualizations
{
    public static class TemplateManipulationHelper
    {
        public static string ReplaceVariable(this string mainString, string variable, string value)
            => mainString.Replace($"@@{variable}", value);
    }

}
