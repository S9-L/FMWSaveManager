using System;
using System.Collections.Generic;
using System.IO;

namespace FMWSaveManager.FileFormats
{
    internal class CBDoujinSave : ISaveFile
    {
        private byte[] SaveBytes { get; set; }
        private string filePath { get; set; }
        private readonly static byte[] fileHeaderHash = [
            0x36, 0x36, 0x41, 0x45, 0x45, 0x32, 0x39, 0x46,
            0x41, 0x31, 0x35, 0x46, 0x35, 0x33, 0x30, 0x37,
            0x39, 0x37, 0x44, 0x39, 0x44, 0x31, 0x42, 0x43,
            0x38, 0x37, 0x42, 0x37, 0x41, 0x46, 0x43, 0x45,
            0x41, 0x43, 0x32, 0x31, 0x33, 0x31, 0x32, 0x30
        ];
        private readonly static byte[] xor_hash2 = [
            0x40, 0x44, 0x36, 0x44, 0x32, 0x44, 0x4F, 0x37, 0x3B, 0x35,
            0x46, 0x34, 0x34, 0x42, 0x43, 0x42, 0x4B, 0x45, 0x45, 0x3F,
            0x46, 0x3E, 0x45, 0x36, 0x48, 0x30, 0x38, 0x30, 0x33, 0x43,
            0x41, 0x32, 0x33, 0x3F, 0x40, 0x30, 0x38, 0x32, 0x36, 0x36
        ];

        public CBDoujinSave()
        {
        }

        public void ReadFile(string filePath)
        {
            this.filePath = filePath;
            this.SaveBytes = File.ReadAllBytes(this.filePath);
        }

        public void ValidateFile(string sigString)
        {
            // Validate version string
            if (!sigString.StartsWith("GSWX:"))
            {
                throw new FileFormatException($"Failed to read file due to invalid file format for {Path.GetFileName(this.filePath)}");
            }
        }

