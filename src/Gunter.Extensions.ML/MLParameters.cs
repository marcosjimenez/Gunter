namespace Gunter.Extensions.ML
{

    public class MLParameters : BaseMLParameters<HouseData>
    {
        public List<string> InputColumnNames { get; set; }

        public List<string> OutputColumnNames { get; set; }

        public int Iterations { get; set; }
    }

    public class BaseMLParameters<T>
    {

        public IEnumerable<T> Model { get; set; }

        public T ItemToPredict { get; set; }
    }
}
