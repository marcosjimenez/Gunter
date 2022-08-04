using GunterUI.Dialogs;

namespace GunterUI.Extensions
{
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption, string value)
        {
            var prompt = new PromptForm(caption, text, value);
            return prompt.ShowDialog() == DialogResult.OK ? prompt.Value : "";
        }
    }
}