        public void ReadSaveBytes(GeneralData gd, NGPlusCarryover cd,
            BonusStats bonusStats, UnsupportedFields uf, UnitData ud,
            CharData charData, ChapterClearData chapClear, Items it, EventFlags ev)
        {
            try
            {
                // Read all fields into related classes
                // 45 bytes of hash in header to skip
                Span<byte> decryptedSpan = this.SaveBytes.AsSpan().Slice(45);
                EncryptDecrypt(decryptedSpan, false);

                // General Data
                gd.FileSize = decryptedSpan.Length;
                gd.VersionStr = SaveHelper.ReadStringDoujin(ref decryptedSpan);

                ValidateFile(gd.VersionStr);

                gd.RouteStr = SaveHelper.ReadStringDoujin(ref decryptedSpan);
                gd.Difficulty = SaveHelper.ReadByte(ref decryptedSpan);
                gd.Chapter = SaveHelper.ReadFloat(ref decryptedSpan);
                gd.ChapterID = SaveHelper.ReadStringDoujin(ref decryptedSpan);
                gd.TotalTurns = SaveHelper.ReadUShort(ref decryptedSpan);
                gd.TotalPoints = SaveHelper.ReadInt(ref decryptedSpan);
                gd.TotalWP = SaveHelper.ReadUShort(ref decryptedSpan);

                /* PC CB datetime is assumed as UTC-0 when read in GM8, 
                 * then GMS2 will read in local time interpretation of the double value
                 * 
                 * Offset the local system time by time zone to match PC CB time display for save
                 * Account for DST
                 */
                gd.Curr_Time = SaveHelper.ReadDouble(ref decryptedSpan);
                TimeSpan localTimeOffset = TimeZoneInfo.Local.GetUtcOffset(DateTime.UtcNow);
                DateTimeOffset GMSDTO = new DateTimeOffset(1900, 1, 1, 0, 0, 0, localTimeOffset);
                GMSDTO = GMSDTO.AddDays(gd.Curr_Time);
                bool isDST = TimeZoneInfo.Local.IsDaylightSavingTime(GMSDTO);

                double offsetHoursPerDay = (isDST) ? -localTimeOffset.TotalHours / 24 : (-(localTimeOffset.TotalHours - 1) / 24);
                gd.Curr_Time += offsetHoursPerDay;

                gd.PlayTime = SaveHelper.ReadDouble(ref decryptedSpan);
                gd.Playthroughs = SaveHelper.ReadUByte(ref decryptedSpan);
                gd.ChangedDifficulty = SaveHelper.ReadByte(ref decryptedSpan);
                gd.BonusAchieved = SaveHelper.ReadUByte(ref decryptedSpan);
                gd.TotalBonus = SaveHelper.ReadUByte(ref decryptedSpan);
                gd.GameOvers = SaveHelper.ReadUByte(ref decryptedSpan);
                gd.ApplyIMInit = SaveHelper.ReadUByte(ref decryptedSpan);
                gd.DefaultBGM = SaveHelper.ReadStringDoujin(ref decryptedSpan);
                gd.ArmyName = SaveHelper.ReadStringDoujin(ref decryptedSpan);

                // NG+ Carryover Fields
                cd.c_TotalPoints = SaveHelper.ReadUInt(ref decryptedSpan);
                cd.c_TotalWP = SaveHelper.ReadUInt(ref decryptedSpan);
                cd.c_PlayTime = SaveHelper.ReadDouble(ref decryptedSpan);

                // Bonus Stats for Game Clear
                bonusStats.MaxDamageDealt = SaveHelper.ReadUInt(ref decryptedSpan);
                bonusStats.MaxDamageTaken = SaveHelper.ReadUInt(ref decryptedSpan);
                bonusStats.MaxDamageDealtDetails = SaveHelper.ReadStringDoujin(ref decryptedSpan);
                bonusStats.MaxDamageTakenDetails = SaveHelper.ReadStringDoujin(ref decryptedSpan);
                bonusStats.Vegetables = SaveHelper.ReadUShort(ref decryptedSpan);
                bonusStats.ShootTheBullet = SaveHelper.ReadUShort(ref decryptedSpan);
                bonusStats.DreamSpirits = SaveHelper.ReadUShort(ref decryptedSpan);
                bonusStats.ToyoFan = SaveHelper.ReadUShort(ref decryptedSpan);
                bonusStats.MakuraSweetDreams = SaveHelper.ReadUShort(ref decryptedSpan);
                bonusStats.MeekoSheepCount = SaveHelper.ReadUShort(ref decryptedSpan);
                bonusStats.AkyuPoints = SaveHelper.ReadUByte(ref decryptedSpan);
                bonusStats.LilyPoints = SaveHelper.ReadUByte(ref decryptedSpan);

                gd.Ng0Playthrough = SaveHelper.ReadByte(ref decryptedSpan);

                // Unsupported Fields
                uf.TeamIDs = SaveHelper.ReadList<sbyte>(ref decryptedSpan, false);
                // Sanitize custom team name id list for compatibility with vanilla saves
                uf.CustomNameIDs = SaveHelper.ReadList<ushort>(ref decryptedSpan, false);
                uf.CustomNameIDs.Clear();
                uf.CustomNameIDs.TrimExcess();
                // Sanitize current custom team name list for compatibility with vanilla saves
                uf.CustomNameList = SaveHelper.ReadList<string>(ref decryptedSpan, false);
                uf.CustomNameList.Clear();
                uf.CustomNameList.TrimExcess();
                // Sanitize custom team name history list for compatibility with vanilla saves
                uf.CustomNameHistory = SaveHelper.ReadList<string>(ref decryptedSpan, false);
                uf.CustomNameHistory.Clear();
                uf.CustomNameHistory.TrimExcess();

                uf.TeamList = SaveHelper.ReadGrid<sbyte>(ref decryptedSpan, false);
                uf.DefaultTeams = SaveHelper.ReadList<byte>(ref decryptedSpan, false);
                uf.SelectedTeams = SaveHelper.ReadList<byte>(ref decryptedSpan, false);
                uf.SelectableBGM = SaveHelper.ReadList<string>(ref decryptedSpan, false);

                // Unit Data
                ud.u_UpgradesLv = SaveHelper.ReadGrid<byte>(ref decryptedSpan, false);
                charData.StatsLv = SaveHelper.ReadGrid<byte>(ref decryptedSpan, false);
                charData.SkillIDs = SaveHelper.ReadGrid<string>(ref decryptedSpan, false);
                charData.SkillsLv = SaveHelper.ReadGrid<sbyte>(ref decryptedSpan, false);
                ud.u_ItemIDs = SaveHelper.ReadGrid<string>(ref decryptedSpan, false);
                ud.UnitNames = SaveHelper.ReadList<string>(ref decryptedSpan, false);
                ud.UnitIDs = SaveHelper.ReadList<string>(ref decryptedSpan, false);
                ud.u_BGM = SaveHelper.ReadList<string>(ref decryptedSpan, false);

                uf.RemainingHP = SaveHelper.ReadList<ushort>(ref decryptedSpan, false);
                uf.RemainingMP = SaveHelper.ReadList<ushort>(ref decryptedSpan, false);
                uf.RemainingAmmo = SaveHelper.ReadList<string>(ref decryptedSpan, false);

                ud.SelectedFUB = SaveHelper.ReadList<sbyte>(ref decryptedSpan, false);

                // Char Data
                charData.CharNames = SaveHelper.ReadList<string>(ref decryptedSpan, false);
                charData.CharIDs = SaveHelper.ReadList<string>(ref decryptedSpan, false);
                charData.Curr_EXP = SaveHelper.ReadList<ushort>(ref decryptedSpan, false);
                charData.Curr_PP = SaveHelper.ReadList<uint>(ref decryptedSpan, false);
                charData.TotalPP = SaveHelper.ReadList<uint>(ref decryptedSpan, false);
                charData.Curr_Kills = SaveHelper.ReadList<short>(ref decryptedSpan, false);
                charData.Curr_WP = SaveHelper.ReadList<ushort>(ref decryptedSpan, false);
                charData.ReserveSkills = SaveHelper.ReadList<string>(ref decryptedSpan, false);

                uf.RemainingSP = SaveHelper.ReadList<ushort>(ref decryptedSpan, false);
                uf.RemainingPW = SaveHelper.ReadList<sbyte>(ref decryptedSpan, false);

                charData.SelectedWPB = SaveHelper.ReadList<sbyte>(ref decryptedSpan, false);

                uf.FriendshipUpdated = new List<string>();
                uf.UpdateIDs = SaveHelper.ReadList<byte>(ref decryptedSpan, false);
                uf.UpdatesCharVal = SaveHelper.ReadList<string>(ref decryptedSpan, false);
                uf.UpdatesResultVal = SaveHelper.ReadList<string>(ref decryptedSpan, false);

                cd.NgPlusUnitNames = SaveHelper.ReadList<string>(ref decryptedSpan, false);
                cd.NgPlusUnitIDs = SaveHelper.ReadList<string>(ref decryptedSpan, false);
                cd.NgPlusCharNames = SaveHelper.ReadList<string>(ref decryptedSpan, false);
                cd.NgPlusCharIDs = SaveHelper.ReadList<string>(ref decryptedSpan, false);

                /* Note: PC CB save format for version 1.0.1+ has an overflow bug for c_PP 
                 * since it wasn't declared as an unsigned int
                 * Must read file pos here as ushort to account for this
                 */
                cd.c_PP = SaveHelper.ReadList<ushort>(ref decryptedSpan, false).ConvertAll(x => (uint)x);
                cd.c_Kills = SaveHelper.ReadList<ushort>(ref decryptedSpan, false);

                uf.ItemNumRef = SaveHelper.ReadList<byte>(ref decryptedSpan, false);

                // Chapter Clear Stats
                chapClear.Chaps = SaveHelper.ReadList<byte>(ref decryptedSpan, false);
                chapClear.ChapDifficulties = SaveHelper.ReadList<sbyte>(ref decryptedSpan, false);
                chapClear.ChapTurns = SaveHelper.ReadList<ushort>(ref decryptedSpan, false);
                chapClear.ChapPlayTime = SaveHelper.ReadList<uint>(ref decryptedSpan, false);
                chapClear.ChapKills = SaveHelper.ReadList<ushort>(ref decryptedSpan, false);
                chapClear.ChapEnemies = SaveHelper.ReadList<ushort>(ref decryptedSpan, false);
                chapClear.ChapCasualties = SaveHelper.ReadList<byte>(ref decryptedSpan, false);
                chapClear.ChapPoints = SaveHelper.ReadList<uint>(ref decryptedSpan, false);
                chapClear.ChapSpellsCaptured = SaveHelper.ReadList<byte>(ref decryptedSpan, false);
                chapClear.ChapTotalSpells = SaveHelper.ReadList<byte>(ref decryptedSpan, false);
                chapClear.ChapBonusAchieved = SaveHelper.ReadList<byte>(ref decryptedSpan, false);
                chapClear.ChapGameOvers = SaveHelper.ReadList<ushort>(ref decryptedSpan, false);
                chapClear.ChapSaves = SaveHelper.ReadList<ushort>(ref decryptedSpan, false);
                chapClear.ChapLoads = SaveHelper.ReadList<ushort>(ref decryptedSpan, false);

                // Items
                it.ItemIDs = SaveHelper.ReadList<string>(ref decryptedSpan, false);
                it.TotalItemNums = SaveHelper.ReadList<byte>(ref decryptedSpan, false);
                it.ItemNums = SaveHelper.ReadList<byte>(ref decryptedSpan, false);

                // Event Flags
                ev.FlagIDs = SaveHelper.ReadList<string>(ref decryptedSpan, false);
                ev.FlagONList = SaveHelper.ReadList<sbyte>(ref decryptedSpan, false);

                uf.HandleTeamData = SaveHelper.ReadList<ushort>(ref decryptedSpan, false);
                uf.HandleTeamCount = SaveHelper.ReadList<byte>(ref decryptedSpan, false);
            }
            catch (Exception _exception)
            {
                throw new InvalidDataException("The save file format is invalid.");
            }
        }
        public void WriteSaveBytes(string outputPath, GeneralData gd, NGPlusCarryover cd,
            BonusStats bonusStats, UnsupportedFields uf, UnitData ud,
            CharData charData, ChapterClearData chapClear, Items it, EventFlags ev, bool import)
        {
            // TODO: Write all fields from related classes into file for CB Doujin Save
        }

