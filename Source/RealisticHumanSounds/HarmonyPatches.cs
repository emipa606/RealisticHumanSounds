using HarmonyLib;
using Verse;

namespace RealisticHumanSounds;

[StaticConstructorOnStartup]
internal static class HarmonyPatches
{
    static HarmonyPatches()
    {
        new Harmony("mlie.RealisticHumanSounds").PatchAll();
        LoadedModManager.GetMod<RealisticHumanSounds>().UpdateSoundDefs();
    }
}