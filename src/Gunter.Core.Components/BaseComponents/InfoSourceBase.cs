using Gunter.Core.Constants;
using Gunter.Core.Contracts;
using Gunter.Core.Infrastructure.Exceptions;
using Gunter.Core.Infrastructure.Helpers;
using Gunter.Core.Infrastructure.Log;
using Gunter.Core.Messaging;
using Gunter.Core.Messaging.Models;
using Gunter.Core.Models;

namespace Gunter.Core.Components.BaseComponents
{
    public abstract class InfoSourceBase<T> : IMessagingComponent
    {
        public abstract T LastItem { get; protected set; }

        public string ClassId { get => IdentificationConstants.CLASSID.GunterInfoSource; }

        public string Id { get; protected set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = string.Empty;
        public SpecialProperties SpecialProperties { get; set; } = new();

        protected SpecialProperties _mandatoryInputs = new();

        private MessagingClient? messagingClient;
        public string MessagingClientId { get => messagingClient?.Id ?? string.Empty; }

        public InfoSourceBase()
        {
            GetClient();
        }
        public InfoSourceBase(string id)
        {
            Id = id;
            GetClient();
        }
        public virtual Dictionary<string, T> GetLastData()
            => new Dictionary<string, T>();

        public object GetLastItem()
        {
            return LastItem;
        }

        public void SetSpecialProperties(SpecialProperties specialProperties)
        {
            SpecialProperties = specialProperties;
        }

        public SpecialProperties GetMandatoryParams()
        {
            return _mandatoryInputs;
        }

        public object? GetMandatoryParam(string name)
        {
            if (_mandatoryInputs.TryGetProperty(name, out var value))
            {
                return value;
            }

            return null;
        }

        protected void AddMandatoryParam(string key, string value)
        {
            if (!_mandatoryInputs.TryGetProperty(key, out var input))
            {
                throw new GunterInfoSourceException($"Unexpected mandatory property {key}");
            }
            _mandatoryInputs.AddOrUpdate(key, value);
        }

        public bool IsReady()
            => !_mandatoryInputs.Properties.Any(x => string.IsNullOrWhiteSpace(x.Value.ToString()));

        public void GetClient()
        {
            messagingClient = MessagingHelper.Instance.CreateClient(Id);
            messagingClient.TextMessageReceived += (sender, e) =>
            {
                GunterLog.Instance.Log(this, e.Message);
            };
            messagingClient.ConnectAsync();
        }

        public void SendMessage(string message, string componentId)
        {
            AsyncHelper.RunSync(() => messagingClient.SendToComponent(message, componentId));
        }
    }
}
