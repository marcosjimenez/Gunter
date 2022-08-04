using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunterAPI.Domain.Models
{
    public class ValoratedSentence<T>
    {
        public string Sentence { get; set; }

        public T Valoration { get; set; }
    }
}
