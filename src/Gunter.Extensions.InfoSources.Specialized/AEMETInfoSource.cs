﻿using Gunter.Core.Components;
using Gunter.Core.Components.BaseComponents;
using Gunter.Core.Contracts;
using Gunter.Core.Cache;
using Gunter.Core.Infrastructure.Helpers;
using Gunter.Core.Models;
using Gunter.Extensions.InfoSources.Specialized.Models;
using System.Text;
using System.Xml.Serialization;

namespace Gunter.Extensions.InfoSources.Specialized
{
    public class AEMETInfoSource : InfoSourceBase<AEMETData>, IGunterInfoSource
    {
        private readonly IGunterInfoItem _container;

        private const string BaseAddress = "https://www.aemet.es/xml/municipios/";
        private const string Chiloeches = "localidad_19105.xml";
        private Dictionary<string, AEMETData> data = new();

        public IGunterInfoItem Container { get => _container; }
        public override AEMETData LastItem { get; protected set; }

        public string Category { get => InfoSourceConstants.CAT_INFORMATION; }
        public string SubCategory { get => InfoSourceConstants.SUB_WEATHER; }

        public AEMETInfoSource(string id)
        {
            Id = id;
        }

        public AEMETInfoSource()
        {
            Name = "AEMET InfoSource";
            SpecialProperties = new SpecialProperties();
            _mandatoryInputs.AddOrUpdate("file", Chiloeches);
            LastItem = new();
        }

        public AEMETInfoSource(IGunterInfoItem container, string id, string name)
        {
            Id = id;
            Name = name;
            SpecialProperties = new SpecialProperties();
            _mandatoryInputs.AddOrUpdate("file", Chiloeches);
            LastItem = new();
            _container = container;
        }
        public SpecialProperties GetMandatoryParams()
        {
            return _mandatoryInputs;
        }

        public object GetLastItem()
        {
            return LastItem;
        }

        public override Dictionary<string, AEMETData> GetLastData()
        {
            SpecialProperties.TryGetProperty("file", out string? file);

            string xml = string.Empty;
            var fileUrl = ExternalDataCache.GenerateCacheFileID("Weather", "AEMET", file);
            if (ExternalDataCache.Instance.TryGetFile(fileUrl, out byte[] content))
            {
                xml = Encoding.UTF8.GetString(content);
            }
            else
            {
                xml = AsyncHelper.RunSync(() => WebManipulationHelper.DownloadFileAsStringAsync(string.Concat(BaseAddress, file)));
                ExternalDataCache.Instance.TryAddFile(xml, fileUrl, DateTimeManipulationHelper.OneDayTimeSpan);
            }

            var serializer = new XmlSerializer(typeof(AEMETData), new XmlRootAttribute("root"));
            using var reader = new StringReader(xml);
            var item = (AEMETData?)serializer.Deserialize(reader);

            if (item is not null)
            {
                LastItem = item;

                var datos = item.prediccion.FirstOrDefault()?
                    .estado_cielo.Where(x => !string.IsNullOrWhiteSpace(x.descripcion))
                    .FirstOrDefault();

                if (datos is not null)
                {
                    var lastData = $"{datos.Value} {datos.descripcion}";

                    if (data.ContainsKey("LastData"))
                    {
                        data["LastData"] = item;
                    }
                    else
                    {
                        data.Add("LastData", item);
                    }
                }
            }

            return data;
        }

        public void Update()
        {
            GetLastData();
        }
    }
}
