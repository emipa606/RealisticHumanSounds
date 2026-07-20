# GitHub Copilot Instructions for Realistic Human Sounds (Continued)

## Mod Overview and Purpose

The "Realistic Human Sounds (Continued)" mod for RimWorld is an auditory enhancement mod that aims to create a more immersive battle experience. It updates and continues the work from the original mod by LimitedS, adding realistic human pain and death sounds to the game. These sounds are primarily sourced from the Battlefield series and other popular games to ensure authenticity. The mod capitalizes on RimWorld's 1.6 update, utilizing improved asset bundle support to maintain a manageable mod size.

## Key Features and Systems

- **Support for Female Sounds:** The mod now includes sound packs specifically for female characters, adding diversity to the auditory experience.
- **Volume Sliders:** Players can adjust the volume of sounds for a customized gameplay experience.
- **Soundpack Selection:** Users can choose from different sound packs to tailor the mod to personal preferences.
- **Selective Sound Playback:** Players can configure whether sounds for death or injuries should play.
- **Diverse Sound Packs:** The mod comes with multiple sound packs, with contributions from various sound enthusiasts:
  - Male sound packs provided by Quo-S (sourced from FO4 and BF5)
  - Male sound pack 3 contributed by Battlefleet Covfefe (primarily sourced from Skyrim)

### Integration with Other Mods

- **HAR-mod Patches:** There are add-ons available that integrate sounds with the Humanoid Alien Races (HAR) mods, enhancing compatibility with other game modifications.

## Coding Patterns and Conventions

When contributing to or modifying this mod, adhere to the following conventions:

- **Code Structure:** Maintain a clear and consistent structure within the C# files, ensuring methods and classes are well-commented and logically organized.
- **Naming Conventions:** Use PascalCase for class names and methods. Use camelCase for local variables and parameters.
- **XML Structure:** Ensure proper indentation and spacing for readability in XML definition files. Comment any major sections to explain their purpose.

## XML Integration

The mod uses XML patches to integrate with RimWorld's def database. These XML files define how new and existing sound cues are adjusted or added. Maintain the XML’s hierarchical structure to ensure compatibility with RimWorld's parsing.

## Harmony Patching

The mod uses the Harmony library for safe modification of game methods, which is crucial for maintaining compatibility with other mods:

- **HarmonyPatches.cs:** This file contains the necessary patches to hook into the game's sound playback methods. Use careful inspection of existing game code to determine where patches should be applied.
- Ensure that any Harmony patches:
  - Are reversible, allowing players to safely disable the mod without corrupting their game.
  - Do not inadvertently affect unrelated game functionality.

## Suggestions for Copilot

When using GitHub Copilot or any AI code-assistant, consider the following suggestions to improve code suggestions and contribute effectively:

- **Explicitly Define Intent:** Clearly comment sections of the code where complex logic is applied. This helps Copilot generate contextually accurate code.
- **Review and Refactor:** Carefully review Copilot's suggestions, as AI-generated code may not always align perfectly with the project's standards or intentions.
- **Initial Setup:** Guide Copilot to relevant methods, libraries, and patterns by providing examples and explicit instructions in comments where complex integrations are involved.
- **Leverage Copilot for Repetitive Tasks:** Use Copilot to assist with repetitive patterns, such as generating multiple settings options or creating similar methods within the same class framework.

By adhering to these guidelines, contributors can enhance their development workflow, ensuring that the mod remains robust, reliable, and true to its intended purpose.

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