        public void EncryptDecrypt(Span<byte> byteList, bool encrypt)
        {
            int keyPos = 6;
            for (int i = 0; i < byteList.Length; i++)
            {
                keyPos++;
                if (keyPos >= 40)
                {
                    keyPos = 0;
                }
                byteList[i] = (byte)(byteList[i] ^ fileHeaderHash[keyPos] ^ xor_hash2[keyPos]);
            }
        }
    }

    public class GeneralData
    {
        public int FileSize { get; set; }
        public string VersionStr { get; set; }
        public string RouteStr { get; set; }
        public sbyte Difficulty { get; set; }
        public float Chapter { get; set; }
        public string ChapterID { get; set; }
        public ushort TotalTurns { get; set; }
        public int TotalPoints { get; set; }
        // Internal max WP is 99999, current WP value can overflow as a ushort,
        // this value is bounded to ushort.max when editing in the save editor
        public ushort TotalWP { get; set; }

        public double Curr_Time { get; set; }

        public double PlayTime { get; set; }
        public byte Playthroughs { get; set; }
        public sbyte ChangedDifficulty { get; set; }
        public byte BonusAchieved { get; set; }
        public byte TotalBonus { get; set; }
        public byte GameOvers { get; set; }
        public byte ApplyIMInit { get; set; }
        public string DefaultBGM { get; set; } // Not used in save manager
        public string ArmyName { get; set; }
        public sbyte Ng0Playthrough { get; set; }
    }

