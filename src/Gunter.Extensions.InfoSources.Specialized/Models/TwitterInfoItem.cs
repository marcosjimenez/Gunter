using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunter.Extensions.InfoSources.Specialized.Models
{
    public class TwitterInfoItem
    {
        public string Id { get; set; }
        public string PersonId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}
