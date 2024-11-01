﻿using Gunter.Core.Components.BaseComponents.Chaining;
using Gunter.Core.Constants;
using Gunter.Core.Contracts;
using Gunter.Core.Contracts.Chaining;
using Newtonsoft.Json.Linq;
using System.Collections.Concurrent;
using System.Text.Json.Serialization;

namespace Gunter.Core.Components.BaseComponents
{
    public abstract class GunterInfoItemBase : IGunterInfoItem
    {
        public object lockObject = new();

        public string ClassId { get => IdentificationConstants.CLASSID.GunterInfoItem; }

        public string Id { get; private set; }

        public string Name { get; set; }

        public bool UpdateOnComponentChange { get; set; } = true;
        public IEnumerable<object> events { get; set; }
        public IEnumerable<object> Events { get => events; }

        [JsonIgnore]
        public List<IGunterInfoSource> InfoSources { get; } = new();

        [JsonIgnore]
        public List<IGunterVisualizationHandler> VisualizationHandlers { get; } = new();

        public IChain<IGunterInfoSource> Chain { get; private set; } = new GunterInfoSourceChainBase();
        
        private readonly IGunterProcessor _processor;

        public IGunterProcessor GetProcessor() => _processor;

        private DateTime _lastUpdate = DateTime.Now;
        public DateTime LastUpdate { get => _lastUpdate; }

        public GunterInfoItemBase()
        {

        }

        public GunterInfoItemBase(string id)
        {
            Id = id;
            events = new List<object>();
            VisualizationHandlers = new();
        }

        public GunterInfoItemBase(string name, IGunterProcessor processor)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            events = new List<object>();
            _processor = processor;
            VisualizationHandlers = new();
        }

        public void AddInfoSource(IGunterInfoSource source)
        {
            InfoSources.Add(source);
        }

        public Task UpdateSources()
        {
            var tasks = InfoSources
                .Select(i => Task.Factory.StartNew(() => i.GetLastItem()))
                .ToArray();

            Task.WaitAll(tasks);

            foreach (var source in InfoSources.AsParallel())
            {
                source.Update();
            }

            _lastUpdate = DateTime.Now;

            return Task.CompletedTask;
        }

        public void AddVisualizationHandler(IGunterVisualizationHandler handler)
        {
            VisualizationHandlers.Add(handler);
            VisualizationHandlerUpdated(handler);
        }

        public void Update()
        {
            UpdateSources();
            OnUpdateHandler();
        }

        public void InfoSourceUpdated(IGunterInfoSource source)
        {

        }

        public void VisualizationHandlerUpdated(IGunterVisualizationHandler handler)
        {
            if (!VisualizationHandlers.Contains(handler)) // Not removed
                return;

            VisualizationHandlers.Add(handler);
        }


        CancellationTokenSource source = new CancellationTokenSource();
        CancellationToken token;
        public Task<bool> ExecuteChain(Action<string, string> onItemUpdated)
        {
            token = source.Token;
            if (token.CanBeCanceled)
            {
                if (!source.TryReset())
                    source = new CancellationTokenSource();

                token = source.Token;
            }
            else
            {
                return Task.FromResult(false);
            }
            //token.UnsafeRegister((obj) => {
            //    source = new CancellationTokenSource();
            //}, null);

            return Chain.ExecuteChain(token, InfoSources, onItemUpdated);
        }

        public void StopChain()
        {
            if (token.CanBeCanceled)
                source.Cancel();
        }

        private void OnUpdateHandler()
            => _processor?.InfoItemUpdated(this);
    }
}
