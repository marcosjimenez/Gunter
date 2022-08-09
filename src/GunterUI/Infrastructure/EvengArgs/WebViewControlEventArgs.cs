using Gunter.Core.Solutions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EvengArgs
{
    public class WebViewControlEventArgs
    {
        public string Id { get; set; } = string.Empty;
        public string HTML { get; set; } = string.Empty;
        public Uri Uri { get; set; } = new Uri("http://localhost");
        public string Name { get; set; } = string.Empty;
        public GunterSolutionItemType SolutionItemType { get; set; } = GunterSolutionItemType.OtherItem;
    }
}
