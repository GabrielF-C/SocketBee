using MusicBeeApi;
using MusicBeeApi.PluginTypes;

namespace MusicBeePlugin
{
    public class Plugin : BasePlugin
    {
        protected override PluginInfo InitPluginInfo()
        {
            var about = new PluginInfo
            {
                Name = "Plugin Name",
                Description = "A brief description of what this plugin does",
                Author = "Author",
                TargetApplication = "",   //  the name of a Plugin Storage device or panel header for a dockable panel
                Type = PluginType.General,
                VersionMajor = 1,  // your plugin version
                VersionMinor = 0,
                Revision = 1,
                ReceiveNotifications = (ReceiveNotificationFlags.PlayerEvents | ReceiveNotificationFlags.TagEvents),
                ConfigurationPanelHeight = 0   // height in pixels that musicbee should reserve in a panel for config settings. When set, a handle to an empty panel will be passed to the Configure function
            };
            return about;
        }

        protected override void PluginStartup()
        {
            Subscribe(NotificationType.PlayStateChanged, (s, t) => OnPlayStateChanged());
        }

        private void OnPlayStateChanged()
        {
            if (Api.Player_GetPlayState() == PlayState.Playing)
            {
                Api.Player_PlayPause();
            }
        }
    }
}