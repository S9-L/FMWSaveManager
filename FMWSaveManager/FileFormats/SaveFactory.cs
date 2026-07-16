using System.ComponentModel;
using static FMWSaveManager.FileFormats.GameType;

namespace FMWSaveManager.FileFormats
{
    public enum GameType
    {
        CBDoujin,
        CBSteam,
        CBSwitch1_1_0,
        CBSwitch1_2_5
    }

    public enum ImportMode
    {
        SingleFile,
        BatchImport
    }
    internal static class SaveFactory
    {
        public static ISaveFile Create(GameType type)
        {
            return type switch
            {
                CBDoujin => new CBDoujinSave(),
                CBSteam => new CBSteamSave(),
                CBSwitch1_1_0 => new CBSteamSave(),
                CBSwitch1_2_5 => new CBSteamSave(),
                _ => throw new InvalidEnumArgumentException("Invalid save format enum passed to factory")
            };
        }
    }
}
