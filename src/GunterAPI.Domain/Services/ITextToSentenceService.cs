using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunterAPI.Domain.Services
{
    internal interface ITextToSentenceService
    {
        string TryConvert(string text);
    }
}
