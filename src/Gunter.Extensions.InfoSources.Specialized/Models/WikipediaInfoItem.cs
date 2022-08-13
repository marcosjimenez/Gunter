namespace Gunter.Extensions.InfoSources.Specialized.Models
{
    public class WikipediaInfoItem
    {

        public readonly DateTime LastEdited;

        public int Ns { get; set; }
        public int PageId { get; set; }
        public string Preview { get; set; }
        public int Size { get; set; }
        public string Title { get; set; }
        public int WordCount { get; set; }
        public string Language { set; get; } = "es";

        internal static WikipediaInfoItem FromSearchResult(WikiDotNet.WikiSearchResult result)
        => new WikipediaInfoItem
        {
            Title = result.Title,
            Ns = result.Ns,
            PageId = result.PageId,
            Preview = result.Preview,
            Size = result.Size,
            WordCount = result.WordCount
        };

        public string ConstantUrl => new($"https://{Language}.wikipedia.org/?curid={PageId}");
        public string Url => new($"https://{Language}.wikipedia.org/wiki/{Title}");

    }
}
