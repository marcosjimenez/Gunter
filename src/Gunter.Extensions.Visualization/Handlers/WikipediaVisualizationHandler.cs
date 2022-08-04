using CoreHtmlToImage;
using Gunter.Core.Contracts;
using Gunter.Extensions.InfoSources.Specialized;
using System.Text;

namespace Gunter.Extensions.Visualization.Handlers
{
    public  class WikipediaVisualizationHandler<T> : IGunterVisualizationHandler<T> where T : WikipediaInfoSource
    {

        public bool CanHandle(T value) => value?.IsReady() ?? false;

        private WikipediaInfoSource objectToDraw;

        protected string HTML_Body = @"
<!DOCTYPE html>
<html>
<body>

<div>
	<h1>@@TITLE</h1>
";
        protected string HTML_Template = @"
    <div>
        <span>@@DESCRIPTION</span>
    </div>
    <h3>Information from Wikipedia, <a href=""@@URL"">available here</a></h3>
</div>
";
        protected string HTML_Footer = @"
</body>
</html>
";

        public WikipediaVisualizationHandler(WikipediaInfoSource infoSource)
        {
            objectToDraw = infoSource;
        }

        public string GetHTML()
        {
            var prediccion = objectToDraw.LastItem;

            var sb = new StringBuilder(HTML_Body);
            if (prediccion is not null)
            { 
                foreach (var data in objectToDraw.GetLastData())
                {
                    sb.AppendLine(HTML_Template
                        .ReplaceVariable("TITLE", prediccion.Title)
                        .ReplaceVariable("DESCRIPTION", prediccion.Preview)
                        .ReplaceVariable("URL", prediccion.ConstantUrl.ToString()));
                }
            }
            sb.AppendLine(HTML_Footer);
            return sb.ToString();
        }

        public byte[] GetImage()
        {
            var converter = new HtmlConverter();
            var bytes = converter.FromHtmlString(GetHTML());

            return bytes;
        }

    }
}
