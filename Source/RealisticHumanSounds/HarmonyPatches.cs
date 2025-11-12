using System.Reflection;
using HarmonyLib;
using Verse;

namespace RealisticHumanSounds;

[StaticConstructorOnStartup]
internal static class HarmonyPatches
{
    static HarmonyPatches()
    {
        new Harmony("mlie.RealisticHumanSounds").PatchAll(Assembly.GetExecutingAssembly());
        LoadedModManager.GetMod<RealisticHumanSounds>().UpdateSoundDefs();
    }
}