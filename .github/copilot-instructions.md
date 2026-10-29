# GitHub Copilot Instructions for Realistic Human Sounds (Continued) Mod

## Mod Overview and Purpose

The Realistic Human Sounds (Continued) mod for RimWorld adds realistic pain and death sounds to most pawns, enhancing the immersion of battles. The mod is an updated version of the LimitedS mod, now utilizing Asset Bundles to reduce the size of the mod. It includes support for female sounds, volume sliders, and multiple sound packs. This mod ensures that your battles will sound more realistic and painful, with most sounds sourced from the Battlefield series and Rising Storm 2.

## Key Features and Systems

1. **Support for Female Sounds**: The mod now includes sound packs specifically for female pawns.
2. **Volume Sliders**: Users can adjust the volume of the sounds through the mod settings.
3. **Soundpack Selection**: Users can choose different sound packs to customize the sounds.
4. **Death and Wounded Sounds**: Users can set whether to play death or wounded sounds.
5. **Multiple Sound Packs**: The mod includes several sound packs, with more provided by contributors.

## Coding Patterns and Conventions

- **Harmony Patching**: The mod uses Harmony patching to inject code into the RimWorld game codebase.
- **XML Integration**: XML files are used to define patches and settings for the mod.
- **Settings Management**: The mod includes a settings system to manage user preferences.
- **Sound Starter**: Custom sound starter classes are used to play one-shot sound effects.

## XML Integration

The mod uses XML files to define patches and settings. The primary XML file is located at `1.6/Patches/BaseMod_Patch.xml`. This file contains the necessary definitions to integrate the mod with the RimWorld game.

### Example XML Patch

xml
<Patch>
    <Operation Class="Harmony.HarmonyPatch">
        <Target>
            <Method>
                <DeclaringType FullName="Verse.Pawn"/>
                <Name>Die</Name>
            </Method>
        </Target>
        <Prefix Class="RealisticHumanSounds.SoundStarter_PlayOneShot"/>
    </Operation>
</Patch>


## Harmony Patching

The mod uses Harmony patching to inject code into the RimWorld game codebase. The `HarmonyPatches` class contains the necessary Harmony patches.

### Example Harmony Patch

csharp
using HarmonyLib;

namespace RealisticHumanSounds
{
    [HarmonyPatch(typeof(Pawn), "Die")]
    public static class HarmonyPatches
    {
        public static void Prefix(Pawn __instance)
        {
            // Play death sound
            SoundStarter_PlayOneShot.PlayOneShot(SoundDef.Named("DeathSound"));
        }
    }
}


## Suggestions for Copilot

1. **Code Generation for Patches**: Use Copilot to generate Harmony patches for specific game methods.
2. **Settings Management**: Use Copilot to generate code for managing mod settings and user preferences.
3. **Sound Starter Classes**: Use Copilot to generate custom sound starter classes for playing one-shot sound effects.
4. **XML Definitions**: Use Copilot to generate XML definitions for patches and settings.

By following these guidelines and suggestions, developers can efficiently contribute to the Realistic Human Sounds (Continued) mod and enhance the immersive experience for RimWorld players.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

