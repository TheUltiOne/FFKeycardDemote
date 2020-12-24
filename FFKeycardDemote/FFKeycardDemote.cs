using Exiled.API.Features;
using Exiled.API.Enums;

using Player = Exiled.Events.Handlers.Player;

using System;

namespace FFKeycardDemote
{
    public class FFKeycardDemote : Plugin<Config>
    {
        private static readonly Lazy<FFKeycardDemote> LazyInstance = new Lazy<FFKeycardDemote>(valueFactory: () => new FFKeycardDemote());
        public static FFKeycardDemote Instance => LazyInstance.Value;

        public override PluginPriority Priority { get; } = PluginPriority.First;

        private EventHandlers events;

        private FFKeycardDemote()
        {
        }

        public override void OnEnabled()
        {
            RegisterEvents();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
        }

        public void RegisterEvents()
        {
            events = new EventHandlers();
            Player.Dying += events.OnDying;
        }

        public void UnregisterEvents()
        {
            Player.Dying -= events.OnDying;
            events = null;
        }
    }
}