using System.Text;
using Gunter.Core.Cache;
using Gunter.Core.Components;
using Gunter.Core.Components.BaseComponents;
using Gunter.Core.Contracts;
using Gunter.Core.Models;
using Microsoft.ML;

namespace Gunter.Extensions.ML
{
    public class MLTest: InfoSourceBase<object>, IGunterInfoSource
    {
        private object lastItem { get; set; }
        private readonly IGunterInfoItem _container;

        private Dictionary<string, object> data = new();

        public bool IsOnline => true;

        public IGunterInfoItem Container { get => _container; }

        public string Category { get => InfoSourceConstants.CAT_INFORMATION; }
        public string SubCategory { get => InfoSourceConstants.SUB_WEATHER; }

        private MLContext mlContext = new();

        public MLTest() : base()
        {
            Name = "ML Test";
            SpecialProperties = new SpecialProperties();
            _mandatoryInputs.AddOrUpdate("model", new List<object>());
            lastItem = new();
        }

        public MLTest(string id) : base(id)
        {
            Id = id;
        }

        public SpecialProperties GetMandatoryParams()
        {
            return _mandatoryInputs;
        }

        public object GetLastItem()
        {
            return lastItem;
        }

        public override Dictionary<string, object> GetLastData()
        {
            //SpecialProperties.TryGetProperty("model", out object? model);

            //string xml = string.Empty;
            //var fileUrl = ExternalDataCache.GenerateCacheFileID("ML", "MLTest", model);
            //if (ExternalDataCache.Instance.TryGetFile(fileUrl, out byte[] content))
            //{
            //    xml = Encoding.UTF8.GetString(content);
            //}
            //else
            //{
            //    IDataView trainingData = mlContext.Data.LoadFromEnumerable(model);

            //    // 2. Specify data preparation and model training pipeline
            //    var pipeline = mlContext.Transforms.Concatenate("Features", new[] { "Size" })
            //        .Append(mlContext.Regression.Trainers.Sdca(labelColumnName: "Price", maximumNumberOfIterations: 100));

            //    //xml = AsyncHelper.RunSync(() => WebManipulationHelper.DownloadFileAsStringAsync(string.Concat(BaseAddress, file)));
            //    //ExternalDataCache.Instance.TryAddFile(xml, fileUrl, DateTimeManipulationHelper.OneDayTimeSpan);
            //}

            return data;
        }

        public void Update()
        {
            GetLastData();
        }
    }
}