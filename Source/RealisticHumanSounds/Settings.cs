using Verse;

namespace RealisticHumanSounds;

public class Settings : ModSettings
{
    public enum FemaleSounds
    {
        vanilla,
        anime,
        vanillaAlternate
    }

    /// <summary>
    ///     The settings our mod has.
    /// </summary>
    public enum MaleSounds
    {
        vanilla,
        anime,
        vanillaAlternate
    }

    public float femaleVolumePercent = 100f;
    public float maleVolumePercent = 100f;
    public float originalFemaleMax;
    public float originalFemaleMin;
    public float originalMaleMax;

    public float originalMaleMin;
    public FemaleSounds selectedFemaleSound = FemaleSounds.vanilla;
    public MaleSounds selectedMaleSound = MaleSounds.vanilla;

    /// <summary>
    ///     The part that writes our settings to file. Note that saving is by ref.
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