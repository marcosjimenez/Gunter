using CoreHtmlToImage;
using Gunter.Core.Contracts;
using Gunter.Extensions.InfoSources.Specialized;
using Gunter.Extensions.Plugins.WindowsPerformanceCounters;
using System.Text;

namespace Gunter.Extensions.Visualization.Handlers
{
    public class WPCountersVisualizationHandler : VisualizationHandlerBase<WPCountersInfoSource>, IGunterVisualizationHandler
    {
        public new string Name { get; set; } = "Visor de PerformanceCounters";
        private WPCountersInfoSource objectToDraw;

        protected string HTML_Body = @"
<!DOCTYPE html>
<html>
<body>

<div>
	<h1>@@TITLE</h1>
";
        protected string HTML_Template = @"
    <div>
        <h3>@@NAME</h3>
        <span>@@VALUE</span>
    </div>
    
</div>
";
        protected string HTML_Footer = @"
</body>
</html>
";

        public WPCountersVisualizationHandler(string id)
        {
            Id = id;
        }

        public WPCountersVisualizationHandler(WPCountersInfoSource infoSource)
        {
            objectToDraw = infoSource;
        }

        public string GetHTML()
        {
            var values = objectToDraw?.LastItem;

            var sb = new StringBuilder(HTML_Body);
            if (values is not null)
            {
                foreach (var data in objectToDraw.GetLastData())
                    foreach (var item in data.Value.CounterData)
                        sb.AppendLine(HTML_Template
                            .ReplaceVariable("NAME", item.Name)
                            .ReplaceVariable("VALUE", item.Name));
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
