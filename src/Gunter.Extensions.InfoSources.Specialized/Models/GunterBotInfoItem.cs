using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunter.Extensions.InfoSources.Specialized.Models
{
    public class GunterBotInfoItem
    {
        public string MessageId { get; set; }

        public string ChatId { get; set; }

        public string Sender { get; set; }

        public string MessageText { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
