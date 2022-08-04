using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunterAPI.Domain.Models
{
    public class ValoratedSentenceList<T>
    {
        public IList<ValoratedSentence<T>> ValoratedSentences {get;set;}

    }
}
