namespace GunterAPI.Domain.Models
{
    public class ValoratedSentence<T>
    {
        public string Sentence { get; set; }

        public T Valoration { get; set; }
    }
}
