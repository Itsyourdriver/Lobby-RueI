namespace Lobby
{
    using PluginAPI.Core.Attributes;
    using PluginAPI.Core;
    using PluginAPI.Enums;
    using PluginAPI.Events;
    using RueI;

    public class Lobby
    {
        public static Lobby Instance { get; private set; }

        [PluginConfig("configs/lobby.yml")]
        public Config Config;

        [PluginPriority(LoadPriority.Highest)]
        [PluginEntryPoint("Lobby", "1.1.3", "A plugin that adds a lobby when waiting for players.", "MrAfitol")]
        void LoadPlugin()
        {
            Instance = this;
            EventManager.RegisterEvents<EventHandlers>(this);
            Log.Info("Loading Lobby...");
            var handler = PluginHandler.Get(this);
            handler.SaveConfig(this, nameof(Config));
            Log.Info("Lobby has loaded...");
            RueIMain.EnsureInit();
            Log.Info("Loaded RueI...");
        }
    }
}
