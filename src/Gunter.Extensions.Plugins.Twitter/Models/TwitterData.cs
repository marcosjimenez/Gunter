namespace Gunter.Extensions.InfoSources.Specialized.Models
{
    public class TwitterData
    {
        public string Id { get; set; }
        public string PersonId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}