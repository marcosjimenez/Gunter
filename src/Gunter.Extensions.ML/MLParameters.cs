namespace Gunter.Extensions.ML
{
    public class MLParameters
    {
        public List<string> InputColumnNames { get; set; }

        public List<string> OutputColumnNames { get; set; }

        public int Iterations { get; set; }

        public IEnumerable<object> Model { get; set; }
    }
}
