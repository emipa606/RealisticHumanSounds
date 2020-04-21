using System;
using HarmonyLib;
using Verse;
using Verse.Sound;

namespace RealisticHumanSoundsPatch
{

    [StaticConstructorOnStartup]
    internal static class HarmonyPatches
    {

        static HarmonyPatches()
        {
            new Harmony("mlie.RealisticHumanSounds").PatchAll();
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
                                    soundDef = SoundDef.Named("Pawn_Male1_Wounded");
                                    break;
                                case Gender.Female:
                                    soundDef = SoundDef.Named("Pawn_Female1_Wounded");
                                    break;
                            }
                            return;
                        case "Pawn_Human_Death":
                            switch (info.Maker.Cell.GetFirstPawn(info.Maker.Map).gender)
                            {
                                case Gender.Male:
                                    soundDef = SoundDef.Named("Pawn_Male1_Wounded");
                                    break;
                                case Gender.Female:
                                    soundDef = SoundDef.Named("Pawn_Female1_Wounded");
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