    public class NGPlusCarryover
    {
        public uint c_TotalPoints { get; set; }
        // Internal max WP is 99999, carryover does not overflow as a uint
        public uint c_TotalWP { get; set; }
        public double c_PlayTime { get; set; }
        public List<string> NgPlusUnitNames { get; set; }
        public List<string> NgPlusUnitIDs { get; set; }
        public List<string> NgPlusCharNames { get; set; }
        public List<string> NgPlusCharIDs { get; set; }

        /* Note: PC CB save format for version 1.0.1+ has an overflow bug for c_PP
         * since it wasn't declared as an unsigned int, 
         * Must read save file at pos as ushort to account for this 
         */
        public List<uint> c_PP { get; set; }
        public List<ushort> c_Kills { get; set; }
    }

    public class BonusStats
    {
        public uint MaxDamageDealt { get; set; }
        public uint MaxDamageTaken { get; set; }
        public string MaxDamageDealtDetails { get; set; }

        public string MaxDamageTakenDetails { get; set; }

        public ushort Vegetables { get; set; }

        public ushort ShootTheBullet { get; set; }

        public ushort DreamSpirits { get; set; }
        public ushort ToyoFan { get; set; }

        public ushort MakuraSweetDreams { get; set; }
        public ushort MeekoSheepCount { get; set; }
        public byte AkyuPoints { get; set; }
        public byte LilyPoints { get; set; }

    }

