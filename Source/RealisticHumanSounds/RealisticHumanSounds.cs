using System;
using System.Linq;
using UnityEngine;
using Verse;
using static RealisticHumanSounds.Settings;

namespace RealisticHumanSounds;

public class RealisticHumanSounds : Mod
{
    /// <summary>
    ///     A reference to our settings.
    /// </summary>
    private readonly Settings settings;

    /// <summary>
    ///     A mandatory constructor which resolves the reference to our settings.
    /// </summary>
    /// <param name="content"></param>
    public RealisticHumanSounds(ModContentPack content) : base(content)
    {
        settings = GetSettings<Settings>();
    }

    public override void WriteSettings()
    {
        base.WriteSettings();
        UpdateSoundDefs();
    }

    public void UpdateSoundDefs()
    {
        var soundDefs =
            DefDatabase<SoundDef>.AllDefs.Where(def =>
                def.defName.EndsWith("_Wounded") || def.defName.EndsWith("_Death"));
        foreach (var soundDef in soundDefs)
        {
            if (soundDef.defName.StartsWith("Pawn_Male"))
            {
                foreach (var subSound in soundDef.subSounds)
                {
                    if (settings.originalMaleMin == 0)
                    {
                        settings.originalMaleMin = subSound.volumeRange.min;
                    }

                    if (settings.originalMaleMax == 0)
                    {
                        settings.originalMaleMax = subSound.volumeRange.max;
                    }

                    subSound.volumeRange.max = settings.originalMaleMax * (settings.maleVolumePercent / 100);
                    subSound.volumeRange.min = settings.originalMaleMin * (settings.maleVolumePercent / 100);
                }

                soundDef.ResolveReferences();
                continue;
            }

            foreach (var subSound in soundDef.subSounds)
            {
                if (settings.originalFemaleMin == 0)
                {
                    settings.originalFemaleMin = subSound.volumeRange.min;
                }

                if (settings.originalFemaleMax == 0)
                {
                    settings.originalFemaleMax = subSound.volumeRange.max;
                }

                subSound.volumeRange.max =
                    settings.originalFemaleMax * (settings.femaleVolumePercent / 100);
                subSound.volumeRange.min =
                    settings.originalFemaleMin * (settings.femaleVolumePercent / 100);
            }

            soundDef.ResolveReferences();
        }
    }

    /// <summary>
    ///     The (optional) GUI part to set your settings.
    /// </summary>
    /// <param name="inRect">A Unity Rect with the size of the settings window.</param>
    public override void DoSettingsWindowContents(Rect inRect)
    {
        if (settings.maleVolumePercent == 0)
        {
            settings.maleVolumePercent = 100f;
        }

        if (settings.femaleVolumePercent == 0)
        {
            settings.femaleVolumePercent = 100f;
        }

        var listing = new Listing_Standard();
        listing.Begin(inRect);
        listing.Label("RHS.malesoundpack".Translate());
        foreach (var soundSet in (MaleSounds[])Enum.GetValues(typeof(MaleSounds)))
        {
            if (listing.RadioButton(soundSet.ToString(), settings.selectedMaleSound == soundSet))
            {
                settings.selectedMaleSound = soundSet;
            }
        }

        listing.Gap();
        listing.Label("RHS.malevolume".Translate(settings.maleVolumePercent));
        listing.Gap();
        settings.maleVolumePercent = listing.Slider(settings.maleVolumePercent, 50, 200);
        listing.GapLine();
        listing.Label("RHS.femalesoundpack".Translate());
        foreach (var soundSet in (FemaleSounds[])Enum.GetValues(typeof(FemaleSounds)))
        {
            if (listing.RadioButton(soundSet.ToString(), settings.selectedFemaleSound == soundSet))
            {
                settings.selectedFemaleSound = soundSet;
            }
        }

        listing.Gap();
        listing.Label("RHS.femalevolume".Translate(settings.femaleVolumePercent));
        listing.Gap();
        settings.femaleVolumePercent = listing.Slider(settings.femaleVolumePercent, 50, 200);
        listing.Gap();
        listing.CheckboxLabeled("RHS.deathsounds".Translate(), ref settings.deathSounds);
        listing.CheckboxLabeled("RHS.woundedsounds".Translate(), ref settings.woundedSounds);
        listing.End();
        settings.Write();
    }

    /// <summary>
    ///     Override SettingsCategory to show up in the list of settings.
    ///     Using .Translate() is optional, but does allow for localisation.
    /// </summary>
    /// <returns>The (translated) mod name.</returns>
    public override string SettingsCategory()
    {
        return "Realistic Human Sounds";
    }
}