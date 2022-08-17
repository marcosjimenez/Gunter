using GunterUI.Dialogs;

namespace GunterUI.Extensions
{
    public static class Prompt
    {
        public static bool ShowPromptDialog(string text, string caption, string value, out string result)
        {
            var prompt = new PromptForm(caption, text, value);
            var retVal = prompt.ShowDialog();
            result = retVal == DialogResult.OK ? prompt.Value : string.Empty;

            return retVal == DialogResult.OK;
        }
    }
}
