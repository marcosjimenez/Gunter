namespace GunterAPI.Domain.Services
{
    internal interface ITextToSentenceService
    {
        string TryConvert(string text);
    }
}
