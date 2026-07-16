# Fantasy Maiden Wars Save Manager
A powerful and flexible save manager for the Fantasy Maiden Wars series, written in C# using .NET 10.0. 

Designed with simplicity in mind, this save manager enables any player to fine-tune their save files to their liking, all while being wrapped in an intuitively designed interface. The tool largely does away with messy Cheat Engine overrides of in-memory values or hex editing, so the player can focus on making easy, on-the-fly modifications that can be updated independently of the game session.

Included alongside the editing capabilities is the **Save Import** feature. Any compatible save from an older Fantasy Maiden Wars game can be imported into the Switch/Steam save format. As of release 1.0.0, all compatible saves from the Doujin PC release of Complete Box can be imported and played on the most recent Switch/Steam versions of CB.

This tool supports editing the vanilla Switch/Steam versions of Complete Box detailed below, along with extended support for modded versions.
The usual disclaimers apply for any save managing application: Always, always, **ALWAYS** back up your save files for your fallback, and be discrete when making changes to your saves.

# Prerequisites
- [.NET 10.0 Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)
- Windows 10+
- `gswx_*.sav` save files to import from the original Doujin PC release of Complete Box
- `gsw_*.sav` save files to edit from the Switch/Steam versions of Complete Box

# Features
  * Imports any compatible save out of the box from the Doujin PC release of Complete Box to play on the Switch/Steam version.
    * Choose between single file or batch import modes at your convenience.
  * Functions as an all-in-one tool to edit various groups of save proerties through organized interfaces.
  * Supports editing saves on-the-fly without needing to restart your current active game session.
  * Use cases for each of the sub-editor interfaces:
    * Modify your Points and WP on hand, or change the current chapter/route to jump to any other point in the story.
    * Utilize a full-fledged unit/character status editor:
      * Change UnitIDs, unit upgrade levels, and equipped items, or set a unit's Full Upgrade Bonus.
      * Change CharIDs, Character Level, PP, and invested Stat points. Additionally, you can use the dedicated skill editor to give a character any arbitrary skill in their 8 skill slots, including PSes and unique skills (Shrine Maiden, Magician, Buddhist, Child of Miare, etc.).
      * Add and delete data entries for full control over your roster's vanilla or custom unit/character data.
    * Adjust your Item Inventory to give yourself as many or as little items as you need.
    * Modify various features that are tied to the NG+ Carryover system.
      * Edit the total Points/WP values that are carried over into the subsequent NG+ playthrough. 
      * Change the Names/UnitIDs/CharIDs of your roster entities that are selected for NG+.
        * For NG+ character data, you can also adjust how many PP/Kills are carried over into the next NG+ playthrough.
      * Add and delete data entries to control which entities in your roster should be treated as NG+ units/characters.
    * View and change Bonus/Max Damage stats that are displayed during the game ending sequence.
      * NOTE: Certain Bonus Stats are hidden or untracked by the vanilla game, and require additional code patching to see. Check out the modding repo for updates on these: https://github.com/S9-L/fmw_patches.
    * View your chapter clear stats for all cleared chapters so far in the save. Edit the records to your desire.
    * Set event flags on/off to trigger certain unlocks throughout the game.

# Compatibility
## Importing to Switch/Steam Format

|| Doujin CB | FMW4 | FMW3 | FMW2 | FMW1 |
| :---: | :---: | :---: | :---: | :---: | :---: |
| Supported | Yes | TBD | TBD | TBD | TBD |
| Versions  | 1.0.1 - 1.1.3 | TBD | TBD | TBD | TBD |

## Save Editing

|| Steam | Switch | Doujin CB | FMW4 | FMW3 | FMW2 | FMW1 |
| :---: | :---: | :---: | :---: | :---: | :---: | :---: | :---: |
| Supported | Yes | Yes | TBD | TBD | TBD | TBD | TBD |
| Versions  | 1.2.0 - 1.2.4 | 1.0.0 - 1.2.5 | TBD | TBD | TBD | TBD | TBD |

# Instructions
Please reference the comprehensive repo [wiki](https://github.com/S9-L/FMWSaveManager/wiki) documenting various features in the save manager. The information consolidated there will enable you to fully take advantage of the save manager's capabilties.

# Troubleshooting
If you encounter problems with the tool, open an issue in this repo. In the issue, describe the bug scenario and any reported exception/error message to greatly ease debugging and expedite resolution.

For further troubleshooting and/or discussing the game, reach out in the Save Manager Mod Projects Forum in the [unofficial FMW Discord server](https://discord.gg/q7tpedHj68)!

# Contributing
Contributions are welcome! If you would like to contribute with a feature to the source code, go ahead and open a pull request and request a review of your proposed changes. 

# Development Roadmap
* Initial Release - 1.0.0
  * Import into Switch/Steam feature
  * Capability of editing Switch/Steam saves
    * General Data Editor
    * Entities Editor
      * Unit Editor
      * Character Editor
    * Items Editor
    * NG+ Carryover Editor
    * Bonus Stats Editor
    * Chapter Clear Stats Editor
    * Event Flags Editor
* Future Releases
  * Functional user controls to max/min desired values for unit/character data, resources, stats, etc.
  * Randomize skill selection in Character Editor.
  * Custom Team Name editing for modded versions of the game
  * Onboard original FMW1-FMW4 saves to import into Switch/Steam
  * Editing capability for FMW1-4 + Doujin PC Complete Box saves
  * Extend to alternative UI framework like Avalonia UI, and clean up frontend structure and binding
  * Migrate to web-based application

# Screenshots
![1.0.0 Character Editor](https://i.imgur.com/G7tRNDr.png)
![1.0.0 Save Import](https://i.imgur.com/ytp7d7y.png)

# Credits
* Designed and coded by SQ-L, with the goal in mind to create a "Swiss Army Knife" of FMW save editing for vanilla/modded game versions.
* Inspired by the Etrian Odyssey IV save editor, [Tharsis Forge](https://github.com/xdanieldzd/TharsisForge), written by [xdanieldzd](https://github.com/xdanieldzd).
  * ListBox extension implementation sourced from same repo, under MIT license.

* Logging functionality is implemented with [Serilog](https://github.com/serilog/serilog).
* Log streaming to displayed UI textbox is implemented with the [Serilog.Sinks.RichTextBox.WinForms.Colored NuGet package](https://www.nuget.org/packages/Serilog.Sinks.RichTextBox.WinForms.Colored).
