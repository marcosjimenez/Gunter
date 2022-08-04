using Gunter.Extensions.Common;
using Gunter.Core.Contracts;
using Gunter.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunter.Extensions.InfoSources.Specialized
{
    public class TwitterInfoSource { }

    //    : InfoSourceBase<TwitterInfoItem>, IInfoSource
    //{
    //    public string Id { get; set; }
    //    public string Name { get; set; }

    //    private SpecialProperties _specialProperties;
    //    public SpecialProperties SpecialProperties { get => _specialProperties; }

    //    public TwitterInfoSource() : base()
    //    {
    //        Id = string.Empty;
    //        Name = string.Empty;

    //        _specialProperties = new SpecialProperties()
    //            .AddOrUpdate("language", "es")
    //            .AddOrUpdate("getfirstpage", true)
    //            .AddOrUpdate("expression", "Mark Hammil")
    //            .AddOrUpdate("preview", string.Empty)
    //            .AddOrUpdate("json", string.Empty);

    //        _mandatoryInputs = new SpecialProperties()
    //            .AddOrUpdate("text", "");
    //    }

    //    private bool _isOnLine = false;
    //    public bool IsOnline { get => _isOnLine; }
       
    //    public override Dictionary<string, TwitterInfoItem> GetLastData()
    //    {
    //        return null;
    //    }

    //    public void SetSpecialProperties(SpecialProperties specialProperties)
    //    {
    //        _specialProperties = specialProperties;
    //    }

    //    public void Update()
    //    {
            
    //    }
    //}
}
