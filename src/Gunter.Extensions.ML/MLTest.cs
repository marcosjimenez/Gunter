using Gunter.Core.Components;
using Gunter.Core.Components.BaseComponents;
using Gunter.Core.Contracts;
using Gunter.Core.Infrastructure.Helpers;
using Gunter.Core.Infrastructure.Log;
using Gunter.Core.Infrastructure.RuntimeExecution;
using Gunter.Core.Models;
using Microsoft.ML;
using Newtonsoft.Json;

namespace Gunter.Extensions.ML
{
    public class HouseData
    {
        public float Size { get; set; }
        public float Price { get; set; }
    }

    public class Prediction
    {
        //[ColumnName("Score")]
        //public float Price { get; set; }
    }

    public class MLTest : InfoSourceBase<object>, IGunterInfoSource 
    {
        private readonly IGunterInfoItem? _container = null;
        private Dictionary<string, object> data = new ();
        public IGunterInfoItem Container { get => _container; }
        private object lastItem { get; set; } = new();
        public override object LastItem { get => lastItem; protected set { lastItem = value; } }

        public string Category { get => InfoSourceConstants.CAT_MACHINELEARNING; }
        public string SubCategory { get => InfoSourceConstants.SUB_TESTML; }

        private const string MODEL = "model";
        private const string TRAININGDATA = "TrainingData";
        private const string INPUT_COLUMN_NAME = "InputColumnNames";
        private const string OUTPUT_COLUMN_NAME = "OutputColumnNames";
        private const string ITERATIONS = "100";

        private MLContext persistentContext = new MLContext();

        public MLTest() : base()
        {
            Name = "ML Test";
            SpecialProperties = new SpecialProperties();
            _mandatoryInputs.AddOrUpdate(MODEL, new List<object>());
            _mandatoryInputs.AddOrUpdate(TRAININGDATA, new List<object>());
            _mandatoryInputs.AddOrUpdate(INPUT_COLUMN_NAME, "inputColumnName1, inputColumnName2");
            _mandatoryInputs.AddOrUpdate(OUTPUT_COLUMN_NAME, "outputColumnName1, outputColumnName2");
            _mandatoryInputs.AddOrUpdate(ITERATIONS, ITERATIONS);
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
            SpecialProperties.TryGetProperty(INPUT_COLUMN_NAME, out var inputColumns);
            SpecialProperties.TryGetProperty(OUTPUT_COLUMN_NAME, out var outputColumns);
            SpecialProperties.TryGetProperty(ITERATIONS, out var iterations);
            SpecialProperties.TryGetProperty(TRAININGDATA, out var trainingData);
            SpecialProperties.TryGetProperty(MODEL, out var modelToPredict);

            var inputColumnNames = inputColumns.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList();
            var outputColumnNames = outputColumns.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList();

            var dataList = JsonConvert.DeserializeObject<IEnumerable<object>>(trainingData);

            var parameter = new DynamicMLParameters
            {
                InputColumnNames = inputColumnNames,
                OutputColumnNames = outputColumnNames,
                Iterations = 100,
                TrainingData = dataList ?? new List<object>(),
                ModelToPredict = modelToPredict
            };

            var properties = new Dictionary<string, Type>();
            var prediction = RuntimeCreationHelper.Instance.GenerateType(properties, out var type);

            List<string> source = new() // TODO: Move to runtime templates
            {
                "var mlContext = new MLContext();",
                "IDataView trainingData = mlContext.Data.LoadFromEnumerable(parameter.Model);",
                "var pipeline = mlContext.Transforms.Concatenate(\"Features\", parameter.InputColumnNames.ToArray())",
                    ".Append(mlContext.Regression.Trainers.Sdca(labelColumnName: parameter.OutputColumnNames[0], maximumNumberOfIterations: parameter.Iterations));",
                "",
                "if (parameter.OutputColumnNames.Count > 1)",
                    "foreach (var item in parameter.OutputColumnNames.Skip(1))",
                        "pipeline = pipeline.Append(mlContext.Regression.Trainers.Sdca(labelColumnName: parameter.OutputColumnNames[0], maximumNumberOfIterations: parameter.Iterations));",
                "",
                "var model = pipeline.Fit(trainingData);",
                "var price = mlContext.Model.CreatePredictionEngine<HouseData, Prediction>(model).Predict(parameter.ItemToPredict);",
                "",
                "RetVal = price;",
                "",
            };

            var usings = new[] {
                "Gunter.Extensions.ML",
                "Microsoft.ML",
                "System.Reflection.Metadata", 
                "System.Collections",
                "System.Linq"
            };

            var item = new SourceCodeItem<DynamicMLParameters, Prediction>
            {
                ClassName = "MLTesting",
                MethodName = "RunTest",
                NameSpace = "Gunter.Test",
                Parameter = parameter,
                Parent = this,
                Source = source,
                InputType = typeof(MLParameters),
                ReturnType = typeof(Prediction)
            };
            foreach (var newUsing in usings)
                item = item.AddUsing(newUsing);

            item.AddRefPath(usings);
            item.AddRefPathsForName("Microsoft.ML"); // Add all ML libraries
            item.AddRefPathsForName("Newtonsoft.Json");
            item.AddRefPathsForName("Gunter.Extensions.ML");

            var helper = new RuntimeHelper();
            var result = helper.CompileAndRun(item);

            bool testing; 
            testing = false;

            //Prediction result;
            //if (!testing)
            //{
            //}
            //else
            //{
            //    var shared = new SharedTestExecution<MLParameters, Prediction>();
            //    shared.FuncToTest = (parameter) =>
            //    {
            //        var mlContext = new MLContext();
            //        IDataView trainingData = mlContext.Data.LoadFromEnumerable(parameter.TrainingData);
            //        var pipeline = mlContext.Transforms.Concatenate("Features", parameter.InputColumnNames.ToArray())
            //            .Append(mlContext.Regression.Trainers.Sdca(labelColumnName: parameter.OutputColumnNames[0], maximumNumberOfIterations: parameter.Iterations));

            //        if (parameter.OutputColumnNames.Count > 1)
            //            foreach (var item in outputColumnNames.Skip(1))
            //                pipeline = pipeline.Append(mlContext.Regression.Trainers.Sdca(labelColumnName: parameter.OutputColumnNames[0], maximumNumberOfIterations: parameter.Iterations));

            //        var model = pipeline.Fit(trainingData);
            //        var price = mlContext.Model.CreatePredictionEngine<object, Prediction>(model).Predict(parameter.ModelToPredict);

            //        return price;
            //    };
            //    result = shared.RunTest(parameter);
            //}


            if (result is not null)
            {
                GunterLog.Instance.Log(this, "result:" + result.ToString());

                if (data.ContainsKey("lastData"))
                    data["lastData"] = result;
                else
                    data.Add("lastData", result);
            }

            return data;
        }

