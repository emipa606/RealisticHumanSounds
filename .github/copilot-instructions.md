# GitHub Copilot Instructions for Realistic Human Sounds (Continued) Mod

## Mod Overview and Purpose
The "Realistic Human Sounds (Continued)" mod is designed to enhance the gaming experience in RimWorld by introducing realistic pain and death sounds for human pawns. This mod aims to make battles sound more immersive and intense, capturing the essence of combat through audio. Originally developed by LimitedS, the mod has been updated for RimWorld 1.6 and re-released using Asset Bundles to optimize size and performance.

## Key Features and Systems
- **Improved Audio Support**: Utilizes RimWorld 1.6's Asset Bundle support for efficient sound management.
- **Diverse Soundpacks**: Includes several soundpacks with both male and female sounds, sourced from popular games like Fallout 4, Battlefield 5, Rising Storm 2, and Skyrim.
- **Volume and Soundpack Customization**: Allows players to adjust volume settings and choose between different soundpacks.
- **Integrated Settings**: Offers configurable settings for playing death and wounded sounds.
- **Compatibility Patches**: Includes patches for other mods such as HAR and Android Tiers to expand sound compatibility.

## Coding Patterns and Conventions
- **C# Conventions**: Adheres to standard C# coding practices, ensuring clean and readable code.
- **Class Design**: Utilizes primarily static classes for patching and setting management.
- **Method Naming**: Methods are descriptively named to indicate their functionality (e.g., `UpdateSoundDefs`).

## XML Integration
- The mod integrates XML definitions to manage sound definitions seamlessly.
- XML files are typically used to define sound properties and categories, maintaining clear separation between data and logic.

## Harmony Patching
- **HarmonyPatches.cs**: Contains static classes to apply Harmony patches, modifying or extending the base game methods where necessary.
- Harmony is used to inject or alter game behavior without modifying the original source code, ensuring compatibility and ease of maintenance.

## Suggestions for Copilot
1. **Automatic XML Transformation**: Assist in generating and modifying XML files for sound definitions, reducing manual errors.
2. **Soundpack Integration**: Help automate the process of adding new soundpacks by auto-detecting and configuring new audio files.
3. **Patch Optimization**: Optimize Harmony patching methods with suggested improvements based on code usage patterns.
4. **Debug Assistance**: Provide automated code suggestions to resolve common modding errors or conflicts.
5. **Documentation Prompting**: Suggest inline documentation for classes and methods to maintain comprehensive code documentation.
6. **User Interface Enhancements**: Assist in designing mod settings interfaces within RimWorld, recommending UI improvements for better user experience.

---

Ensure you load this mod last in your mod list to prevent conflicts. For bug reporting, please use the dedicated Discord channel and submit logs with the Log Uploader. Contributions and error solutions can be posted directly to the GitHub repository. Use tools like RimSort for ideal mod sorting and compatibility.
