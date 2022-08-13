namespace GunterAPI.Domain.Models
{
    public class ValoratedSentenceList<T>
    {
        public IList<ValoratedSentence<T>> ValoratedSentences { get; set; }

    }
}
