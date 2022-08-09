namespace Gunter.Core.Contracts
{
    public interface IMessagingComponent
    {
        string MessagingClientId { get; }

        void GetClient();

    }
}
