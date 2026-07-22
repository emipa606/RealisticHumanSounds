using System;
using HarmonyLib;
using Verse;
using Verse.Sound;

namespace RealisticHumanSounds;

[HarmonyPatch(typeof(SoundStarter), nameof(SoundStarter.PlayOneShot), typeof(SoundDef), typeof(SoundInfo))]
public static class SoundStarter_PlayOneShot
{
    private static bool Prefix(ref SoundDef soundDef, ref SoundInfo info)
    {
        if (soundDef == null)
        {
            return true;
        }

        var map = info.Maker.Map;
        if (map == null)
        {
            return true;
        }


        try
        {
            Pawn pawn;
            switch (soundDef.defName)
            {
                case "Pawn_Human_Wounded":
                    if (!LoadedModManager.GetMod<RealisticHumanSounds>().GetSettings<Settings>()
                            .woundedSounds)
                    {
                        return false;
                    }

                    pawn = info.Maker.Thing as Pawn ?? info.Maker.Cell.GetFirstPawn(map);
                    if (pawn == null)
                    {
                        return false;
                    }

                    switch (pawn.gender)
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

                    pawn = info.Maker.Thing as Pawn ?? info.Maker.Cell.GetFirstPawn(map);
                    if (pawn == null)
                    {
                        return false;
                    }

                    switch (pawn.gender)
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