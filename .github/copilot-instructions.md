# GitHub Copilot Instructions for RimWorld Modding Project: Tangle Weed (Continued)

## Mod Overview and Purpose
**Tangle Weed (Continued)** is an updated version of Arcane_Chill's original "Tangleweed" mod for RimWorld. The mod introduces a new plant, the "Tangleweed vine," which is strategically designed for defensive purposes. Its primary function is to hinder enemy movement by creating challenging terrain that slows down their progress.

The mod is balanced to ensure that while Tangleweed is an effective defensive tool, it doesn't unbalance the game. It presents a middle ground in growth time between food crops and trees, allowing for strategic placement and use in colony defense.

## Key Features and Systems
- **Tangleweed Vine:**
  - A unique plant that significantly slows down anyone attempting to walk through it.
  - Suitable for defensive strategies, either by fortifying the area around critical structures or by designing mazes to delay enemy assaults.

- **Strategic Growth Cycle:**
  - Grows faster than trees but slower than food crops.
  - Requires careful planning for effective deployment in defense.

- **Community Feedback Integration:**
  - Players are encouraged to provide feedback for ongoing improvements and enhancements.

## Coding Patterns and Conventions
The mod follows common C# programming conventions designed for RimWorld modding. Key points include:
- Use of PascalCase for class names and public members.
- Use of camelCase for private members and local variables.
- Emphasis on code readability and maintainability.

### Main C# Files:
1. **TangleweedFinder.cs**
   - Contains logic for identifying the presence and location of Tangleweed within the game.
   - Key Class: `TangleweedFinder`
   - Key Method: `FirstTangleweed`

2. **AttackPlantUtility.cs**
   - Provides utilities for interactions with Tangleweed during attacks.
   - Key Class: `AttackPlantUtility`
   - Key Methods: `AttackPlant`, `finalizeTrashJob`

3. **JobGiver_AITangleweedDestroyer.cs**
   - Governs AI behavior in relation to Tangleweed, such as prioritizing its removal when necessary.
   - Key Class: `JobGiver_AITangleweedDestroyer`
   - Key Method: `TryGiveJob`

## XML Integration
XML files play a significant role in defining the properties and configurations of the mod. This includes:
- **AssultColony_Patch.xml:** Contains XML patches to modify specific game behaviors related to colony assaults.
- **Plants_Cultivated_Hostile.xml:** Defines the Tangleweed plant's properties, such as growth cycles and defensive capabilities.
- XML files follow `DefInjected` conventions for integrating into RimWorld's def structure, using descriptive naming and detailed configuration options.

## Harmony Patching
Harmony is employed to modify the base game behavior non-destructively. The mod leverages Harmony patches to ensure compatibility and minimize conflicts with other mods. Key considerations include:
- Ensuring patches are well-scoped to avoid unintended interactions.
- Employing prefixes and postfixes where appropriate to modulate base game methods.

## Suggestions for Copilot
To enhance Copilot's ability to assist in this project, consider the following suggestions:
- Ensure that function names are descriptive of their purpose and invoke relevant domain terms, like "Tangleweed," "Defensive," and "AiLogic."
- Consistently comment code to provide context to Copilot, improving its prediction accuracy during coding sessions.
- Structure XML files with clear headers and section comments to enable Copilot to assist effectively in XML configuration.
- Provide Copilot with context on RimWorld-specific classes and methods to improve its ability to recommend suitable code modifications and additions.

By adhering to these detailed guidelines and practices, you will enhance both the maintenance and development process of the **Tangle Weed (Continued)** mod, while leveraging GitHub Copilot effectively for further development.

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

