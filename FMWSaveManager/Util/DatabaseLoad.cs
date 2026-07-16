using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace FMWSaveManager.Util
{
    public static class DatabaseLoad
    {
        public static Dictionary<string, string> ItemRecords { get; private set; }
        public static Dictionary<string, string> ChapterRecords { get; private set; }
        // public static Dictionary<string, string> SkillRecords { get; private set; }
        // public static string[] SkillIDRecords { get; private set; }
        static DatabaseLoad()
        {
            ItemRecords = JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText(Application.StartupPath + "/Database/Items.json"));
            ChapterRecords = JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText(Application.StartupPath + "/Database/Chapters.json"));

            // TODO: Integrate skill dictionaries into selectable options in CharEditor skill comboboxes
            // SkillRecords = JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText(Application.StartupPath + "/Database/Skills.json"));
            // SkillIDRecords = JsonSerializer.Deserialize<string[]>(File.ReadAllText(Application.StartupPath + "/Database/SkillIDs.json"));
        }
    }
}
