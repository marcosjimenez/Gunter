﻿using Gunter.Core.Components;
using Gunter.Core.Components.BaseComponents;
using Gunter.Core.Contracts;
using Gunter.Core.Infrastructure.Helpers;
using Gunter.Core.Infrastructure.Log;
using Gunter.Core.Models;
using Microsoft.ML;
using Microsoft.ML.Data;
using System.Diagnostics;

namespace Gunter.Extensions.ML
{
    public class HouseData
    {
        public float Size { get; set; }
        public float Price { get; set; }
    }

    public class Prediction
    {
        [ColumnName("Score")]
        public float Price { get; set; }
    }

    public class MLTest: InfoSourceBase<object>, IGunterInfoSource
    {
        private object lastItem { get; set; }
        private readonly IGunterInfoItem _container;

        private Dictionary<string, object> data = new();

        public bool IsOnline => true;

        public IGunterInfoItem Container { get => _container; }

        public string Category { get => InfoSourceConstants.CAT_MACHINELEARNING; }
        public string SubCategory { get => InfoSourceConstants.SUB_TESTML; }

        private const string MODEL = "model";
        private const string INPUT_COLUMN_NAME = "InputColumnNames";
        private const string OUTPUT_COLUMN_NAME = "OutputColumnNames";
        private const string ITERATIONS = "100";

        private MLContext context = null;

        public MLTest() : base()
        {
            Name = "ML Test";
            SpecialProperties = new SpecialProperties();
            _mandatoryInputs.AddOrUpdate(MODEL, new List<object>());
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
            //SpecialProperties.TryGetProperty(MODEL, out var value);

            var inputColumnNames = inputColumns.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList();
            var outputColumnNames = outputColumns.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList();

            //var dataList = JsonConvert.DeserializeObject<IEnumerable<object>>(value);
            HouseData[] houseData = {
               new HouseData() { Size = 1.1F, Price = 1.2F },
               new HouseData() { Size = 1.9F, Price = 2.3F },
               new HouseData() { Size = 2.8F, Price = 3.0F },
               new HouseData() { Size = 3.4F, Price = 3.7F } };

            var parameter = new MLParameters
            {
                InputColumnNames = inputColumnNames,
                OutputColumnNames = outputColumnNames,
                Iterations = 100,
                Model = houseData
            };

            List<string> source = new()
            {
                "var size = new HouseData() { Size = 2.5F };",
                "var mlContext = new MLContext();",
                "IDataView trainingData = mlContext.Data.LoadFromEnumerable(parameter.Model);",
                "Gunter.Core.Infrastructure.Log.GunterLog.Instance.Log(this, parameter.InputColumnNames[0]);",
                "var pipeline = mlContext.Transforms.Concatenate(\"Features\", parameter.InputColumnNames.ToArray());",
                "foreach (var outputColumn in parameter.OutputColumnNames)",
                "{",
                "   Gunter.Core.Infrastructure.Log.GunterLog.Instance.Log(this, \"output:\" + outputColumn);",
                "   pipeline.Append(mlContext.Regression.Trainers.Sdca(labelColumnName: outputColumn, maximumNumberOfIterations: parameter.Iterations));",
                "}",
                " ",
                "var model = pipeline.Fit(trainingData);",
                "var price = mlContext.Model.CreatePredictionEngine<HouseData, Prediction>(model).Predict(size);",
                " ",
                "return price;"
        };

            List<string> testSource = new()
            {
                "MLContext mlContext = new MLContext();",
                "",
                "// 1. Import or create training data",
                "HouseData[] houseData = {",
                   "new HouseData() { Size = 1.1F, Price = 1.2F },",
                "   new HouseData() { Size = 1.9F, Price = 2.3F },",
                   "new HouseData() { Size = 2.8F, Price = 3.0F },",
                "   new HouseData() { Size = 3.4F, Price = 3.7F } };",
                "IDataView trainingData = mlContext.Data.LoadFromEnumerable(houseData);",
                "",
                "// 2. Specify data preparation and model training pipeline",
                "var pipeline = mlContext.Transforms.Concatenate(\"Features\", new[] { \"Size\" })",
                   ".Append(mlContext.Regression.Trainers.Sdca(labelColumnName: \"Price\", maximumNumberOfIterations: 100));",
                "",
                "// 3. Train model",
                "var model = pipeline.Fit(trainingData);",
                "",
                "// 4. Make a prediction",
                "var size = new HouseData() { Size = 2.5F };",
                "var price = mlContext.Model.CreatePredictionEngine<HouseData, Prediction>(model).Predict(size);",
                "",
                "Gunter.Core.Infrastructure.Log.GunterLog.Instance.Log(this, $\"Predicted price for size: {size.Size*1000} sq ft= {price.Price*100:C}k\");",
                "",
                "return price;"
            };

            var usings = new[] {
                "Gunter.Extensions.ML",
                "Microsoft.ML",
                "System.Reflection.Metadata"
            };

            //var predictionClassModel = GeneratePredictionClass(typeof(HouseData), parameter.InputColumnNames);

            var item = new SourceCodeItem<MLParameters, Prediction>
            {
                ClassName = "MLTesting",
                MethodName = "RunTest",
                NameSpace = "Gunter.Test",
                Parameter = parameter,
                Parent = this,
                Source = testSource,
                InputType = typeof(MLParameters),
                ReturnType = typeof(Prediction)
            };
            foreach (var newUsing in usings)
                item = item.AddUsing(newUsing);

            item.AddRefPath(usings);
            item.AddRefPathsForName("Microsoft.ML"); // Add all ML libraries
            item.AddRefPathsForName("Gunter.Extensions.ML");

            var helper = new RuntimeHelper();
            var result = helper.CompileAndRun(item);

            if (result is not null)
            {
                GunterLog.Instance.Log(this, "Price is :" + result.Price.ToString());

                if (data.ContainsKey("lastData"))
                    data["lastData"] = result.Price;
                else
                    data.Add("lastData", result.Price);
            }

            return data;
        }

        public static IEnumerable<string> GeneratePredictionClass(Type type, IEnumerable<string> fieldsToPredict)
        {
            var props = type.GetProperties();
            var retVal = new List<string>();
            retVal.Add($"public class Prediction<{type.Name}> : Prediction");
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