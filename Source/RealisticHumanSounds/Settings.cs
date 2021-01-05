using SettingsHelper;
using UnityEngine;
using Verse;
using Verse.Sound;

namespace RealisticHumanSounds
{
    public class Settings : ModSettings
    {
        /// <summary>
        /// The settings our mod has.
        /// </summary>
        public enum MaleSounds
        {
            vanilla,
            anime,
            vanillaAlternate
        };
        public enum FemaleSounds
        {
            vanilla,
            anime,
            vanillaAlternate
        };

        public float originalMaleMin;
        public float originalMaleMax;
        public float originalFemaleMin;
        public float originalFemaleMax;
        public MaleSounds selectedMaleSound = MaleSounds.vanilla;
        public FemaleSounds selectedFemaleSound = FemaleSounds.vanilla;
        public float maleVolumePercent = 100f;
        public float femaleVolumePercent = 100f;

        /// <summary>
        /// The part that writes our settings to file. Note that saving is by ref.
        /// </summary>
        public override void ExposeData()
        {
            Scribe_Values.Look(ref selectedMaleSound, "selectedMaleSound");
            Scribe_Values.Look(ref selectedFemaleSound, "selectedFemaleSound");
            Scribe_Values.Look(ref maleVolumePercent, "maleVolumePercent");
            Scribe_Values.Look(ref femaleVolumePercent, "femaleVolumePercent");
            base.ExposeData();
        }
    }

    public class RealisticHumanSounds : Mod
    {
        /// <summary>
        /// A reference to our settings.
        /// </summary>
        readonly Settings settings;

        /// <summary>
        /// A mandatory constructor which resolves the reference to our settings.
        /// </summary>
        /// <param name="content"></param>
        public RealisticHumanSounds(ModContentPack content) : base(content)
        {
            this.settings = GetSettings<Settings>();
        }

        public override void WriteSettings()
        {
            base.WriteSettings();
            UpdateSoundDefs();
        }

        public void UpdateSoundDefs()
        {
            return;
            var soundDefs = DefDatabase<SoundDef>.AllDefs;
            foreach (SoundDef soundDef in soundDefs)
            {
                switch (soundDef.defName)
                {
                    case "Pawn_Male1_Wounded":
                    case "Pawn_Male2_Wounded":
                    case "Pawn_Male1_Death":
                    case "Pawn_Male2_Death":
                        foreach (SubSoundDef subSound in soundDef.subSounds)
                        {
                            if (settings.originalMaleMin == 0) { settings.originalMaleMin = subSound.volumeRange.min; }
                            if (settings.originalMaleMax == 0) { settings.originalMaleMax = subSound.volumeRange.max; }
                            Log.Message(settings.originalMaleMax + " Male before");
                            subSound.volumeRange.max = settings.originalMaleMax * (settings.maleVolumePercent / 100);
                            subSound.volumeRange.min = settings.originalMaleMin * (settings.maleVolumePercent / 100);
                            Log.Message(subSound.volumeRange.max + " Male after");
                        }
                        break;
                    case "Pawn_Female1_Wounded":
                    case "Pawn_Female2_Wounded":
                    case "Pawn_Female1_Death":
                    case "Pawn_Female2_Death":
                        foreach (SubSoundDef subSound in soundDef.subSounds)
                        {
                            if (settings.originalFemaleMin == 0) { settings.originalFemaleMin = subSound.volumeRange.min; }
                            if (settings.originalFemaleMax == 0) { settings.originalFemaleMax = subSound.volumeRange.max; }
                            Log.Message(settings.originalFemaleMax + " Female before");
                            subSound.volumeRange.max = settings.originalFemaleMax * (settings.femaleVolumePercent / 100);
                            subSound.volumeRange.min = settings.originalFemaleMin * (settings.femaleVolumePercent / 100);
                            Log.Message(subSound.volumeRange.max + " Female after");
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// The (optional) GUI part to set your settings.
        /// </summary>
        /// <param name="inRect">A Unity Rect with the size of the settings window.</param>
        public override void DoSettingsWindowContents(Rect inRect)
        {
            if (settings.maleVolumePercent == 0) { settings.maleVolumePercent = 100f; }
            if (settings.femaleVolumePercent == 0) { settings.femaleVolumePercent = 100f; }
            var listing = new Listing_Standard();
            listing.Begin(inRect);
            listing.AddLabeledSlider("Male soundpack", ref settings.selectedMaleSound);
            //listing.Gap();
            //settings.maleVolumePercent = listing.Slider(settings.maleVolumePercent, 50, 200, null, "50%", "200%", 1);
            //listing.Label("Male volume: " + settings.maleVolumePercent + "%");
            listing.AddHorizontalLine(12f);
            listing.AddLabeledSlider("Female soundpack", ref settings.selectedFemaleSound);
            //listing.Gap();
            //settings.femaleVolumePercent = listing.Slider(settings.femaleVolumePercent, 50, 200, null, "50%", "200%", 1);
            //listing.Label("Female volume: " + settings.femaleVolumePercent + "%");
            listing.End();
            settings.Write();
        }

        /// <summary>
        /// Override SettingsCategory to show up in the list of settings.
        /// Using .Translate() is optional, but does allow for localisation.
        /// </summary>
        /// <returns>The (translated) mod name.</returns>
        public override string SettingsCategory()
        {
            return "Realistic Human Sounds";
        }
    }
}
