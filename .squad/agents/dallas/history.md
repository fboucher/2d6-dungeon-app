# Dallas — History

## Project Context

Project: 2d6 Dungeon App — dungeon crawler game
Stack: .NET Aspire, Blazor web client, C# domain/services
Repo: https://github.com/fboucher/2d6-dungeon-app
Owner: Frank

Key paths:
- Frontend: src/2d6-dungeon-web-client/Components/
- Backend: src/2d6-dungeon-service/
- Domain: src/2d6-dungeon-service/domain/
- Services: src/2d6-dungeon-service/Services/

## Learnings

- **Issue #45 (Parameter casing standard):** Renamed `state` → `State` in `Adventurer.razor` (route, template `@if`, and `@code` block) and `adventureId` → `AdventureId` in `Play.razor` (route, `@code` block usages: `OnInitializedAsync` guard and `GetAdventure` call). Applied private backing field pattern (`_state`, `_adventureId`) with PascalCase public `[Parameter]` properties.

- **Lambert (2026-02-28): Map Graphics Improvement** — Enhanced dungeon map visuals using pure Canvas 2D (canvasTools.js): parchment background, 3D beveled walls with shadows, stone tile patterns, torch glow effects. No external libraries per user preference.
