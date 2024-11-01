﻿using ColorCode;
using ColorCode.Common;
using ColorCode.Parsing;
using ColorCode.Styling;
using System.Net;
using System.Text;

namespace Console
{
    public class ConsoleLanguageFormatter : CodeColorizerBase
    {
        private TextWriter Writer { get; set; }

        /// <summary>
        /// Creates a <see cref="HtmlFormatter"/>, for creating HTML to display Syntax Highlighted code.
        /// </summary>
        /// <param name="Style">The Custom styles to Apply to the formatted Code.</param>
        /// <param name="languageParser">The language parser that the <see cref="HtmlFormatter"/> instance will use for its lifetime.</param>
        public ConsoleLanguageFormatter(StyleDictionary Style = null, ILanguageParser languageParser = null) : base(Style, languageParser)
        {
        }

        /// <summary>
        /// Creates the HTML Markup, which can be saved to a .html file.
        /// </summary>
        /// <param name="sourceCode">The source code to colorize.</param>
        /// <param name="language">The language to use to colorize the source code.</param>
        /// <returns>Colorised HTML Markup.</returns>
        public string GetRTFString(string sourceCode, ILanguage language)
        {
            var buffer = new StringBuilder(sourceCode.Length * 2);

            using (TextWriter writer = new StringWriter(buffer))
            {
                Writer = writer;
                WriteHeader(language);

                languageParser.Parse(sourceCode, language, (parsedSourceCode, captures) => Write(parsedSourceCode, captures));

                WriteFooter(language);

                writer.Flush();
            }

            return buffer.ToString();
        }

        protected override void Write(string parsedSourceCode, IList<Scope> scopes)
        {
            var styleInsertions = new List<TextInsertion>();

            foreach (Scope scope in scopes)
                GetStyleInsertionsForCapturedStyle(scope, styleInsertions);

            styleInsertions.SortStable((x, y) => x.Index.CompareTo(y.Index));

            int offset = 0;

            foreach (TextInsertion styleInsertion in styleInsertions)
            {
                var text = parsedSourceCode.Substring(offset, styleInsertion.Index - offset);
                Writer.Write(WebUtility.HtmlEncode(text));
                if (string.IsNullOrEmpty(styleInsertion.Text))
                    BuildSpanForCapturedStyle(styleInsertion.Scope);
                else
                    Writer.Write(styleInsertion.Text);
                offset = styleInsertion.Index;
            }

            Writer.Write(WebUtility.HtmlEncode(parsedSourceCode.Substring(offset)));
        }
        private void WriteHeader(ILanguage language)
        {
            WriteHeaderDivStart();
            //WriteHeaderPreStart();
            Writer.WriteLine();
        }

        private void WriteFooter(ILanguage language)
        {
            Writer.WriteLine();
            //WriteHeaderPreEnd();
            WriteHeaderDivEnd();
        }

        private void GetStyleInsertionsForCapturedStyle(Scope scope, ICollection<TextInsertion> styleInsertions)
        {
            styleInsertions.Add(new TextInsertion
            {
                Index = scope.Index,
                Scope = scope
            });

            foreach (Scope childScope in scope.Children)
                GetStyleInsertionsForCapturedStyle(childScope, styleInsertions);

            styleInsertions.Add(new TextInsertion
            {
                Index = scope.Index + scope.Length,
                Text = "}$NL"
            });
        }

        private void BuildSpanForCapturedStyle(Scope scope)
        {
            string foreground = string.Empty;
            string background = string.Empty;
            bool italic = false;
            bool bold = false;

            if (Styles.Contains(scope.Name))
            {
                Style style = Styles[scope.Name];

                foreground = style.Foreground;
                background = style.Background;
                italic = style.Italic;
                bold = style.Bold;
            }

            WriteElementStart("", foreground, background, italic, bold);
        }

        private void WriteHeaderDivEnd()
        {
            WriteElementEnd("");
        }

        private void WriteElementEnd(string elementName)
        {
            Writer.Write("}");
        }

        private void WriteHeaderPreEnd()
        {
            WriteElementEnd("pre");
        }

        private void WriteHeaderPreStart()
        {
            WriteElementStart("pre");
        }

        private void WriteHeaderDivStart()
        {
            string foreground = string.Empty;
            string background = string.Empty;

            if (Styles.Contains(ScopeName.PlainText))
            {
                Style plainTextStyle = Styles[ScopeName.PlainText];

                foreground = plainTextStyle.Foreground;
                background = plainTextStyle.Background;
            }

            WriteElementStart("\\rtf1\\ansi\\deff0 {\\fonttbl {\\f0 Consoles;}}", foreground, background);
        }

        private void WriteElementStart(string @elementName, string foreground = null, string background = null, bool italic = false, bool bold = false)
        {
            Writer.Write(String.Concat("{", elementName));

            //if (!string.IsNullOrWhiteSpace(foreground) || !string.IsNullOrWhiteSpace(background) || italic || bold)
            //{
            //    Writer.Write(" style=\"");

            //    if (!string.IsNullOrWhiteSpace(foreground))
            //        Writer.Write("color:{0};", foreground);

            //    if (!string.IsNullOrWhiteSpace(background))
            //        Writer.Write("background-color:{0};", background);

            //    if (italic)
            //        Writer.Write("font-style: italic;");

            //    if (bold)
            //        Writer.Write("font-weight: bold;");

            //    Writer.Write("\"");
            //}

            //Writer.Write(">");
        }
    }
}