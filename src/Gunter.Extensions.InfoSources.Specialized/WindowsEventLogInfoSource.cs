using Gunter.Extensions.Common;
using Gunter.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunter.Extensions.InfoSources.Specialized
{
    public class WindowsEventLogInfoSource { }
    //: InfoSourceBase<WindowsEventLogInfoItem>, IInfoSource
    //{
    //    public string Id { get; set; }
    //    public string Name { get; set; }

    //    private SpecialProperties _specialProperties;

    //    public SpecialProperties SpecialProperties => _specialProperties;

    //    public bool IsOnline => true;

    //    private Dictionary<string, WindowsEventLogInfoItem> data;

    //    public override Dictionary<string, WindowsEventLogInfoItem> GetLastData()
    //    {
    //        return data;
    //    }

    //    public void SetSpecialProperties(SpecialProperties specialProperties)
    //    {
    //        _specialProperties = specialProperties;
    //    }

    //    public void Update()
    //    {
            
    //    }

    //    public WindowsEventLogInfoSource()
    //    {
    //        Id = string.Empty;
    //        Name = string.Empty;
    //        data = new Dictionary<string, WindowsEventLogInfoItem>();
    //        _specialProperties = new SpecialProperties();
    //        _specialProperties.AddOrUpdate("Type", typeof(WindowsEventLogInfoItem).ToString());
    //        _specialProperties.AddOrUpdate("Data", data);
    //    }
    //}
}
