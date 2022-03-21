using System;
using HarmonyLib;
using Verse;
using Verse.Sound;

namespace RealisticHumanSounds;

[StaticConstructorOnStartup]
internal static class HarmonyPatches
{
    static HarmonyPatches()
    {
        new Harmony("mlie.RealisticHumanSounds").PatchAll();
        LoadedModManager.GetMod<RealisticHumanSounds>().UpdateSoundDefs();
    }

    [HarmonyPatch(typeof(SoundStarter), "PlayOneShot", typeof(SoundDef), typeof(SoundInfo))]
    public class Patch
    {
        private static bool Prefix(ref SoundDef soundDef, ref SoundInfo info)
        {
            try
            {
                switch (soundDef.defName)
                {
                    case "Pawn_Human_Wounded":
                        if (!LoadedModManager.GetMod<RealisticHumanSounds>().GetSettings<Settings>()
                                .woundedSounds)
                        {
                            return false;
                        }

                        switch (info.Maker.Cell.GetFirstPawn(info.Maker.Map).gender)
                        {
                            case Gender.Male:
                                switch (LoadedModManager.GetMod<RealisticHumanSounds>().GetSettings<Settings>()
                                            .selectedMaleSound)
                                {
                                    case Settings.MaleSounds.vanilla:
                                        soundDef = SoundDef.Named("Pawn_Male1_Wounded");
                                        break;
                                    case Settings.MaleSounds.anime:
                                        soundDef = SoundDef.Named("Pawn_Male2_Wounded");
                                        break;
                                    case Settings.MaleSounds.vanillaAlternate:
                                        soundDef = SoundDef.Named("Pawn_Male3_Wounded");
                                        break;
                                }

                                break;
                            case Gender.Female:
                                switch (LoadedModManager.GetMod<RealisticHumanSounds>().GetSettings<Settings>()
                                            .selectedFemaleSound)
                                {
                                    case Settings.FemaleSounds.vanilla:
                                        soundDef = SoundDef.Named("Pawn_Female1_Wounded");
                                        break;
                                    case Settings.FemaleSounds.anime:
                                        soundDef = SoundDef.Named("Pawn_Female2_Wounded");
                                        break;
                                    case Settings.FemaleSounds.vanillaAlternate:
                                        soundDef = SoundDef.Named("Pawn_Female3_Wounded");
                                        break;
                                }

                                break;
                        }

                        return true;
                    case "Pawn_Human_Death":
                        if (!LoadedModManager.GetMod<RealisticHumanSounds>().GetSettings<Settings>()
                                .deathSounds)
                        {
                            return false;
                        }

                        switch (info.Maker.Cell.GetFirstPawn(info.Maker.Map).gender)
                        {
                            case Gender.Male:
                                switch (LoadedModManager.GetMod<RealisticHumanSounds>().GetSettings<Settings>()
                                            .selectedMaleSound)
                                {
                                    case Settings.MaleSounds.vanilla:
                                        soundDef = SoundDef.Named("Pawn_Male1_Death");
                                        break;
                                    case Settings.MaleSounds.anime:
                                        soundDef = SoundDef.Named("Pawn_Male2_Death");
                                        break;
                                    case Settings.MaleSounds.vanillaAlternate:
                                        soundDef = SoundDef.Named("Pawn_Male3_Death");
                                        break;
                                }

                                break;
                            case Gender.Female:
                                switch (LoadedModManager.GetMod<RealisticHumanSounds>().GetSettings<Settings>()
                                            .selectedFemaleSound)
                                {
                                    case Settings.FemaleSounds.vanilla:
                                        soundDef = SoundDef.Named("Pawn_Female1_Death");
                                        break;
                                    case Settings.FemaleSounds.anime:
                                        soundDef = SoundDef.Named("Pawn_Female2_Death");
                                        break;
                                    case Settings.FemaleSounds.vanillaAlternate:
                                        soundDef = SoundDef.Named("Pawn_Female3_Death");
                                        break;
                                }

                                break;
                        }

                        return true;
                }
            }
            catch (Exception exception)
            {
                Log.Warning($"Sound is supposed to be {soundDef?.defName}, cannot figure out gender. {exception}");
            }

            return true;
        }
    }
}