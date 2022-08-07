using AngleSharp;
using AngleSharp.Dom;
using Gunter.Extensions.Common;
using Gunter.Core.Contracts;
using Gunter.Infrastructure.Cache;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static Gunter.Extensions.InfoSources.Specialized.Models.AEMETInfoItem;
using Gunter.Extensions.InfoSources.Specialized.Models;
using Gunter.Core.Infrastructure.Helpers;
using Gunter.Core.Constants;

namespace Gunter.Extensions.InfoSources.Specialized
{
    public class AEMETInfoSource : InfoSourceBase<string>, IGunterInfoSource
    {
        private AEMETResponseModel lastItem { get; set; }
        private readonly IGunterInfoItem _container;
        private readonly TimeSpan MinInterval = new TimeSpan();

        private const string BaseAddress = "https://www.aemet.es/xml/municipios/";
        private const string Chiloeches = "localidad_19105.xml";
        private Dictionary<string, string> data = new();

        public AEMETResponseModel LastItem { get => lastItem; }
        public SpecialProperties SpecialProperties { get; set; }

        public bool IsOnline => true;

        public IGunterInfoItem Container { get => _container; }

        public string Category { get => InfoSourceConstants.CAT_WEATHER; }
        public string SubCategry { get => InfoSourceConstants.SUB_OFFICIAL; }

        public AEMETInfoSource(string id)
        {
            Id = id;
        }

        public AEMETInfoSource() 
        {
            Id = string.Empty;
            Name = string.Empty;
            SpecialProperties = new SpecialProperties();
            _mandatoryInputs.AddOrUpdate("file", Chiloeches);
            lastItem = new();
        }

        public AEMETInfoSource(IGunterInfoItem container, string id, string name)
        {
            Id = id;
            Name = name;
            SpecialProperties = new SpecialProperties();
            _mandatoryInputs.AddOrUpdate("file", Chiloeches);
            lastItem = new();
            _container = container;
        }
        public SpecialProperties GetMandatoryParams()
        {
            return _mandatoryInputs;
        }

        public object GetData()
        {
            return lastItem;
        }


        public void SetSpecialProperties(SpecialProperties specialProperties)
        {
            SpecialProperties = specialProperties;
        }

        public override Dictionary<string, string> GetLastData()
        {
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            _mandatoryInputs.TryGetProperty("file", out string? file);

            string xml = string.Empty;
            var fileUrl = ExternalDataCache.GenerateCacheFileName("AEMET", file, "weather");
            if (ExternalDataCache.Instance.TryGetFile(fileUrl, out byte[] content))
            {
                xml = Encoding.UTF8.GetString(content);
            }
            else
            {
                xml = AsyncHelper.RunSync(() => WebManipulationHelper.DownloadFileAsStringAsync(fileUrl));
                ExternalDataCache.Instance.TryAddFile(xml, fileUrl, DateTimeManipulationHelper.OneDayTimeSpan);
            }

            var serializer = new XmlSerializer(typeof(AEMETResponseModel), new XmlRootAttribute("root"));
            using var reader = new StringReader(xml);
            var item = (AEMETResponseModel?)serializer.Deserialize(reader);

            if (item is not null)
            {
                lastItem = item;

                var datos = item.prediccion.FirstOrDefault()?
                    .estado_cielo.Where(x => !string.IsNullOrWhiteSpace(x.descripcion))
                    .FirstOrDefault();

                if (datos is not null)
                {
                    var lastData = $"{datos.Value} {datos.descripcion}";

                    if (data.ContainsKey("LastData"))
                    {
                        data["LastData"] = lastData ?? string.Empty;
                    }
                    else
                    {
                        data.Add("LastData", lastData ?? string.Empty);
                    }
                }
            }

            return data;
        }

        public void Update()
        {
            GetLastData();
            _container?.InfoSourceUpdated(this);
        }
    }
}
