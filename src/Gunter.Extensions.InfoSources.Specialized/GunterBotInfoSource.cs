using Gunter.Core.Contracts;
using Gunter.Extensions.Common;
using Gunter.Extensions.InfoSources.Specialized.Models;
using Gunter.Infrastructure.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Gunter.Core.Infrastructure.Helpers;
using System.Threading;
using System.Collections.Concurrent;

namespace Gunter.Extensions.InfoSources.Specialized
{
    public class GunterBotInfoSource : InfoSourceBase<GunterBotInfoItem>, IInfoSource
    {

        private ConcurrentBag<GunterBotInfoItem> _messages = new();

        public string LastItem { get => lastItem; }

        public SpecialProperties SpecialProperties { get; set; }

        public bool IsOnline => true;

        public string Id { get; set; }
        public string Name { get; set; }

        public IGunterInfoItem Container { get => _container; }

        public string Category { get => InfoSourceConstants.CAT_COMMUNICATION; }
        public string SubCategry { get => InfoSourceConstants.SUB_BOTS; }

        private string lastItem { get; set; }
        private readonly IGunterInfoItem _container;

        private Dictionary<string, GunterBotInfoItem> data = new();

        private TelegramBotClient botClient;
        private Telegram.Bot.Types.User botUser;
        private CancellationTokenSource receivingCancelToken = new CancellationTokenSource();

        public GunterBotInfoSource()
        {
            Id = string.Empty;
            Name = string.Empty;
            SpecialProperties = new SpecialProperties();
            _mandatoryInputs.AddOrUpdate("token", "{YOUR_ACCESS_TOKEN_HERE}");
            _container = null;
            lastItem = string.Empty;
        }

        public GunterBotInfoSource(IGunterInfoItem container, string id, string name)
        {
            Id = id;
            Name = name;
            SpecialProperties = new SpecialProperties();
            _mandatoryInputs.AddOrUpdate("token", "{YOUR_ACCESS_TOKEN_HERE}");
            lastItem = string.Empty;
            _container = container;
        }

        ~GunterBotInfoSource()
        {
            if (receivingCancelToken is not null)
                receivingCancelToken.Cancel();

            //AsyncHelper.RunSync(() => botClient.CloseAsync());
        }

        public object GetData()
        {
            return lastItem;
        }

        public void SetSpecialProperties(SpecialProperties specialProperties)
        {
            specialProperties.AddOrUpdate("command", string.Empty);
            SpecialProperties = specialProperties;
            InitBot();
        }

        public override Dictionary<string, GunterBotInfoItem> GetLastData()
        {

            _mandatoryInputs.TryGetProperty("command", out string? command);

            while(!_messages.IsEmpty)
                if (_messages.TryTake(out var result))
                    data.Add(result.MessageId, result);

            //var fileUrl = ExternalDataCache.GenerateCacheFileName(string.Empty, "GUNTERBOT", string.Empty);
            //if (ExternalDataCache.Instance.TryGetFile(fileUrl, out byte[] content))
            //{
            //    var json = Encoding.UTF8.GetString(content);
            //    //weather = System.Text.Json.JsonSerializer.Deserialize<OpenWeatherInfoItem.RootObject>(json);
            //}
            //else
            //{
            //    //weather = WeatherApi.getOneDayWeather(city);
            //    //var json = System.Text.Json.JsonSerializer.Serialize(weather, typeof(OpenWeatherInfoItem.RootObject));
            //    //ExternalDataCache.Instance.TryAddFile(json, fileUrl, DateTimeManipulationHelper.QuarterDayTimeSpan);
            //}

            //if (weather is not null)
            //{
            //    lastItem = weather;
            //}

            return data;
        }
        private async Task SendMessageToBot(string message, long chatId)
        {
            Message sentMessage = await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: message,
                cancellationToken: new CancellationToken());
        }

        private User GetBotUser ()
        {
            botClient ??= new TelegramBotClient(GetToken());
            botUser ??= AsyncHelper.RunSync(() => botClient.GetMeAsync());

            return botUser;
        }

        private string GetToken()
        {
            if (SpecialProperties.TryGetProperty<string>("token", out string? token))
                return token;

            return string.Empty;
        }

        private void InitBot()
        {
            var me = GetBotUser();

            // StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = Array.Empty<UpdateType>() // receive all update types
            };
            botClient.StartReceiving(
                updateHandler: HandleUpdateAsync,
                pollingErrorHandler: HandlePollingErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: receivingCancelToken.Token
            );

            //receivingCancelToken.Cancel();
        }

        Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            // Only process Message updates: https://core.telegram.org/bots/api#message
            if (update.Message is not { } message)
                return Task.CompletedTask;
            // Only process text messages
            if (message.Text is not { } messageText)
                return Task.CompletedTask;

            _messages.Add(new GunterBotInfoItem
            {
                MessageId = message.MessageId.ToString(),
                ChatId = message.Chat.Id.ToString(),
                MessageText = messageText,
                TimeStamp = message.EditDate.HasValue ? message.EditDate.Value : DateTime.Now
            });

            return Task.CompletedTask;
        }

        Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }

        public void Update()
        {
            GetLastData();
            _container?.InfoSourceUpdated(this);
        }
    }
}