    public class UnsupportedFields
    {
        public List<sbyte> TeamIDs { get; set; }

        public List<ushort> CustomNameIDs { get; set; }

        public List<string> CustomNameList { get; set; }

        public List<string> CustomNameHistory { get; set; }
        public List<List<sbyte>> TeamList { get; set; }
        public List<byte> DefaultTeams { get; set; }

        public List<byte> SelectedTeams { get; set; }
        public List<string> SelectableBGM { get; set; }

        public List<ushort> RemainingHP { get; set; }
        public List<ushort> RemainingMP { get; set; }
        public List<string> RemainingAmmo { get; set; }

        public List<ushort> RemainingSP { get; set; }
        public List<sbyte> RemainingPW { get; set; }
        public List<string> FriendshipUpdated { get; set; } // Switch/Steam Only
        public List<byte> UpdateIDs { get; set; }
        public List<string> UpdatesCharVal { get; set; }
        public List<string> UpdatesResultVal { get; set; }
        public List<byte> ItemNumRef { get; set; } // Virtually unused
        /* Not used in Switch/Steam */
        public List<ushort> HandleTeamData { get; set; }
        public List<byte> HandleTeamCount { get; set; }

    }

    public class UnitData
    {
        public List<List<byte>> u_UpgradesLv { get; set; }
        public List<List<string>> u_ItemIDs { get; set; }
        public List<string> UnitNames { get; set; }
        public List<string> UnitIDs { get; set; }
        public List<string> u_BGM { get; set; }

        public List<sbyte> SelectedFUB { get; set; }

    }

    public class CharData
    {
        public List<string> CharNames { get; set; }
        public List<string> CharIDs { get; set; }
        public List<List<byte>> StatsLv { get; set; }
        public List<List<string>> SkillIDs { get; set; }
        public List<List<sbyte>> SkillsLv { get; set; }
        public List<ushort> Curr_EXP { get; set; }
        public List<uint> Curr_PP { get; set; }
        public List<uint> TotalPP { get; set; }
        public List<short> Curr_Kills { get; set; }
        public List<ushort> Curr_WP { get; set; }
        public List<string> ReserveSkills { get; set; }
        public List<sbyte> SelectedWPB { get; set; }
    }

    public class ChapterClearData
    {
        public List<byte> Chaps { get; set; }
        public List<sbyte> ChapDifficulties { get; set; }
        public List<ushort> ChapTurns { get; set; }
        public List<uint> ChapPlayTime { get; set; }
        public List<ushort> ChapKills { get; set; }
        public List<ushort> ChapEnemies { get; set; }
        public List<byte> ChapCasualties { get; set; }
        public List<uint> ChapPoints { get; set; }
        public List<byte> ChapSpellsCaptured { get; set; }
        public List<byte> ChapTotalSpells { get; set; }
        public List<byte> ChapBonusAchieved { get; set; }
        public List<ushort> ChapGameOvers { get; set; }
        public List<ushort> ChapSaves { get; set; }
        public List<ushort> ChapLoads { get; set; }
    }

    public class Items
    {
        public List<string> ItemIDs { get; set; }
        public List<byte> TotalItemNums { get; set; }
        public List<byte> ItemNums { get; set; }

    }

    public class EventFlags
    {
        public List<string> FlagIDs { get; set; }
        public List<sbyte> FlagONList { get; set; }

    }
}
