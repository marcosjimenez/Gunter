namespace Gunter.Extensions.ML
{


    public class DynamicMLParameters
    {
        public List<string> InputColumnNames { get; set; }

        public List<string> OutputColumnNames { get; set; }

        public int Iterations { get; set; }

        public IEnumerable<dynamic> TrainingData { get; set; } = new List<dynamic>();

        public dynamic ModelToPredict { get; set; }

    }

    public class MLParameters : BaseMLParameters<object>
    {
        public List<string> InputColumnNames { get; set; }

        public List<string> OutputColumnNames { get; set; }

        public int Iterations { get; set; }
    }

    public class BaseMLParameters<T>
    {
        public IEnumerable<T> TrainingData { get; set; } = new List<T>();

        public T ModelToPredict { get; set; } = default;
    }
}