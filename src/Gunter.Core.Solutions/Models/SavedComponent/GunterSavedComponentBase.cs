using Gunter.Extensions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunter.Core.Solutions.Models.SavedComponent
{
    public abstract class GunterSavedComponentBase<T>
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public SpecialProperties SpecialProperties { get; set; } = new SpecialProperties();
        public string SystemType { get; set; } = string.Empty;
    }
}
