using Microsoft.ML;

namespace GunterAPI.Domain.Services
{
    public class TextAnalysisService : ITextAnalysisService
    {
        private const string DataFile = "GunterAPI.Domain_Data.zip";

        private readonly MLContext context;
        private ITransformer trainedModel;
        private IDataView data;

        public TextAnalysisService()
        {
            context = new MLContext();
            Initialize();
        }

        private void Initialize()
        {

        }

        public T GetSentiment<T>(string sentenceText)
        {
            //var sentence = new Sentence("Your text should go here");
            //var lemmas = sentence.Lemmas;
            //var pos = sentence.PosTags;

            return default;
        }

        public DataViewSchema LoadContext()
        {
            // Load trained model
            trainedModel = context.Model.Load(DataFile, out var modelSchema);

            return modelSchema;
        }

        public void SaveContext()
        {
            context.Model.Save(trainedModel, data.Schema, DataFile);
        }
    }
}
