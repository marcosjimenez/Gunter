using Gunter.Core.Contracts;
using Gunter.Infrastructure.Cache;
using System.Text;
using System.Xml.Serialization;
using Gunter.Extensions.InfoSources.Specialized.Models;
using Gunter.Core.Infrastructure.Helpers;
using Gunter.Core.Models;

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
        public bool IsOnline => true;

        public IGunterInfoItem Container { get => _container; }

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

        public override Dictionary<string, string> GetLastData()
        {
            SpecialProperties.TryGetProperty("file", out string? file);

            string xml = string.Empty;
            var fileUrl = ExternalDataCache.GenerateCacheFileName("AEMET", file, "weather");
            if (ExternalDataCache.Instance.TryGetFile(fileUrl, out byte[] content))
            {
                xml = Encoding.UTF8.GetString(content);
            }
            else
            {
                xml = AsyncHelper.RunSync(() => WebManipulationHelper.DownloadFileAsStringAsync(string.Concat(BaseAddress, file)));
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
