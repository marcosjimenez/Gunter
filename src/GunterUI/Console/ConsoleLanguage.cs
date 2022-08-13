using ColorCode;
using ColorCode.Common;

namespace Console
{
    public class ConsoleLanguage : ILanguage
    {
        public string Id { get => "GunterConsole"; }

        public string FirstLinePattern { get => null; }

        public string Name { get => "Gunter Console"; }
        public string CssClassName { get => "GunterConsole"; }


        public IList<LanguageRule> Rules
        {
            get
            {
                return new List<LanguageRule>
                           {

                               // strings
                               new LanguageRule(
                                   "$",
                                   new Dictionary<int, string>
                                       {
                                           { 0, ScopeName.XmlAttribute },
                                       }),

                               // code block
                               //new LanguageRule(
                               //    @"^([ ]{4}(?![ ])(?:.|\r?\n[ ]{4})*)|^(```+[ \t]*\w*)((?:[ \t\r\n]|.)*?)(^```+)[ \t]*\r?$",
                               //    new Dictionary<int, string>
                               //        {
                               //            { 1, ScopeName.MarkdownCode },
                               //            { 2, ScopeName.XmlDocTag },
                               //            { 3, ScopeName.MarkdownCode },
                               //            { 4, ScopeName.XmlDocTag },
                               //        }),

                               //// strings
                               //new LanguageRule(
                               //    @"""[^""\n]+?""|'[\w\-_]+'",
                               //    new Dictionary<int, string>
                               //        {
                               //            { 0, ScopeName.String },
                               //        }),

                               // html tag
                               new LanguageRule(
                                   @"</?\w.*?>",
                                   new Dictionary<int, string>
                                       {
                                           { 0, ScopeName.HtmlTagDelimiter },
                                       }),

                               new LanguageRule (
                                   @"\[?\w.*?\]",
                                   new Dictionary<int, string>
                                       {
                                           { 0, ScopeName.HtmlTagDelimiter },
                                       }),


                               // html entity
                               new LanguageRule(
                                   @"\&\#?\w+?;",
                                   new Dictionary<int, string>
                                       {
                                           { 0, ScopeName.HtmlEntity },
                                       }),
                           };
            }
        }


        public bool HasAlias(string lang)
        {
            switch (lang.ToLower())
            {
                case "bat":
                    return true;

                default:
                    return false;
            }
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
