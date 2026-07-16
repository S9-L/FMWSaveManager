using System;

namespace FMWSaveManager.FileFormats
{
    internal interface ISaveFile
    {
        public void ReadFile(string filePath);
        public void EncryptDecrypt(Span<byte> byteList, bool encrypt);
        public void WriteSaveBytes(string outputPath, GeneralData gd, NGPlusCarryover cd,
            BonusStats bonusStats, UnsupportedFields uf, UnitData ud,
            CharData charData, ChapterClearData chapClear, Items it, EventFlags ev, bool import);
        public void ReadSaveBytes(GeneralData gd, NGPlusCarryover cd,
            BonusStats bonusStats, UnsupportedFields uf, UnitData ud,
            CharData charData, ChapterClearData chapClear, Items it, EventFlags ev);
    }
}
