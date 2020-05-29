using System;
using HarmonyLib;
using Verse;
using Verse.Sound;

namespace RealisticHumanSounds
{

    [StaticConstructorOnStartup]
    internal static class HarmonyPatches
    {

        static HarmonyPatches()
        {
            new Harmony("mlie.RealisticHumanSounds").PatchAll();
            LoadedModManager.GetMod<RealisticHumanSounds>().UpdateSoundDefs();
        }

        [HarmonyPatch(typeof(SoundStarter), "PlayOneShot", new Type[] { typeof(SoundDef), typeof(SoundInfo) })]
        class Patch
        {
            static void Prefix(ref SoundDef soundDef, ref SoundInfo info)
            {
                try
                {
                    switch (soundDef.defName)
                    {
                        case "Pawn_Human_Wounded":
                            switch (info.Maker.Cell.GetFirstPawn(info.Maker.Map).gender)
                            {
                                case Gender.Male:
                                    switch (LoadedModManager.GetMod<RealisticHumanSounds>().GetSettings<Settings>().selectedMaleSound)
                                    {
                                        case Settings.maleSounds.vanilla:
                                            soundDef = SoundDef.Named("Pawn_Male1_Wounded");
                                            break;
                                        case Settings.maleSounds.anime:
                                            soundDef = SoundDef.Named("Pawn_Male2_Wounded");
                                            break;
                                    }
                                    break;
                                case Gender.Female:
                                    switch (LoadedModManager.GetMod<RealisticHumanSounds>().GetSettings<Settings>().selectedFemaleSound)
                                    {
                                        case Settings.femaleSounds.vanilla:
                                            soundDef = SoundDef.Named("Pawn_Female1_Wounded");
                                            break;
                                        case Settings.femaleSounds.anime:
                                            soundDef = SoundDef.Named("Pawn_Female2_Wounded");
                                            break;
                                    }
                                    break;
                            }
                            return;
                        case "Pawn_Human_Death":
                            switch (info.Maker.Cell.GetFirstPawn(info.Maker.Map).gender)
                            {
                                case Gender.Male:
                                    switch (LoadedModManager.GetMod<RealisticHumanSounds>().GetSettings<Settings>().selectedMaleSound)
                                    {
                                        case Settings.maleSounds.vanilla:
                                            soundDef = SoundDef.Named("Pawn_Male1_Death");
                                            break;
                                        case Settings.maleSounds.anime:
                                            soundDef = SoundDef.Named("Pawn_Male2_Death");
                                            break;
                                    }
                                    break;
                                case Gender.Female:
                                    switch (LoadedModManager.GetMod<RealisticHumanSounds>().GetSettings<Settings>().selectedFemaleSound)
                                    {
                                        case Settings.femaleSounds.vanilla:
                                            soundDef = SoundDef.Named("Pawn_Female1_Death");
                                            break;
                                        case Settings.femaleSounds.anime:
                                            soundDef = SoundDef.Named("Pawn_Female2_Death");
                                            break;
                                    }
                                    break;
                            }
                            return;
                    }
                }
                catch (Exception exception)
                {
                    Log.Warning($"Sound is supposed to be {soundDef.defName}, cannot figure out gender. {exception.ToString()}");
                }
            }
        }

    }
}
