using FMWSaveManager.Util;
using System;
using System.Buffers;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace FMWSaveManager.FileFormats
{
    internal class CBSteamSave : ISaveFile
    {
        private byte[] SaveBytes { get; set; }
        private string filePath { get; set; }
        private readonly static string baseHashOrig = "8c5b0038804fc69f158d4cb0f95c757258275eb1c5fb02a68bc90c87c40c429162a399b229013417df4403212d7641dd7cbd86ec41920ba40881cb83714500cd598cd1a38dd64d32";
        private readonly static string concatHashOrig = "25230bed7cb135eefe47dd48180a80140a76263530ca457bd9583cbc89594102ffd43c4f0e5102a45adb0883eefdf15ccf009d6066aee29fa15f530797d9d1bc87b7afceac2131208c5b0038804fc69f158d4cb0f95c757258275eb1c5fb02a68bc90c87c40c429162a399b229013417df4403212d7641dd7cbd86ec41920ba40881cb83714500cd598cd1a38dd64d32";
        private string baseHash;
        private string concatHash;

        public CBSteamSave()
        {
            this.baseHash = baseHashOrig;
            this.concatHash = concatHashOrig;
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
                Span<byte> decryptedSpan = this.SaveBytes.AsSpan<byte>();
                EncryptDecrypt(decryptedSpan, false);

                // General Data
                gd.FileSize = SaveHelper.ReadInt(ref decryptedSpan);
                gd.VersionStr = SaveHelper.ReadStringSteam(ref decryptedSpan);

                ValidateFile(gd.VersionStr);

                gd.RouteStr = SaveHelper.ReadStringSteam(ref decryptedSpan);
                gd.Difficulty = SaveHelper.ReadByte(ref decryptedSpan);
                gd.Chapter = SaveHelper.ReadFloat(ref decryptedSpan);
                gd.ChapterID = SaveHelper.ReadStringSteam(ref decryptedSpan);
                gd.TotalTurns = SaveHelper.ReadUShort(ref decryptedSpan);
                gd.TotalPoints = SaveHelper.ReadInt(ref decryptedSpan);
                gd.TotalWP = SaveHelper.ReadUShort(ref decryptedSpan);
                gd.Curr_Time = SaveHelper.ReadDouble(ref decryptedSpan);
                gd.PlayTime = SaveHelper.ReadDouble(ref decryptedSpan);
                gd.Playthroughs = SaveHelper.ReadUByte(ref decryptedSpan);
                gd.ChangedDifficulty = SaveHelper.ReadByte(ref decryptedSpan);
                gd.BonusAchieved = SaveHelper.ReadUByte(ref decryptedSpan);
                gd.TotalBonus = SaveHelper.ReadUByte(ref decryptedSpan);
                gd.GameOvers = SaveHelper.ReadUByte(ref decryptedSpan);
                gd.ApplyIMInit = SaveHelper.ReadUByte(ref decryptedSpan);
                gd.DefaultBGM = SaveHelper.ReadStringSteam(ref decryptedSpan);
                gd.ArmyName = SaveHelper.ReadStringSteam(ref decryptedSpan);

                // NG+ Carryover Fields
                cd.c_TotalPoints = SaveHelper.ReadUInt(ref decryptedSpan);
                cd.c_TotalWP = SaveHelper.ReadUInt(ref decryptedSpan);
                cd.c_PlayTime = SaveHelper.ReadDouble(ref decryptedSpan);

                // Bonus Stats for Game Clear
                bonusStats.MaxDamageDealt = SaveHelper.ReadUInt(ref decryptedSpan);
                bonusStats.MaxDamageTaken = SaveHelper.ReadUInt(ref decryptedSpan);
                bonusStats.MaxDamageDealtDetails = SaveHelper.ReadStringSteam(ref decryptedSpan);
                bonusStats.MaxDamageTakenDetails = SaveHelper.ReadStringSteam(ref decryptedSpan);
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
                uf.TeamIDs = SaveHelper.ReadList<sbyte>(ref decryptedSpan, true);
                uf.CustomNameIDs = SaveHelper.ReadList<ushort>(ref decryptedSpan, true);
                uf.CustomNameList = SaveHelper.ReadList<string>(ref decryptedSpan, true);
                uf.CustomNameHistory = SaveHelper.ReadList<string>(ref decryptedSpan, true);
                uf.TeamList = SaveHelper.ReadGrid<sbyte>(ref decryptedSpan, true);
                uf.DefaultTeams = SaveHelper.ReadList<byte>(ref decryptedSpan, true);
                uf.SelectedTeams = SaveHelper.ReadList<byte>(ref decryptedSpan, true);
                uf.SelectableBGM = SaveHelper.ReadList<string>(ref decryptedSpan, true);

                // Unit Data
                ud.u_UpgradesLv = SaveHelper.ReadGrid<byte>(ref decryptedSpan, true);
                charData.StatsLv = SaveHelper.ReadGrid<byte>(ref decryptedSpan, true);
                charData.SkillIDs = SaveHelper.ReadGrid<string>(ref decryptedSpan, true);
                charData.SkillsLv = SaveHelper.ReadGrid<sbyte>(ref decryptedSpan, true);
                ud.u_ItemIDs = SaveHelper.ReadGrid<string>(ref decryptedSpan, true);
                ud.UnitNames = SaveHelper.ReadList<string>(ref decryptedSpan, true);
                ud.UnitIDs = SaveHelper.ReadList<string>(ref decryptedSpan, true);
                ud.u_BGM = SaveHelper.ReadList<string>(ref decryptedSpan, true);

                uf.RemainingHP = SaveHelper.ReadList<ushort>(ref decryptedSpan, true);
                uf.RemainingMP = SaveHelper.ReadList<ushort>(ref decryptedSpan, true);
                uf.RemainingAmmo = SaveHelper.ReadList<string>(ref decryptedSpan, true);

                ud.SelectedFUB = SaveHelper.ReadList<sbyte>(ref decryptedSpan, true);

                // Char Data
                charData.CharNames = SaveHelper.ReadList<string>(ref decryptedSpan, true);
                charData.CharIDs = SaveHelper.ReadList<string>(ref decryptedSpan, true);
                charData.Curr_EXP = SaveHelper.ReadList<ushort>(ref decryptedSpan, true);
                charData.Curr_PP = SaveHelper.ReadList<uint>(ref decryptedSpan, true);
                charData.TotalPP = SaveHelper.ReadList<uint>(ref decryptedSpan, true);
                charData.Curr_Kills = SaveHelper.ReadList<short>(ref decryptedSpan, true);
                charData.Curr_WP = SaveHelper.ReadList<ushort>(ref decryptedSpan, true);
                charData.ReserveSkills = SaveHelper.ReadList<string>(ref decryptedSpan, true);

                uf.RemainingSP = SaveHelper.ReadList<ushort>(ref decryptedSpan, true);
                uf.RemainingPW = SaveHelper.ReadList<sbyte>(ref decryptedSpan, true);

                charData.SelectedWPB = SaveHelper.ReadList<sbyte>(ref decryptedSpan, true);

                uf.FriendshipUpdated = SaveHelper.ReadList<string>(ref decryptedSpan, true); // Full read on Switch/Steam
                uf.UpdateIDs = SaveHelper.ReadList<byte>(ref decryptedSpan, true);
                uf.UpdatesCharVal = SaveHelper.ReadList<string>(ref decryptedSpan, true);
                uf.UpdatesResultVal = SaveHelper.ReadList<string>(ref decryptedSpan, true);

                cd.NgPlusUnitNames = SaveHelper.ReadList<string>(ref decryptedSpan, true);
                cd.NgPlusUnitIDs = SaveHelper.ReadList<string>(ref decryptedSpan, true);
                cd.NgPlusCharNames = SaveHelper.ReadList<string>(ref decryptedSpan, true);
                cd.NgPlusCharIDs = SaveHelper.ReadList<string>(ref decryptedSpan, true);

                cd.c_PP = SaveHelper.ReadList<uint>(ref decryptedSpan, true);
                cd.c_Kills = SaveHelper.ReadList<ushort>(ref decryptedSpan, true);

                uf.ItemNumRef = SaveHelper.ReadList<byte>(ref decryptedSpan, true);

                // Chapter Clear Stats
                chapClear.Chaps = SaveHelper.ReadList<byte>(ref decryptedSpan, true);
                chapClear.ChapDifficulties = SaveHelper.ReadList<sbyte>(ref decryptedSpan, true);
                chapClear.ChapTurns = SaveHelper.ReadList<ushort>(ref decryptedSpan, true);
                chapClear.ChapPlayTime = SaveHelper.ReadList<uint>(ref decryptedSpan, true);
                chapClear.ChapKills = SaveHelper.ReadList<ushort>(ref decryptedSpan, true);
                chapClear.ChapEnemies = SaveHelper.ReadList<ushort>(ref decryptedSpan, true);
                chapClear.ChapCasualties = SaveHelper.ReadList<byte>(ref decryptedSpan, true);
                chapClear.ChapPoints = SaveHelper.ReadList<uint>(ref decryptedSpan, true);
                chapClear.ChapSpellsCaptured = SaveHelper.ReadList<byte>(ref decryptedSpan, true);
                chapClear.ChapTotalSpells = SaveHelper.ReadList<byte>(ref decryptedSpan, true);
                chapClear.ChapBonusAchieved = SaveHelper.ReadList<byte>(ref decryptedSpan, true);
                chapClear.ChapGameOvers = SaveHelper.ReadList<ushort>(ref decryptedSpan, true);
                chapClear.ChapSaves = SaveHelper.ReadList<ushort>(ref decryptedSpan, true);
                chapClear.ChapLoads = SaveHelper.ReadList<ushort>(ref decryptedSpan, true);

                // Items
                it.ItemIDs = SaveHelper.ReadList<string>(ref decryptedSpan, true);
                it.TotalItemNums = SaveHelper.ReadList<byte>(ref decryptedSpan, true);
                it.ItemNums = SaveHelper.ReadList<byte>(ref decryptedSpan, true);

                // Event Flags
                ev.FlagIDs = SaveHelper.ReadList<string>(ref decryptedSpan, true);
                ev.FlagONList = SaveHelper.ReadList<sbyte>(ref decryptedSpan, true);
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
            // Write all fields from related classes into file
            int writeFileSize = import ? gd.FileSize : FMWSaveManagerConstants.allocatedSaveFileSize;
            ArrayBufferWriter<byte> writeByteBuffer = new ArrayBufferWriter<byte>(writeFileSize);

            // General Data
            SaveHelper.WriteIntBuffer(writeByteBuffer, gd.FileSize);
            SaveHelper.WriteStringBuffer(writeByteBuffer, gd.VersionStr);
            SaveHelper.WriteStringBuffer(writeByteBuffer, gd.RouteStr);
            SaveHelper.WriteByteBuffer(writeByteBuffer, gd.Difficulty);
            SaveHelper.WriteFloatBuffer(writeByteBuffer, gd.Chapter);
            SaveHelper.WriteStringBuffer(writeByteBuffer, gd.ChapterID);
            SaveHelper.WriteUShortBuffer(writeByteBuffer, gd.TotalTurns);
            SaveHelper.WriteIntBuffer(writeByteBuffer, gd.TotalPoints);
            SaveHelper.WriteUShortBuffer(writeByteBuffer, gd.TotalWP);
            SaveHelper.WriteDoubleBuffer(writeByteBuffer, gd.Curr_Time);
            SaveHelper.WriteDoubleBuffer(writeByteBuffer, gd.PlayTime);
            SaveHelper.WriteUByteBuffer(writeByteBuffer, gd.Playthroughs);
            SaveHelper.WriteByteBuffer(writeByteBuffer, gd.ChangedDifficulty);
            SaveHelper.WriteUByteBuffer(writeByteBuffer, gd.BonusAchieved);
            SaveHelper.WriteUByteBuffer(writeByteBuffer, gd.TotalBonus);
            SaveHelper.WriteUByteBuffer(writeByteBuffer, gd.GameOvers);
            SaveHelper.WriteUByteBuffer(writeByteBuffer, gd.ApplyIMInit);
            SaveHelper.WriteStringBuffer(writeByteBuffer, gd.DefaultBGM);
            SaveHelper.WriteStringBuffer(writeByteBuffer, gd.ArmyName);

            // NG+ Carryover Fields
            SaveHelper.WriteUIntBuffer(writeByteBuffer, cd.c_TotalPoints);
            SaveHelper.WriteUIntBuffer(writeByteBuffer, cd.c_TotalWP);
            SaveHelper.WriteDoubleBuffer(writeByteBuffer, cd.c_PlayTime);

            // Bonus Stats for Game Clear
            SaveHelper.WriteUIntBuffer(writeByteBuffer, bonusStats.MaxDamageDealt);
            SaveHelper.WriteUIntBuffer(writeByteBuffer, bonusStats.MaxDamageTaken);
            SaveHelper.WriteStringBuffer(writeByteBuffer, bonusStats.MaxDamageDealtDetails);
            SaveHelper.WriteStringBuffer(writeByteBuffer, bonusStats.MaxDamageTakenDetails);

            SaveHelper.WriteUShortBuffer(writeByteBuffer, bonusStats.Vegetables);
            SaveHelper.WriteUShortBuffer(writeByteBuffer, bonusStats.ShootTheBullet);
            SaveHelper.WriteUShortBuffer(writeByteBuffer, bonusStats.DreamSpirits);
            SaveHelper.WriteUShortBuffer(writeByteBuffer, bonusStats.ToyoFan);
            SaveHelper.WriteUShortBuffer(writeByteBuffer, bonusStats.MakuraSweetDreams);
            SaveHelper.WriteUShortBuffer(writeByteBuffer, bonusStats.MeekoSheepCount);
            SaveHelper.WriteUByteBuffer(writeByteBuffer, bonusStats.AkyuPoints);
            SaveHelper.WriteUByteBuffer(writeByteBuffer, bonusStats.LilyPoints);

            SaveHelper.WriteByteBuffer(writeByteBuffer, gd.Ng0Playthrough);

            // Unsupported Fields for Team Names
            SaveHelper.WriteListBuffer<sbyte>(writeByteBuffer, uf.TeamIDs);
            SaveHelper.WriteListBuffer<ushort>(writeByteBuffer, uf.CustomNameIDs);
            SaveHelper.WriteListBuffer<string>(writeByteBuffer, uf.CustomNameList);
            SaveHelper.WriteListBuffer<string>(writeByteBuffer, uf.CustomNameHistory);
            SaveHelper.WriteGridBuffer<sbyte>(writeByteBuffer, uf.TeamList);
            SaveHelper.WriteListBuffer<byte>(writeByteBuffer, uf.DefaultTeams);
            SaveHelper.WriteListBuffer<byte>(writeByteBuffer, uf.SelectedTeams);
            SaveHelper.WriteListBuffer<string>(writeByteBuffer, uf.SelectableBGM);

            // Unit Data
            SaveHelper.WriteGridBuffer<byte>(writeByteBuffer, ud.u_UpgradesLv);
            SaveHelper.WriteGridBuffer<byte>(writeByteBuffer, charData.StatsLv);
            SaveHelper.WriteGridBuffer<string>(writeByteBuffer, charData.SkillIDs);
            SaveHelper.WriteGridBuffer<sbyte>(writeByteBuffer, charData.SkillsLv);
            SaveHelper.WriteGridBuffer<string>(writeByteBuffer, ud.u_ItemIDs);
            SaveHelper.WriteListBuffer<string>(writeByteBuffer, ud.UnitNames);
            SaveHelper.WriteListBuffer<string>(writeByteBuffer, ud.UnitIDs);
            SaveHelper.WriteListBuffer<string>(writeByteBuffer, ud.u_BGM);

            SaveHelper.WriteListBuffer<ushort>(writeByteBuffer, uf.RemainingHP);
            SaveHelper.WriteListBuffer<ushort>(writeByteBuffer, uf.RemainingMP);
            SaveHelper.WriteListBuffer<string>(writeByteBuffer, uf.RemainingAmmo);

            SaveHelper.WriteListBuffer<sbyte>(writeByteBuffer, ud.SelectedFUB);

            // Char Data
            SaveHelper.WriteListBuffer<string>(writeByteBuffer, charData.CharNames);
            SaveHelper.WriteListBuffer<string>(writeByteBuffer, charData.CharIDs);
            SaveHelper.WriteListBuffer<ushort>(writeByteBuffer, charData.Curr_EXP);
            SaveHelper.WriteListBuffer<uint>(writeByteBuffer, charData.Curr_PP);
            SaveHelper.WriteListBuffer<uint>(writeByteBuffer, charData.TotalPP);
            SaveHelper.WriteListBuffer<short>(writeByteBuffer, charData.Curr_Kills);
            SaveHelper.WriteListBuffer<ushort>(writeByteBuffer, charData.Curr_WP);
            SaveHelper.WriteListBuffer<string>(writeByteBuffer, charData.ReserveSkills);

            SaveHelper.WriteListBuffer<ushort>(writeByteBuffer, uf.RemainingSP);
            SaveHelper.WriteListBuffer<sbyte>(writeByteBuffer, uf.RemainingPW);

            SaveHelper.WriteListBuffer<sbyte>(writeByteBuffer, charData.SelectedWPB);

            SaveHelper.WriteListBuffer<string>(writeByteBuffer, uf.FriendshipUpdated);
            SaveHelper.WriteListBuffer<byte>(writeByteBuffer, uf.UpdateIDs);
            SaveHelper.WriteListBuffer<string>(writeByteBuffer, uf.UpdatesCharVal);
            SaveHelper.WriteListBuffer<string>(writeByteBuffer, uf.UpdatesResultVal);

            SaveHelper.WriteListBuffer<string>(writeByteBuffer, cd.NgPlusUnitNames);
            SaveHelper.WriteListBuffer<string>(writeByteBuffer, cd.NgPlusUnitIDs);
            SaveHelper.WriteListBuffer<string>(writeByteBuffer, cd.NgPlusCharNames);
            SaveHelper.WriteListBuffer<string>(writeByteBuffer, cd.NgPlusCharIDs);

            SaveHelper.WriteListBuffer<uint>(writeByteBuffer, cd.c_PP);
            SaveHelper.WriteListBuffer<ushort>(writeByteBuffer, cd.c_Kills);

            SaveHelper.WriteListBuffer<byte>(writeByteBuffer, uf.ItemNumRef);

            // Chapter Clear Stats
            SaveHelper.WriteListBuffer<byte>(writeByteBuffer, chapClear.Chaps);
            SaveHelper.WriteListBuffer<sbyte>(writeByteBuffer, chapClear.ChapDifficulties);
            SaveHelper.WriteListBuffer<ushort>(writeByteBuffer, chapClear.ChapTurns);
            SaveHelper.WriteListBuffer<uint>(writeByteBuffer, chapClear.ChapPlayTime);
            SaveHelper.WriteListBuffer<ushort>(writeByteBuffer, chapClear.ChapKills);
            SaveHelper.WriteListBuffer<ushort>(writeByteBuffer, chapClear.ChapEnemies);
            SaveHelper.WriteListBuffer<byte>(writeByteBuffer, chapClear.ChapCasualties);
            SaveHelper.WriteListBuffer<uint>(writeByteBuffer, chapClear.ChapPoints);
            SaveHelper.WriteListBuffer<byte>(writeByteBuffer, chapClear.ChapSpellsCaptured);
            SaveHelper.WriteListBuffer<byte>(writeByteBuffer, chapClear.ChapTotalSpells);
            SaveHelper.WriteListBuffer<byte>(writeByteBuffer, chapClear.ChapBonusAchieved);
            SaveHelper.WriteListBuffer<ushort>(writeByteBuffer, chapClear.ChapGameOvers);
            SaveHelper.WriteListBuffer<ushort>(writeByteBuffer, chapClear.ChapSaves);
            SaveHelper.WriteListBuffer<ushort>(writeByteBuffer, chapClear.ChapLoads);

            // Items
            SaveHelper.WriteListBuffer<string>(writeByteBuffer, it.ItemIDs);
            SaveHelper.WriteListBuffer<byte>(writeByteBuffer, it.TotalItemNums);
            SaveHelper.WriteListBuffer<byte>(writeByteBuffer, it.ItemNums);

            // Event Flags
            SaveHelper.WriteListBuffer<string>(writeByteBuffer, ev.FlagIDs);
            SaveHelper.WriteListBuffer<sbyte>(writeByteBuffer, ev.FlagONList);

            int writtenSize = writeByteBuffer.WrittenCount;

            // Get writeable span from written span so far and write new int file size
            Span<byte> writtenBytes = MemoryMarshal.CreateSpan(ref MemoryMarshal.GetReference(writeByteBuffer.WrittenSpan), writtenSize);
            BinaryPrimitives.WriteInt32LittleEndian(writtenBytes, writtenSize);

            EncryptDecrypt(writtenBytes, true);

            File.WriteAllBytes(outputPath, writtenBytes);
        }

        public void EncryptDecrypt(Span<byte> byteList, bool encrypt)
        {
            int byteCount = 1;
            int byteIncrement = 128;
            int pos = 0;
            int keySize = Convert.FromHexString(concatHash).Length;
            List<int> transformedHash = HexTransform(concatHash);

            for (int i = 0; i < byteList.Length; i++)
            {
                if (encrypt)
                {
                    byteList[i] = (byte)((((byteList[i] + byteIncrement + transformedHash[pos]) & 255) ^ byteCount ^ transformedHash[pos]) & 255);
                }
                else
                {
                    byteList[i] = (byte)((((byteList[i] ^ byteCount ^ transformedHash[pos]) + byteIncrement) - transformedHash[pos]) & 255);
                }

                byteCount += 1;
                if (byteCount > 5000)
                {
                    byteCount = 1;
                    string newHash = string.Join("", [GetUTF16LEMD5(baseHash), GetUTF16LESHA1(baseHash), GetUTF8MD5(baseHash), GetUTF8SHA1(baseHash)]);
                    baseHash = string.Join("", [GetUTF16LEMD5(newHash), GetUTF16LESHA1(newHash), GetUTF8MD5(newHash), GetUTF8SHA1(newHash)]);
                    concatHash = string.Join("", [newHash, baseHash]);
                    transformedHash = HexTransform(concatHash);
                }

                if (encrypt)
                {
                    byteIncrement += transformedHash[keySize - pos - 1] & 1;
                }
                else
                {
                    byteIncrement -= transformedHash[keySize - pos - 1] & 1;
                }

                pos = (pos + 1) % keySize;
                byteIncrement = (byteIncrement + 254) % 255 + 1;
            }

            // Reset hashes
            baseHash = baseHashOrig;
            concatHash = concatHashOrig;
        }

        private static List<int> HexTransform(string byteString)
        {
            List<int> transformedBytes = new List<int>();
            for (int i = 0; i < byteString.Length - 1; i += 2)
            {
                int char1 = (int)byteString[i];
                int char2 = (int)byteString[i + 1];
                int charVal1 = (char1 < 58) ? char1 - 48 : char1 - 94;
                int charVal2 = (char2 < 58) ? char2 - 48 : char2 - 94;
                transformedBytes.Add((charVal1 << 4) + charVal2);
            }

            return transformedBytes;
        }

        private static string GetUTF8SHA1(string content)
        {
            byte[] utf8String = Encoding.UTF8.GetBytes(content);
            byte[] utf8SHA1 = SHA1.HashData(utf8String);
            return Convert.ToHexStringLower(utf8SHA1);
        }

        private static string GetUTF16LESHA1(string content)
        {
            byte[] utf16LEString = Encoding.Unicode.GetBytes(content);
            byte[] utf16LESHA1 = SHA1.HashData(utf16LEString);
            return Convert.ToHexStringLower(utf16LESHA1);
        }

        private static string GetUTF8MD5(string content)
        {
            byte[] utf8String = Encoding.UTF8.GetBytes(content);
            byte[] utf8MD5 = MD5.HashData(utf8String);
            return Convert.ToHexStringLower(utf8MD5);
        }

        private static string GetUTF16LEMD5(string content)
        {
            byte[] utf16LEString = Encoding.Unicode.GetBytes(content);
            byte[] utf16LEMD5 = MD5.HashData(utf16LEString);
            return Convert.ToHexStringLower(utf16LEMD5);
        }
    }
}
