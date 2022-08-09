using CoreHtmlToImage;
using Gunter.Core.Contracts;
using Gunter.Extensions.InfoSources.Specialized;
using Gunter.Extensions.InfoSources.Specialized.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunter.Extensions.Visualization.Handlers
{
    public class GunterBotVisualizationHandler : VisualizationHandlerBase<GunterBotInfoSource>, IGunterVisualizationHandler
    {

        public new string Name { get; set; } = "Visor de GunterBot";

        private GunterBotInfoSource objectToDraw;

        protected string HTML_Body = @"
<!DOCTYPE html>
<html>
<body>

<div>
	<h1>@@TITLE</h1>
";
        protected string HTML_Template = @"
    <div>
        <h3>Message from, @@SENDER AT @@TIME</h3>
        <span>@@MESSAGE</span>
    </div>
    
</div>
";
        protected string HTML_Footer = @"
</body>
</html>
";

        public GunterBotVisualizationHandler(string id)
        {
            Id = Id;
        }

        public GunterBotVisualizationHandler(GunterBotInfoSource infoSource)
        {
            objectToDraw = infoSource;
        }

        public string GetHTML()
        {
            var messages = objectToDraw.GetLastData();
            if (messages is null || messages.Count == 0)
                return string.Empty;

            var sb = new StringBuilder(HTML_Body);
            foreach (var message in messages.Values)
            {
                sb.AppendLine(HTML_Template
                    .ReplaceVariable("SENDER", message.Sender)
                    .ReplaceVariable("TIME", message.TimeStamp.ToShortDateString())
                    .ReplaceVariable("MESSAGE", message.MessageText));
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

        private rootDia GetPrediction(AEMETResponseModel model)
            => model.prediccion
            .Where(x => x.fecha == DateTime.Now.Date).Single();


    }
}
