using SettingsHelper;
using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace RealisticHumanSounds
{
    public class Settings : ModSettings
    {
        /// <summary>
        /// The settings our mod has.
        /// </summary>
        public enum maleSounds
        {
            vanilla,
            anime
        };
        public enum femaleSounds
        {
            vanilla,
            anime
        };

        public maleSounds selectedMaleSound = maleSounds.vanilla;
        public femaleSounds selectedFemaleSound = femaleSounds.vanilla;

        /// <summary>
        /// The part that writes our settings to file. Note that saving is by ref.
        /// </summary>
        public override void ExposeData()
        {
            Scribe_Values.Look(ref selectedMaleSound, "selectedMaleSound");
            Scribe_Values.Look(ref selectedFemaleSound, "selectedFemaleSound");
            base.ExposeData();
        }
    }

    public class RealisticHumanSounds : Mod
    {
        /// <summary>
        /// A reference to our settings.
        /// </summary>
        Settings settings;

        /// <summary>
        /// A mandatory constructor which resolves the reference to our settings.
        /// </summary>
        /// <param name="content"></param>
        public RealisticHumanSounds(ModContentPack content) : base(content)
        {
            this.settings = GetSettings<Settings>();
        }

        /// <summary>
        /// The (optional) GUI part to set your settings.
        /// </summary>
        /// <param name="inRect">A Unity Rect with the size of the settings window.</param>
        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listing = new Listing_Standard();
            listing.Begin(inRect);
            listing.AddLabeledSlider("Male soundpack", ref settings.selectedMaleSound);
            listing.AddLabeledSlider("Female soundpack", ref settings.selectedFemaleSound);
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