        public static IEnumerable<string> GenerateModelClass(string className, string genericModifiers, string inheritsFrom, Type type, IEnumerable<string> fieldsToPredict)
        {
            var props = type.GetProperties();
            var retVal = new List<string>();

            retVal.Add(string.Format($"public class {0}{1} {2}",
                className,
                genericModifiers,
                !string.IsNullOrWhiteSpace(inheritsFrom) ? inheritsFrom : string.Empty
                ));
            retVal.Add("{");
            foreach (var prop in props)
            {
                if (fieldsToPredict.Contains(prop.Name) && prop.CanRead && prop.CanWrite)
                {
                    retVal.Add($"public {prop.PropertyType.Name} {prop.Name} ");
                    retVal.Add("{ ");
                    if (prop.CanRead)
                        retVal.Add("get;");
                    if (prop.CanWrite)
                        retVal.Add("set;");
                    retVal.Add("}");

                }
            }

            retVal.Add("}");

            return retVal;
        }

        //public Dictionary<string, object> GetLastData_old()
        //{
        //    SpecialProperties.TryGetProperty(INPUT_COLUMN_NAMES, out var inputColumnNames);
        //    SpecialProperties.TryGetProperty(OUTPUT_COLUMN_NAMES, out var outputColumnNames);
        //    SpecialProperties.TryGetProperty(ITERATIONS, out var iterations);
        //    SpecialProperties.TryGetProperty(MODEL, out var value);

        //    var inputColumns = inputColumnNames.Split(",", StringSplitOptions.RemoveEmptyEntries);
        //    var outputColumns = outputColumnNames.Split(",", StringSplitOptions.RemoveEmptyEntries);


        //    var dataList = JsonConvert.DeserializeObject<IEnumerable<object>>(value);
        //    IDataView trainingData = mlContext.Data.LoadFromEnumerable(dataList);

        //    // 2. Specify data preparation and model training pipeline
        //    var pipeline = mlContext.Transforms.Concatenate("Features", inputColumns);
        //    foreach(var outputColumn in outputColumns)
        //        pipeline.Append(mlContext.Regression.Trainers.Sdca(labelColumnName: outputColumn, maximumNumberOfIterations: int.Parse(iterations)));

        //    // 3. Train model
        //    var model = pipeline.Fit(trainingData);

        //    // 4. Make a prediction
        //    //var size = new { Size = 2.5F };
        //    var size = new ExpandoObject() as IDictionary<string, object>;
        //    foreach (var column in inputColumns)
        //    {
        //        size.Add(column, string.Empty);
        //    }

        //    //var price = mlContext.Model.CreatePredictionEngine<HouseData, Prediction>(model).Predict(size);
        //    var price = mlContext.Model.CreatePredictionEngine<IDictionary<string, object>, Prediction>(model).Predict(size);

        //    //Console.WriteLine($"Predicted price for size: {size.Size * 1000} sq ft= {price.Price * 100:C}k");

        //    return data;
        //}

        public void Update()
        {
            GetLastData();
        }
    }
}