using System.Collections.Generic;
using System.Collections.Immutable;
using System.Reflection;

namespace FMWSaveManager.Util
{
    public static class FMWSaveManagerConstants
    {
        // Allocate 64KB to byte buffer until resize
        public const int allocatedSaveFileSize = 65536;
        public static AssemblyName currentAssemblyName => new AssemblyName(Assembly.GetExecutingAssembly().FullName);
        public static string copyrightText = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyCopyrightAttribute>().Copyright;
        public const string ghLink = "https://github.com/S9-L";
        public const string communityLink = "https://discord.gg/q7tpedHj68";
        public static ImmutableList<string> routeList = ["Reimu", "Marisa"];
        // Meeko's internal name is mapped to Meko, needed to load route/chapter internal values
        public static ImmutableList<string> fullRouteList = ["Reimu", "Marisa", "Sakuya", "Meko"];

        public const decimal maxChapterNumSakuya = 4;
        public const decimal maxChapterNumMeeko = 5;
        public const decimal maxChapterNumGeneral = 80;
        public static List<byte> addUnitUpgrades => [0, 0, 0, 0, 0];
        public const string addUnitName = "NewUnit";
        public const string addUnitID = "NewUnit00";
        public const sbyte addFUB = -1;
        public static List<string> addItemIDs => ["NONE", "NONE", "NONE", "NONE"];
        public const string addBGM = "";
        public const string FUBComboBoxDefaultText = "None";
        public const string ItemComboBoxDefaultText = "NONE";
        public const string SkillComboBoxDefaultText = "NONE";
        public const string WPComboBoxDefaultText = "Item Slots +1";

        public const string addCharName = "NewChar";
        public const string addCharID = "NewChar00";
        /* Even though there are only 6 editable stats,
         * single stat list for a char has a size of 8,
         * with the last 2 elements of the list going unused
         */
        public static List<byte> addStats => [0, 0, 0, 0, 0, 0, 0, 0];
        public static List<string> addSkillIDs => ["NONE", "NONE", "NONE", "NONE", "NONE", "NONE", "NONE", "NONE"];
        public static List<sbyte> addSkillLvs => [-1, -1, -1, -1, -1, -1, -1, -1];
        public const ushort addEXP = 0;
        public const short addKills = 0;
        public const uint addPP = 0;
        public const uint addTotalPP = 0;
        public const ushort addWP = 0;
        public const uint addc_PP = 0;
        public const ushort addc_Kills = 0;
        public const string addReserveSkills = "";
        public const sbyte addWPB = -1;

        public const int maxPP = 99999;

        public readonly static ImmutableDictionary<sbyte, string> diffMap = new Dictionary<sbyte, string>{
            {-1, "Easy"},
            {0, "Normal"},
            {1, "Hard"},
            {2, "Lunatic"}
            }.ToImmutableDictionary();

        public static ImmutableDictionary<sbyte, string> FUBMap = new Dictionary<sbyte, string>{
            {-1, "None"},
            {0, "HP +3000"},
            {1, "MP +150"},
            {2, "Mobility +20"},
            {3, "Armor +500"},
            {4, "ATK +300"},
            {5, "Foc./Unfoc. Move +1"},
            {6, "Range +1"},
            {7, "Accuracy +20%"},
            {8, "Air/Lnd/Wtr Terrain -> S"},
            {9, "Barriers cost no MP"},
            }.ToImmutableDictionary();

        public static ImmutableList<string> WPB1List = ["Item Slots +1", "Final Damage x1.1", "Range +2, Move +2", "MP/Ammo Regen 50%", "SP Regen 20%"];
        public static ImmutableList<string> WPB2List = ["Item Slots +1", "Final Damage x1.1", "Range +2, Move +2", "MP/Ammo Regen 50%", "SP Regen 20%"];
    }
}
