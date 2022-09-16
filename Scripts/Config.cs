// Yay me learned config
using System.IO;
using BepInEx;
using BepInEx.Configuration;

namespace DiscoBall.Config
{
    static internal class Config
    {
        public static float DefaultVolume { get => _DefaultVolume.Value; set => _DefaultVolume.Value = value; }
        public static bool PlayOnStart { get => _PlayOnStart.Value; set => _PlayOnStart.Value = value; }
        public static bool MenuOpenByDefault { get => _MenuOpenByDefault.Value; set => _MenuOpenByDefault.Value = value; }
        public static float SpinSpeed { get => _SpinSpeed.Value; set => _SpinSpeed.Value = value; }
        public static float MusicDistance { get => _MusicDistance.Value; set => _MusicDistance.Value = value; }

        static ConfigEntry<bool> _PlayOnStart;
        static ConfigEntry<float> _SpinSpeed;
        static ConfigEntry<float> _DefaultVolume;
        static ConfigEntry<float> _MusicDistance;
        static ConfigEntry<bool> _MenuOpenByDefault;

        static ConfigFile config;

        static Config()
        {
            config = new ConfigFile(Path.Combine(Paths.ConfigPath, "DiscoBall.cfg"), true);
            _DefaultVolume = config.Bind("DiscoBall", "Default Volume", 0.5f, "change the default volume anything over 1 or under 0 might not work");
            _SpinSpeed = config.Bind("DiscoBall", "Ball Rotation Speed", 1.5f, "change the speed the discoball will rotate at");
            _MusicDistance = config.Bind("DiscoBall", "Required Distance", 3.8f, "required distance for the music to play");
            _PlayOnStart = config.Bind("DiscoBall", "Play On Start", true, "enable to play on start disable to not play on start");
            _MenuOpenByDefault = config.Bind("DiscoBall", "Open Menu On Start", false, "open menu by default");
        }
    }
}

            
